// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LucidX.iOS.ViewControllers
{
	[Register ("LoginVC")]
	partial class LoginVC
	{
		[Outlet]
		UIKit.UIView IBContentVw { get; set; }

		[Outlet]
		UIKit.UILabel IBCopyRightLbl { get; set; }

		[Outlet]
		UIKit.UIImageView IBLanguageImg { get; set; }

		[Outlet]
		UIKit.UILabel IBLanguageLbl { get; set; }

		[Outlet]
		UIKit.UITextField IBLanguageTxt { get; set; }

		[Outlet]
		UIKit.UIView IBLanguageVw { get; set; }

		[Outlet]
		UIKit.UIImageView IBLogoImg { get; set; }

		[Outlet]
		UIKit.UIView IBLogoVw { get; set; }

		[Outlet]
		UIKit.UIImageView IBPasswordImg { get; set; }

		[Outlet]
		UIKit.UILabel IBPasswordLbl { get; set; }

		[Outlet]
		UIKit.UITextField IBPasswordTxt { get; set; }

		[Outlet]
		UIKit.UIView IBPasswordVw { get; set; }

		[Outlet]
		UIKit.UIButton IBRemeberMeBtn { get; set; }

		[Outlet]
		UIKit.UIScrollView IBScrollVw { get; set; }

		[Outlet]
		UIKit.UIButton IBSignInBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBTitleLbl { get; set; }

		[Outlet]
		UIKit.UIImageView IBUserImg { get; set; }

		[Outlet]
		UIKit.UILabel IBUsernameLbl { get; set; }

		[Outlet]
		UIKit.UITextField IBUsernameTxt { get; set; }

		[Outlet]
		UIKit.UIView IBUsernameVw { get; set; }

		[Outlet]
		UIKit.UILabel IBVersinonLbl { get; set; }

		[Action ("IBRemembermeClicked:")]
		partial void IBRemembermeClicked (Foundation.NSObject sender);

		[Action ("SignInClicked:")]
		partial void SignInClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (IBRemeberMeBtn != null) {
				IBRemeberMeBtn.Dispose ();
				IBRemeberMeBtn = null;
			}

			if (IBContentVw != null) {
				IBContentVw.Dispose ();
				IBContentVw = null;
			}

			if (IBCopyRightLbl != null) {
				IBCopyRightLbl.Dispose ();
				IBCopyRightLbl = null;
			}

			if (IBLanguageImg != null) {
				IBLanguageImg.Dispose ();
				IBLanguageImg = null;
			}

			if (IBLanguageLbl != null) {
				IBLanguageLbl.Dispose ();
				IBLanguageLbl = null;
			}

			if (IBLanguageTxt != null) {
				IBLanguageTxt.Dispose ();
				IBLanguageTxt = null;
			}

			if (IBLanguageVw != null) {
				IBLanguageVw.Dispose ();
				IBLanguageVw = null;
			}

			if (IBLogoImg != null) {
				IBLogoImg.Dispose ();
				IBLogoImg = null;
			}

			if (IBLogoVw != null) {
				IBLogoVw.Dispose ();
				IBLogoVw = null;
			}

			if (IBPasswordImg != null) {
				IBPasswordImg.Dispose ();
				IBPasswordImg = null;
			}

			if (IBPasswordLbl != null) {
				IBPasswordLbl.Dispose ();
				IBPasswordLbl = null;
			}

			if (IBPasswordTxt != null) {
				IBPasswordTxt.Dispose ();
				IBPasswordTxt = null;
			}

			if (IBPasswordVw != null) {
				IBPasswordVw.Dispose ();
				IBPasswordVw = null;
			}

			if (IBScrollVw != null) {
				IBScrollVw.Dispose ();
				IBScrollVw = null;
			}

			if (IBSignInBtn != null) {
				IBSignInBtn.Dispose ();
				IBSignInBtn = null;
			}

			if (IBTitleLbl != null) {
				IBTitleLbl.Dispose ();
				IBTitleLbl = null;
			}

			if (IBUserImg != null) {
				IBUserImg.Dispose ();
				IBUserImg = null;
			}

			if (IBUsernameLbl != null) {
				IBUsernameLbl.Dispose ();
				IBUsernameLbl = null;
			}

			if (IBUsernameTxt != null) {
				IBUsernameTxt.Dispose ();
				IBUsernameTxt = null;
			}

			if (IBUsernameVw != null) {
				IBUsernameVw.Dispose ();
				IBUsernameVw = null;
			}

			if (IBVersinonLbl != null) {
				IBVersinonLbl.Dispose ();
				IBVersinonLbl = null;
			}
		}
	}
}
