using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.SWRevealViewController;

namespace LucidX.iOS
{
	public partial class SettingsVc : UIViewController
	{
		List<String> menu = new List<string>();

		public SWRevealViewController revealVC;

		public SettingsVc() : base("SettingsVc", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			configureView();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		#region HelperMethods

		void configureView()
		{
			IBProfileImg.Layer.CornerRadius = IBProfileImg.Frame.Width / 2;
			IBTrashVw.Layer.ShadowColor = UIColor.FromRGBA(0, 0, 0, 0.5f).CGColor;
			IBTrashVw.Layer.ShadowOffset = new CGSize(0,2);
			IBTrashVw.Layer.MasksToBounds = false;
			SetupLanguageStrings();
		}

		void SetupLanguageStrings()
		{
			IBMailTitleLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSMailTitle", "");
			IBInboxLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSInbox", "");
			IBDraftLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSDrafts", "");
			IBSentLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSSent", "");
			IBTrashLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSTrash", "");
			IBCalendarLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSCalendra", "");
			IBInvoiceLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSInvoice", "");
		}


		#endregion

		#region IBaction Methods

		partial void IBCalendarClicked(Foundation.NSObject sender)
		{
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBDraftClicked(Foundation.NSObject sender)
		{
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBInboxClicked(Foundation.NSObject sender)
		{
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBInvoiceClicked(Foundation.NSObject sender)
		{
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBSentClicked(Foundation.NSObject sender)
		{
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBTrashClicked(Foundation.NSObject sender)
		{
			revealVC.RevealToggleAnimated(true);
		}

		#endregion

	}
}

