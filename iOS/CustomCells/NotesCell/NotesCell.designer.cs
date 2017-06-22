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
		UIKit.UILabel IBDateTimeLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBDescLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBNotesTitleLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBTitleLbl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (IBDateTimeLbl != null) {
				IBDateTimeLbl.Dispose ();
				IBDateTimeLbl = null;
			}

			if (IBDescLbl != null) {
				IBDescLbl.Dispose ();
				IBDescLbl = null;
			}

			if (IBNotesTitleLbl != null) {
				IBNotesTitleLbl.Dispose ();
				IBNotesTitleLbl = null;
			}

			if (IBTitleLbl != null) {
				IBTitleLbl.Dispose ();
				IBTitleLbl = null;
			}
		}
	}
}
