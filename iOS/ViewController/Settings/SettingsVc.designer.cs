// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LucidX.iOS
{
	[Register ("SettingsVc")]
	partial class SettingsVc
	{
		[Outlet]
		UIKit.UITableView IBContntTbl { get; set; }

		[Outlet]
		UIKit.UILabel IBMailAddLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBNameLbl { get; set; }

		[Outlet]
		UIKit.UIImageView IBProfileImg { get; set; }

		[Outlet]
		UIKit.UIView IBProfileVw { get; set; }

		[Action ("CloseBtnClicked:")]
		partial void CloseBtnClicked (Foundation.NSObject sender);

		[Action ("IBCalendarClicked:")]
		partial void IBCalendarClicked (Foundation.NSObject sender);

		[Action ("IBDraftClicked:")]
		partial void IBDraftClicked (Foundation.NSObject sender);

		[Action ("IBInboxClicked:")]
		partial void IBInboxClicked (Foundation.NSObject sender);

		[Action ("IBInvoiceClicked:")]
		partial void IBInvoiceClicked (Foundation.NSObject sender);

		[Action ("IBSentClicked:")]
		partial void IBSentClicked (Foundation.NSObject sender);

		[Action ("IBTrashClicked:")]
		partial void IBTrashClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (IBMailAddLbl != null) {
				IBMailAddLbl.Dispose ();
				IBMailAddLbl = null;
			}

			if (IBNameLbl != null) {
				IBNameLbl.Dispose ();
				IBNameLbl = null;
			}

			if (IBProfileImg != null) {
				IBProfileImg.Dispose ();
				IBProfileImg = null;
			}

			if (IBProfileVw != null) {
				IBProfileVw.Dispose ();
				IBProfileVw = null;
			}

			if (IBContntTbl != null) {
				IBContntTbl.Dispose ();
				IBContntTbl = null;
			}
		}
	}
}
