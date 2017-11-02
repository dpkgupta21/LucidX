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

		[Action ("BtnCancelClicked:")]
		partial void BtnCancelClicked (Foundation.NSObject sender);

		[Action ("BtnSaveClicked:")]
		partial void BtnSaveClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnSave != null) {
				BtnSave.Dispose ();
				BtnSave = null;
			}

			if (BtnCancel != null) {
				BtnCancel.Dispose ();
				BtnCancel = null;
			}
		}
	}
}
