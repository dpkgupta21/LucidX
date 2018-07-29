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
	[Register ("AddOrderThird")]
	partial class AddOrderThird
	{
		[Outlet]
		UIKit.UIButton BtnCancel { get; set; }

		[Outlet]
		UIKit.UIButton BtnSave { get; set; }

<<<<<<< HEAD
=======
		[Outlet]
		UIKit.UILabel LblGross { get; set; }

		[Outlet]
		UIKit.UILabel LblNet { get; set; }

		[Outlet]
		UIKit.UILabel LblVat { get; set; }

		[Outlet]
		UIKit.UITextField TxtGross { get; set; }

		[Outlet]
		UIKit.UITextField TxtNet { get; set; }

		[Outlet]
		UIKit.UITextField txtVat { get; set; }

>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
		[Action ("BtnCancelClicked:")]
		partial void BtnCancelClicked (Foundation.NSObject sender);

		[Action ("BtnSaveClicked:")]
		partial void BtnSaveClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
<<<<<<< HEAD
			if (BtnSave != null) {
				BtnSave.Dispose ();
				BtnSave = null;
=======
			if (LblVat != null) {
				LblVat.Dispose ();
				LblVat = null;
			}

			if (txtVat != null) {
				txtVat.Dispose ();
				txtVat = null;
			}

			if (LblNet != null) {
				LblNet.Dispose ();
				LblNet = null;
			}

			if (TxtNet != null) {
				TxtNet.Dispose ();
				TxtNet = null;
			}

			if (LblGross != null) {
				LblGross.Dispose ();
				LblGross = null;
			}

			if (TxtGross != null) {
				TxtGross.Dispose ();
				TxtGross = null;
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
			}

			if (BtnCancel != null) {
				BtnCancel.Dispose ();
				BtnCancel = null;
			}
<<<<<<< HEAD
=======

			if (BtnSave != null) {
				BtnSave.Dispose ();
				BtnSave = null;
			}
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
		}
	}
}
