// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LucidX.iOS.OrderCell
{
	[Register ("OrderListCell")]
	partial class OrderListCell
	{
		[Outlet]
		UIKit.UILabel IBCostTitleLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBCostValueLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBDateLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBNameLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBTitleLbl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (IBNameLbl != null) {
				IBNameLbl.Dispose ();
				IBNameLbl = null;
			}

			if (IBDateLbl != null) {
				IBDateLbl.Dispose ();
				IBDateLbl = null;
			}

			if (IBTitleLbl != null) {
				IBTitleLbl.Dispose ();
				IBTitleLbl = null;
			}

			if (IBCostTitleLbl != null) {
				IBCostTitleLbl.Dispose ();
				IBCostTitleLbl = null;
			}

			if (IBCostValueLbl != null) {
				IBCostValueLbl.Dispose ();
				IBCostValueLbl = null;
			}
		}
	}
}
