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
	[Register ("HomeVC")]
	partial class HomeVC
	{
		[Outlet]
		UIKit.UIButton IBCancelBtn { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint IBCancelWidth { get; set; }

		[Outlet]
		UIKit.UITableView IBContntTbl { get; set; }

		[Outlet]
		UIKit.UISearchBar IBSearchBar { get; set; }

		[Action ("IBCancelClicked:")]
		partial void IBCancelClicked (Foundation.NSObject sender);

		[Action ("IBSendAlertClicked:")]
		partial void IBSendAlertClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (IBCancelBtn != null) {
				IBCancelBtn.Dispose ();
				IBCancelBtn = null;
			}

			if (IBCancelWidth != null) {
				IBCancelWidth.Dispose ();
				IBCancelWidth = null;
			}

			if (IBContntTbl != null) {
				IBContntTbl.Dispose ();
				IBContntTbl = null;
			}

			if (IBSearchBar != null) {
				IBSearchBar.Dispose ();
				IBSearchBar = null;
			}
		}
	}
}
