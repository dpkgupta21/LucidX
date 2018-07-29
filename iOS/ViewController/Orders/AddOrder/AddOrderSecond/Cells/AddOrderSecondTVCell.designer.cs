// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

<<<<<<< HEAD
namespace LucidX.iOS.ViewController.Orders.AddOrder.AddOrderSecond.Cells
=======
namespace LucidX.iOS
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
{
	[Register ("AddOrderSecondTVCell")]
	partial class AddOrderSecondTVCell
	{
		[Outlet]
		UIKit.UIButton BtnDelete { get; set; }

		[Outlet]
		UIKit.UIButton BtnEdit { get; set; }

		[Outlet]
		UIKit.UILabel LblAccountNameTilte { get; set; }

		[Outlet]
		UIKit.UILabel LblAccountNameValue { get; set; }

		[Outlet]
		UIKit.UILabel LblBaseAmountTitle { get; set; }

		[Outlet]
		UIKit.UILabel LblBaseAmountValue { get; set; }

		[Outlet]
		UIKit.UILabel LblItemTitle { get; set; }

		[Outlet]
		UIKit.UILabel LblTaxTitle { get; set; }

		[Outlet]
		UIKit.UILabel LblTaxValue { get; set; }

		[Action ("BtndeleteClicked:")]
		partial void BtndeleteClicked (Foundation.NSObject sender);

		[Action ("BtnEditClicked:")]
		partial void BtnEditClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (LblAccountNameTilte != null) {
				LblAccountNameTilte.Dispose ();
				LblAccountNameTilte = null;
			}

			if (LblAccountNameValue != null) {
				LblAccountNameValue.Dispose ();
				LblAccountNameValue = null;
			}

			if (LblBaseAmountTitle != null) {
				LblBaseAmountTitle.Dispose ();
				LblBaseAmountTitle = null;
			}

			if (LblBaseAmountValue != null) {
				LblBaseAmountValue.Dispose ();
				LblBaseAmountValue = null;
			}

			if (LblTaxTitle != null) {
				LblTaxTitle.Dispose ();
				LblTaxTitle = null;
			}

			if (LblTaxValue != null) {
				LblTaxValue.Dispose ();
				LblTaxValue = null;
			}

			if (LblItemTitle != null) {
				LblItemTitle.Dispose ();
				LblItemTitle = null;
			}

			if (BtnEdit != null) {
				BtnEdit.Dispose ();
				BtnEdit = null;
			}

			if (BtnDelete != null) {
				BtnDelete.Dispose ();
				BtnDelete = null;
			}
		}
	}
}
