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
		UIKit.UIView ContentVw { get; set; }

		[Outlet]
		UIKit.UILabel LblPageCount { get; set; }

		[Action ("BtnNextClicked:")]
		partial void BtnNextClicked (Foundation.NSObject sender);

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
		}
	}
}
