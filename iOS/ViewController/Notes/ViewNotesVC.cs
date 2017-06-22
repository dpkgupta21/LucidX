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

namespace LucidX.iOS.Notes
{
	public partial class ViewNotesVC : UIViewController, IUITabBarDelegate, IUITableViewDataSource, IUITextFieldDelegate
	{

		public SWRevealViewController revealVC;

		List<CrmNotesResponse> notes = new List<CrmNotesResponse>();
		List<EntityCodesResponse> entitylst = new List<EntityCodesResponse>();
		List<AccountCodesResponse> accountlst = new List<AccountCodesResponse>();


		EntityCodesResponse EntityCode;
		AccountCodesResponse AccountCode;
		UITextField selectedTextFeild;

		EntityPickerModel entityModel;
		AccountCodePickerModel accountModel;

		DateTime StartDate;
		DateTime EndDate;

		bool isfirstTime;

		public ViewNotesVC() : base("ViewNotesVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			isfirstTime = true;
			GetEntityCodeList();
		}


		#region helping Methods

		async void GetNotes()
		{
			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				try
				{
					var res = await WebServiceMethods.ShowNotes(EntityCode.CompCode, AccountCode.AccountCode, IBFromDateTxt.Text, IBToDateTxt.Text);
					InvokeOnMainThread(() =>
						{
							if (res != null)
							{
								notes = res;
								if (notes.Count == 0)
								{
									IBEmptyLbl.Hidden = false;
								}
								else
								{
									IBEmptyLbl.Hidden = true;
								}
							}
							else
							{
								IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
																	  IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSUnknownError", "LSErrorTitle"));
							}
							IBNotesTbl.ReloadData();
						});
				}
				catch (Exception e)
				{
					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"), e.Message);

				}
				IosUtils.Utility.hideProgressHud();
			}
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
						//IosUtils.Utility.hideProgressHud();
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
						SetDateTime();
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

		void SetDateTime()
		{
			DateTime now = DateTime.Now;
			StartDate = new DateTime(now.Year, now.Month, 1);
			EndDate = StartDate.AddMonths(1).AddDays(-1);
			IBToDateTxt.Text = EndDate.ToString("d");
			IBFromDateTxt.Text = StartDate.ToString("d");
			if (isfirstTime)
			{
				GetNotes();
			}
		}

		/// <summary>
		/// Configures the view.
		/// </summary>
		void ConfigureView()
		{
			this.EdgesForExtendedLayout = UIRectEdge.None;
			this.NavigationItem.Title = "";
			var menuBtn = new UIBarButtonItem(UIImage.FromBundle("Menu"),
											  UIBarButtonItemStyle.Plain,
											  MenuClicked);
			this.NavigationItem.LeftBarButtonItem = menuBtn;

			IBNotesTbl.RegisterNibForCellReuse(NotesCell.Nib, NotesCell.Key);
			IBNotesTbl.TableFooterView = new UIView();
			IBNotesTbl.EstimatedRowHeight = HeightConstants.CellHeight70;
			this.NavigationItem.Title = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSNotesTitle","");
			this.NavigationItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null, null);

			var createBtn = new UIBarButtonItem(UIImage.FromBundle("Edit"),
											  UIBarButtonItemStyle.Plain,
												EditClicked);
			this.NavigationItem.RightBarButtonItem = createBtn;

			//IosUtils.Utility.setLeftPadding(IBEntityTxt);
			//IosUtils.Utility.setLeftPadding(IBAccountCodeTxt);
			//IosUtils.Utility.setLeftPadding(IBFromDateTxt);
			//IosUtils.Utility.setLeftPadding(IBToDateTxt);

			IBEntityTxt.InputView = IBEntityPicker;
			IBEntityTxt.InputAccessoryView = IBEntityDoneBar;

			IBAccountCodeTxt.InputView = IBAccountCodePicker;
			IBAccountCodeTxt.InputAccessoryView = IBAccountCodeDoneBar;

			IBDateTimePicker.Mode = UIDatePickerMode.Date;
			IBFromDateTxt.InputView = IBDateTimePicker;
			IBFromDateTxt.InputAccessoryView = IBDateTimeDoneBar;
			IBToDateTxt.InputView = IBDateTimePicker;
			IBToDateTxt.InputAccessoryView = IBDateTimeDoneBar;
			SetupLanguageString();
		}

		void SetupLanguageString()
		{
			IBToLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSToTitle", "");
			IBEntityCodeTiltleLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSEntityTitle", "");
			IBAccountCodeTitleLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSAccountTitle", "");
			IBEmptyLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSNoNotes", "");
		}

		#endregion

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
				else if (textField == IBFromDateTxt && string.IsNullOrEmpty(IBAccountCodeTxt.Text))
				{
					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSAccountCodeEmpty", "LSErrorTitle"));
					return false;
				}
				else if (textField == IBFromDateTxt)
				{
					IBDateTimePicker.Date = IosUtils.Utility.ConvertToNSDate(StartDate);
					IBDateTimePicker.MinimumDate = NSDate.DistantPast; //IosUtils.Utility.ConvertToNSDate(new DateTime(2001, 1, 1, 0, 0, 0));
				}
				else if (textField == IBToDateTxt && string.IsNullOrEmpty(IBFromDateTxt.Text))
				{

					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSFromDateEmpty", "LSErrorTitle"));
					return false;
				}
				else if (textField == IBToDateTxt) { 
					IBDateTimePicker.Date = IosUtils.Utility.ConvertToNSDate(EndDate);
					IBDateTimePicker.MinimumDate = IosUtils.Utility.ConvertToNSDate(StartDate);
				
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

		#region IBAction Methods

		void MenuClicked(object sender, EventArgs e)
		{
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBSearchBtnClicked(Foundation.NSObject sender)
		{
			if (string.IsNullOrEmpty(IBEntityTxt.Text) ||
			   string.IsNullOrEmpty(IBAccountCodeTxt.Text) ||
			   string.IsNullOrEmpty(IBFromDateTxt.Text) ||
			   string.IsNullOrEmpty(IBToDateTxt.Text)
			  )
			{
				IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSBlankMsg", "LSErrorTitle"));


			}
			else
			{
				GetNotes();
			}

		}

		void EditClicked(object sender, EventArgs e)
		{
			var createNotesVc = new CreateNotesVC();
			this.NavigationController.PushViewController(createNotesVc, true);
		}

		partial void IBAccountDoneClicked(Foundation.NSObject sender)
		{
			AccountCode = accountModel.selectedModel;
			selectedTextFeild.EndEditing(true);
			GetNotes();

		}

		partial void IBDateTimeDoneClicked(Foundation.NSObject sender)
		{
			selectedTextFeild.Text = IosUtils.Utility.ConvertToDateTime(IBDateTimePicker.Date).ToString("d");
			if (selectedTextFeild == IBFromDateTxt)
			{
				StartDate = IosUtils.Utility.ConvertToDateTime(IBDateTimePicker.Date);
			}
			else
			{
				EndDate = IosUtils.Utility.ConvertToDateTime(IBDateTimePicker.Date);
			}
			selectedTextFeild.EndEditing(true);
		}

		partial void IBEntityDoneClicked(Foundation.NSObject sender)
		{
			EntityCode = entityModel.selectedModel;
			GetAccountCodeList();
			selectedTextFeild.EndEditing(true);

		}

		#endregion


		#region Tableview delegate and database methods

		[Export("numberOfSectionsInTableView:")]
		public nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public nint RowsInSection(UITableView tableView, nint section)
		{
			return notes.Count;
		}

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(NotesCell.Key) as NotesCell;
			cell.ConfigureCell(notes[indexPath.Row]);
			return cell;
		}
		[Export("tableView:heightForRowAtIndexPath:")]
		public nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return UITableView.AutomaticDimension;
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			if (IosUtils.Utility.IsReachable())
			{
				//notes[indexPath.Row].Unread = false;
				//markRead(notes[indexPath.Row].MailId);
				//IBContntTbl.ReloadData();
				//var detailsVC = new MailDetails.MailDetailsVC();
				//detailsVC.mail = notes[indexPath.Row];
				//this.NavigationController.PushViewController(detailsVC, true);
			}
		}


		#endregion




	}
}

