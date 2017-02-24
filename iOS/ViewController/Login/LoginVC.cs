using System;
using LucidX.RequestModels;
using UIKit;

namespace LucidX.iOS.ViewControllers
{
	public partial class LoginVC : UIViewController
	{
		UIGestureRecognizer tapGesture;

		public LoginVC() : base("LoginVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			tapGesture = new UITapGestureRecognizer((obj) => {
				this.View.EndEditing(true);
			});
			this.View.AddGestureRecognizer(tapGesture);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void SignInClicked(Foundation.NSObject sender)
		{
			Login();
		}

		async void Login()
		{
			ElucidateAPIParams loginParams = new ElucidateAPIParams
			{
				userID = IBUsernameTxt.Text,
				strPwd = IBPasswordTxt.Text,
				connectionName = IBLanguageTxt.Text
			};
			var a = await WebServiceMethods.Login(loginParams);
			object b = null;
		}

	}
}

