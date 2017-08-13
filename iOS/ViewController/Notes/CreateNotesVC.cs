﻿using System;
using System.Collections.Generic;
using Foundation;
using IosUtils;
using LucidX.ResponseModels;
using LucidX.Webservices;
using UIKit;
using Xamarin.SWRevealViewController;
using LucidX.iOS.CustomCells;
using LucidX.iOS.PickerModels;
using LucidX.RequestModels;
using System.Threading.Tasks;
using LucidX.Enums;
using LucidX.Constants;

namespace LucidX.iOS.Notes
{
	public partial class CreateNotesVC : UIViewController, IUITextFieldDelegate, IUIScrollViewDelegate
	{

		List<EntityCodesResponse> entitylst = new List<EntityCodesResponse>();
		List<AccountCodesResponse> accountlst = new List<AccountCodesResponse>();


		EntityCodesResponse EntityCode;
		AccountCodesResponse AccountCode;
		UITextField selectedTextFeild;

		EntityPickerModel entityModel;
		AccountCodePickerModel accountModel;

		public CrmNotesResponse notes;
		public bool isEdit;

		string privacy = "public";

		public CreateNotesVC() : base("CreateNotesVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			GetEntityCodeList();
		}


		void ConfigureView()
		{
			SetupLanguageString();
			IosUtils.Utility.setBorderColor(IBNotesDetailsTxt);
			IosUtils.Utility.setcornerRadius(IBSaveBtn);
			IosUtils.Utility.setcornerRadius(IBCancelBtn);
			this.EdgesForExtendedLayout = UIRectEdge.None;

			ScrollVw.Delegate = this;
			this.NavigationItem.Title = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSNotesTitle", "");
			this.NavigationItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null, null);

			if (isEdit)
			{
				var createBtn = new UIBarButtonItem(UIImage.FromBundle("Delete"),
												  UIBarButtonItemStyle.Plain,
													DeleteClicked);
				this.NavigationItem.RightBarButtonItem = createBtn;
			}

			IBEntityTxt.InputView = IBEntityPicker;
			IBEntityTxt.InputAccessoryView = IBEntityDoneBar;

			IBAccountCodeTxt.InputView = IBAccountCodePicker;
			IBAccountCodeTxt.InputAccessoryView = IBAccountCodeDoneBar;
			IBPubicBtn.Selected = true;

			if (notes != null)
			{
				IBNotesHeaderTxt.Text = notes.NotesSubject;
				IBNotesDetailsTxt.Text = notes.NotesDetail;
				IBPubicBtn.Selected = notes.PrivacyId == PrivacyCode.Public.ToString();
				IBMeBtn.Selected = notes.PrivacyId == PrivacyCode.Me.ToString();

			}


		}

		void SetupLanguageString()
		{
			IBEntityCodeTiltleLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSEntityTitle", "");
			IBAccountCodeTitleLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSAccountTitle", "");
			IBNotesHeaderLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSNotesHeaderTitle", "");
			IBNotesDetailsLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSNotesDetailsTitle", "");

			IBMeBtn.SetTitle(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSMeTitle", ""),
							 UIControlState.Normal);
			IBPubicBtn.SetTitle(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSPublicTitle", ""),
							 UIControlState.Normal);
			IBSelectedBtn.SetTitle(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSSelectTitle", ""),
							 UIControlState.Normal);
			IBSaveBtn.SetTitle(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSSave", ""),
							 UIControlState.Normal);
			IBCancelBtn.SetTitle(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSCancelKey", ""),
							 UIControlState.Normal);


		}



		async void GetEntityCodeList()
		{
			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				try
				{
					var res = await WebServiceMethods.GetEntityCode();
					if (res != null)
					{
						InvokeOnMainThread(() =>
						{
							entitylst = res;
							entityModel = new EntityPickerModel(entitylst, IBEntityTxt, entitylst[0]);
							EntityCode = entitylst[0];
							IBEntityTxt.Text = entitylst[0].CompCode;
							IBEntityPicker.Model = entityModel;
						});
						GetAccountCodeList();
					}
					else
					{
						IosUtils.Utility.hideProgressHud();
						IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
														  IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSUnknownError", "LSErrorTitle"));
					}
				}
				catch (Exception e)
				{
					IosUtils.Utility.hideProgressHud();
					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   e.Message);
				}

			}

		}

		/// <summary>
		/// Gets the account code list.
		/// </summary>
		async void GetAccountCodeList()
		{

			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				try
				{
					var res = await WebServiceMethods.GetAccountCodes(EntityCode.CompCode);
					if (res != null)
					{
						InvokeOnMainThread(() =>
						{
							accountlst = res;
							AccountCode = accountlst[0];
							accountModel = new AccountCodePickerModel(accountlst, IBAccountCodeTxt, accountlst[0]);
							IBAccountCodePicker.Model = accountModel;
							IBAccountCodeTxt.Text = AccountCode.AccountCode;
						});
						IosUtils.Utility.hideProgressHud();
					}
					else
					{
						IosUtils.Utility.hideProgressHud();
						IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
														  IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSUnknownError", "LSErrorTitle"));
					}
				}
				catch (Exception e)
				{
					IosUtils.Utility.hideProgressHud();
					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"), e.Message);
				}

			}

		}

		async Task SaveNotes()
		{

			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				try
				{
					AddNotesAPIParams prams = new AddNotesAPIParams()
					{
						entityCode = EntityCode.CompCode,
						accountCode = AccountCode.AccountCode,
						accountId = AccountCode.AccountId,
						notesDetail = IBNotesDetailsTxt.Text,
						notesHeader = IBNotesHeaderTxt.Text,
						privacyId = privacy,
						connectionName = WebserviceConstants.CONNECTION_NAME,
						userId = Settings.UserId,
						notesId = notes != null ? notes.NotesId : "0",
						notesDetail_Add = "",
						sendTo = "",
						actionTypeId = ActionType.Default.ToString()
					};

					var res = await WebServiceMethods.AddCrmNotes(prams);
					IosUtils.Utility.hideProgressHud();
					if (res == 1)
					{
						this.NavigationController.PopViewController(true);
					}
					else
					{
						IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
														  IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSUnknownError", "LSErrorTitle"));
					}
				}
				catch (Exception e)
				{
					IosUtils.Utility.hideProgressHud();
					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   e.Message);
				}

			}

		}


		[Export("textFieldShouldBeginEditing:")]
		public bool ShouldBeginEditing(UITextField textField)
		{
			if (entitylst.Count > 0 && accountlst.Count > 0)
			{
				selectedTextFeild = textField;
				if (textField == IBAccountCodeTxt && string.IsNullOrEmpty(IBEntityTxt.Text))
				{
					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSEntityCodeEmpty", "LSErrorTitle"));
					return false;
				}
				else if (textField != IBEntityTxt && (string.IsNullOrEmpty(IBEntityTxt.Text) || string.IsNullOrEmpty(IBAccountCodeTxt.Text)))
				{
					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
														   IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSBlankMsg", "LSErrorTitle"));
					return false;
				}
			}
			else
			{
				IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSReloadMsg", "LSErrorTitle"));
				return false;
			}
			return true;
		}

		[Export("textFieldDidEndEditing:")]
		public void EditingEnded(UITextField textField)
		{
			EntityCode = entityModel.selectedModel;
			AccountCode = accountModel.selectedModel;
		}


		#region IBAction Methods

		async void DeleteClicked(object sender, EventArgs e)
		{
			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				try
				{
					if (isEdit && notes != null)
					{
						var res = await WebServiceMethods.DeleteCrmNotes(notes.NotesId);
						IosUtils.Utility.hideProgressHud();
						if (res)
						{
							this.NavigationController.PopViewController(true);
						}
						else
						{
							IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
															  IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSUnknownError", "LSErrorTitle"));
						}
					}
				}
				catch (Exception ex)
				{
					IosUtils.Utility.hideProgressHud();
					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   ex.Message);
				}
			}
		}

		partial void IBAccountDoneClicked(Foundation.NSObject sender)
		{
			AccountCode = accountModel.selectedModel;
			selectedTextFeild.EndEditing(true);
		}

		partial void IBEntityDoneClicked(Foundation.NSObject sender)
		{
			EntityCode = entityModel.selectedModel;
			GetAccountCodeList();
			selectedTextFeild.EndEditing(true);
		}


		partial void BtnCancelClicked(Foundation.NSObject sender)
		{
			this.NavigationController.PopViewController(true);
		}


		partial void BtnSaveClicked(Foundation.NSObject sender)
		{
			if (string.IsNullOrEmpty(IBEntityTxt.Text) ||
			   string.IsNullOrEmpty(IBAccountCodeTxt.Text) ||
				string.IsNullOrEmpty(IBNotesHeaderTxt.Text) ||
				string.IsNullOrEmpty(IBNotesDetailsTxt.Text)
			  )
			{
				IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSBlankMsg", "LSErrorTitle"));


			}
			else
			{
				SaveNotes();
			}

		}


		partial void IBRadioBtnClicked(Foundation.NSObject sender)
		{
			IBMeBtn.Selected = false;
			IBPubicBtn.Selected = false;
			if (sender == IBMeBtn)
			{
				privacy = PrivacyCode.Me.ToString();
			}
			else if (sender == IBPubicBtn)
			{
				privacy = PrivacyCode.Public.ToString();
			}
			((UIButton)sender).Selected = true;
		}

		#endregion



	}
}
