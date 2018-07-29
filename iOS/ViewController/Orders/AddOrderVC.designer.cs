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
	[Register ("AddOrderVC")]
	partial class AddOrderVC
	{
		[Outlet]
<<<<<<< HEAD
=======
		UIKit.UIButton BtnPre { get; set; }

		[Outlet]
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
		UIKit.UIView ContentVw { get; set; }

		[Outlet]
		UIKit.UILabel LblPageCount { get; set; }

<<<<<<< HEAD
		[Action ("BtnNextClicked:")]
		partial void BtnNextClicked (Foundation.NSObject sender);

=======
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
		[Action ("BtnPreClicked:")]
		partial void BtnPreClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ContentVw != null) {
				ContentVw.Dispose ();
				ContentVw = null;
			}

			if (LblPageCount != null) {
				LblPageCount.Dispose ();
				LblPageCount = null;
			}
<<<<<<< HEAD
=======

			if (BtnPre != null) {
				BtnPre.Dispose ();
				BtnPre = null;
			}
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
		}
	}
}
