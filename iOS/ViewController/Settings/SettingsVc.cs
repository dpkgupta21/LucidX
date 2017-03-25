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
		string Selected="Inbox";

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
			IBProfileImg.Layer.BorderWidth = 1;
			IBProfileImg.Layer.BorderColor = UIColor.White.CGColor;
			IBProfileImg.ClipsToBounds = true;
			SetupLanguageStrings();
			IBNameLbl.Text = IosUtils.Settings.Name;
			IBMailAddLbl.Text = IosUtils.Settings.UserMail;
			IBMailAddLbl.AdjustsFontSizeToFitWidth = true;
			SetSelected(IBInboxVw);
			GetCount();
		}

		async void GetCount() {
			var res = await Webservices.WebServiceMethods.EmailCount(IosUtils.Settings.UserId);
			IBInboxCountLbl.Text = res.inboxCount.ToString();
			IBSentCountLbl.Text = res.sentItemCount.ToString();
			IBDraftCountLbl.Text = res.draftCount.ToString();
			IBTrashCountLbl.Text = res.trashCount.ToString();
		}


		void SetupLanguageStrings()
		{
			IBMailTitleLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSMailTitle", "");
			IBInboxLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSInbox", "");
			IBDraftLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSDrafts", "");
			IBSentLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSSent", "");
			IBTrashLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSTrash", "");
			IBCalendarLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSCalendar", "");
			IBInvoiceLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSInvoice", "");
		}

		void SetSelected(UIView vw) {
			IBInboxVw.BackgroundColor = IBMailVw.BackgroundColor;
			IBSentVw.BackgroundColor = IBMailVw.BackgroundColor;
			IBDraftVw.BackgroundColor = IBMailVw.BackgroundColor;
			IBTrashVw.BackgroundColor = IBMailVw.BackgroundColor;
			IBCalendarVw.BackgroundColor = UIColor.Clear;
			IBInvoiceVw.BackgroundColor = UIColor.Clear;
			
			vw.BackgroundColor = IosUtils.IosColorConstant.ThemeNavBlue;
		}

		#endregion

		#region IBaction Methods

		partial void IBCalendarClicked(Foundation.NSObject sender)
		{
			var caledarvc = new Calendar.CalendarVC();
			caledarvc.revealVC = revealVC;
			var navVc = new UINavigationController(caledarvc);
			var fixitVw = new UIView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
			fixitVw.BackgroundColor = IosUtils.IosColorConstant.ThemeNavBlue;
			navVc.View.AddSubview(fixitVw);
			revealVC.FrontViewController = navVc;
			SetSelected(IBCalendarVw);
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBDraftClicked(Foundation.NSObject sender)
		{
			var draftvc = new Drafts.DraftsVC();
			draftvc.revealVC = revealVC;
			var navVc = new UINavigationController(draftvc);
			var fixitVw = new UIView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
			fixitVw.BackgroundColor = IosUtils.IosColorConstant.ThemeNavBlue;
			navVc.View.AddSubview(fixitVw);
			revealVC.FrontViewController = navVc;
			SetSelected(IBDraftVw);
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBInboxClicked(Foundation.NSObject sender)
		{
			var inboxVc = new Inbox.InboxVC();
			inboxVc.revealVC = revealVC;
			var navVc = new UINavigationController(inboxVc);
			var fixitVw = new UIView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
			fixitVw.BackgroundColor = IosUtils.IosColorConstant.ThemeNavBlue;
			navVc.View.AddSubview(fixitVw);
			revealVC.FrontViewController = navVc;
			SetSelected(IBInboxVw);
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBInvoiceClicked(Foundation.NSObject sender)
		{
			var invoiceVc = new Invoice.InvoiceVC();
			invoiceVc.revealVC = revealVC;
			var navVc = new UINavigationController(invoiceVc);
			var fixitVw = new UIView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
			fixitVw.BackgroundColor = IosUtils.IosColorConstant.ThemeNavBlue;
			navVc.View.AddSubview(fixitVw);
			revealVC.FrontViewController = navVc;
			SetSelected(IBInvoiceVw);
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBSentClicked(Foundation.NSObject sender)
		{
			var sentVC = new Sent.SentVC();
			sentVC.revealVC = revealVC;
			var navVc = new UINavigationController(sentVC);
			var fixitVw = new UIView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
			fixitVw.BackgroundColor = IosUtils.IosColorConstant.ThemeNavBlue;
			navVc.View.AddSubview(fixitVw);
			revealVC.FrontViewController = navVc;
			SetSelected(IBSentVw);
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBTrashClicked(Foundation.NSObject sender)
		{
			var trashVc = new Trash.TrashVC();
			trashVc.revealVC = revealVC;
			var navVc = new UINavigationController(trashVc);
			var fixitVw = new UIView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
			fixitVw.BackgroundColor = IosUtils.IosColorConstant.ThemeNavBlue;
			navVc.View.AddSubview(fixitVw);
			revealVC.FrontViewController = navVc;
			SetSelected(IBTrashVw);
			revealVC.RevealToggleAnimated(true);
		}

		#endregion

	}
}

