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
	[Register ("NotesCell")]
	partial class NotesCell
	{
		[Outlet]
		UIKit.UILabel IBDateLbl { get; set; }

		[Outlet]
		UIKit.UIButton IBEditBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBNameLbl { get; set; }

		[Outlet]
		UIKit.UIButton IBViewBtn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (IBDateLbl != null) {
				IBDateLbl.Dispose ();
				IBDateLbl = null;
			}

			if (IBNameLbl != null) {
				IBNameLbl.Dispose ();
				IBNameLbl = null;
			}

			if (IBViewBtn != null) {
				IBViewBtn.Dispose ();
				IBViewBtn = null;
			}

			if (IBEditBtn != null) {
				IBEditBtn.Dispose ();
				IBEditBtn = null;
			}
		}
	}
}
