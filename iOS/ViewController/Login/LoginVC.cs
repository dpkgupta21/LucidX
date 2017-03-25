using System;
using System.Collections.Generic;
using Foundation;
using LucidX.RequestModels;
using LucidX.Webservices;
using UIKit;

namespace LucidX.iOS
{
	public partial class LoginVC : UIViewController, IUITextFieldDelegate
	{
		UIGestureRecognizer tapGesture;

		List<string> languages = new List<string>() { "English", "French" };

		#region Life Cycle methods

		public LoginVC() : base("LoginVC", null)
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
		#endregion

		#region Helper Methods

		void ConfigureView()
		{
			SetupLanguageString();
			var model = new PickerModel(languages, IBLanguageTxt);
			IBLanguagePicker.Model = model;
			IBLanguageTxt.InputView = IBLanguagePicker;
			IBLanguageTxt.InputAccessoryView = IBDoneBar;
			IBLanguageTxt.Text = IosUtils.Settings.CurrentLanguage == "fr" ? "French" : "English";
			if (IosUtils.Settings.IsRememberMeSelected)
			{
				IBUsernameTxt.Text = IosUtils.Settings.UserName;
				IBPasswordTxt.Text = IosUtils.Settings.Password;
				IBRemeberMeBtn.Selected = IosUtils.Settings.IsRememberMeSelected;
			}

		}

		void SetupLanguageString()
		{
			IBUsernameLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSUsername", "");
			IBPasswordLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSPassword", "");
			IBLanguageLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSLanguage", "");
			IBRemeberMeBtn.SetTitle(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSRememberMe", ""), UIControlState.Normal);
			IBSignInBtn.SetTitle(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSLogin", ""), UIControlState.Normal);
			IBCopyRightLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSCopyRightTxt", "");
			IBTitleLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSCompanyTitle", "");
			IBVersinonLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSVersionInfo", "");
			IBDoneBtn.Title = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSDone", "");

		}

		async void Login()
		{
			if (IBRemeberMeBtn.Selected)
			{
				IosUtils.Settings.IsRememberMeSelected = true;
				IosUtils.Settings.UserName = IBUsernameTxt.Text;
				IosUtils.Settings.Password = IBPasswordTxt.Text;
			}
			else
			{
				IosUtils.Settings.RemoveLoginInfo();
			}
			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				var loginResponse = await WebServiceMethods.Login(IBUsernameTxt.Text, IBPasswordTxt.Text);
				IosUtils.Utility.hideProgressHud();
				if (loginResponse != null)
				{
					if (loginResponse.IsAuthenticate)
					{
						IosUtils.Settings.UserId = loginResponse.UserId;
						IosUtils.Settings.IsLogedin = true;
						IosUtils.Settings.Name = loginResponse.Name;
						IosUtils.Settings.UserMail = loginResponse.UserEmail;
						AppDelegate.GetSharedInstance().showHomeScreen();
					}
					else
					{
						IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", ""),
														  IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSInvalidCredentialError", ""));

					}
				}
				else
				{
					//AppDelegate.GetSharedInstance().showHomeScreen();

					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", ""),
														  IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSInvalidCredentialError", ""));

				}
			}
		}

		void Validate()
		{

			bool result = true;
			string msg = "";
			if (string.IsNullOrEmpty(IBUsernameTxt.Text))
			{
				result = false;
				msg = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSBlankUsername", "");
			}
			else if (string.IsNullOrEmpty(IBPasswordTxt.Text))
			{

				result = false;
				msg = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSBlankPassword", "");
			}
			if (result)
			{
				Login();
			}
			else
			{
				IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "")
												   , msg);
			}
		}

		#endregion

		[Export("textFieldShouldBeginEditing:")]
		public bool ShouldBeginEditing(UITextField textField)
		{

			IosUtils.Utility.scrollViewToCenterOfScreen(IBScrollVw, textField.Superview.Superview);
			return true;
		}

		[Export("textFieldShouldReturn:")]
		public bool ShouldReturn(UITextField textField)
		{
			IosUtils.Utility.scrollViewToZero(IBScrollVw);
			textField.EndEditing(true);
			return true;
		}

		#region IBAction methods

		partial void SignInClicked(Foundation.NSObject sender)
		{
			Validate();
		}


		partial void IBRemembermeClicked(Foundation.NSObject sender)
		{
			IBRemeberMeBtn.Selected = !IBRemeberMeBtn.Selected;
		}

		partial void IBDoneClicked(Foundation.NSObject sender)
		{
			if (IBLanguageTxt.Text == "French")
			{
				IosUtils.Settings.CurrentLanguage = "fr";
			}
			else
			{
				IosUtils.Settings.CurrentLanguage = "en";

			}
			SetupLanguageString();
			IosUtils.Utility.scrollViewToZero(IBScrollVw);
			IBLanguageTxt.EndEditing(true);
		}

		#endregion
	}
}

