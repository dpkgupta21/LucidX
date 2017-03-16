// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CustomCells
{
	[Register ("MailDetailsCell")]
	partial class MailDetailsCell
	{
		[Outlet]
		UIKit.UILabel IBDateTimeLbl { get; set; }

		[Outlet]
		UIKit.UIButton IBDeleteBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBDescLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBMailAddressLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBTitleLbl { get; set; }

		[Action ("IBDeleteBtnClicked:")]
		partial void IBDeleteBtnClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (IBTitleLbl != null) {
				IBTitleLbl.Dispose ();
				IBTitleLbl = null;
			}

			if (IBMailAddressLbl != null) {
				IBMailAddressLbl.Dispose ();
				IBMailAddressLbl = null;
			}

			if (IBDescLbl != null) {
				IBDescLbl.Dispose ();
				IBDescLbl = null;
			}

			if (IBDateTimeLbl != null) {
				IBDateTimeLbl.Dispose ();
				IBDateTimeLbl = null;
			}

			if (IBDeleteBtn != null) {
				IBDeleteBtn.Dispose ();
				IBDeleteBtn = null;
			}
		}
	}
}
