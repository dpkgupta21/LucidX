// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LucidX.iOS.CustomCells
{
	[Register ("MenuCell")]
	partial class MenuCell
	{
		[Outlet]
		UIKit.UIView IBBackVw { get; set; }

		[Outlet]
		UIKit.UILabel IBCountLbl { get; set; }

		[Outlet]
		UIKit.UIImageView IBIconCell { get; set; }

		[Outlet]
		UIKit.UILabel IBTitleLbl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (IBCountLbl != null) {
				IBCountLbl.Dispose ();
				IBCountLbl = null;
			}

			if (IBIconCell != null) {
				IBIconCell.Dispose ();
				IBIconCell = null;
			}

			if (IBTitleLbl != null) {
				IBTitleLbl.Dispose ();
				IBTitleLbl = null;
			}

			if (IBBackVw != null) {
				IBBackVw.Dispose ();
				IBBackVw = null;
			}
		}
	}
}
