using System;
using LucidX.RequestModels;
using UIKit;

namespace LucidX.iOS.ViewControllers
{
	public partial class LoginVC : UIViewController
	{
		public LoginVC() : base("LoginVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
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
				userID = "jmathews@elucidate-software.com",
				strPwd = "jeneby",
				connectionName = "DEMOConneection"
			};
			var a = await WebServiceMethods.Login(loginParams);
			object b = null;
		}

	}
}

