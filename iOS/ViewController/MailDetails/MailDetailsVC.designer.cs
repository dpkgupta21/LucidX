// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MailDetails
{
	[Register ("MailDetailsVC")]
	partial class MailDetailsVC
	{
		[Outlet]
		UIKit.UIButton IBBtmReplyBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBBtmReplyLbl { get; set; }

		[Outlet]
		UIKit.UITextView IBContnTxt { get; set; }

		[Outlet]
		UIKit.UIButton IBForwardBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBForwardLbl { get; set; }

		[Outlet]
		UIKit.UIButton IBInboxbtn { get; set; }

		[Outlet]
		UIKit.UIButton IBMenuBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBNameIconLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBNameLbl { get; set; }

		[Outlet]
		UIKit.UIButton IBReplyAllBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBReplyAllLbl { get; set; }

		[Outlet]
		UIKit.UIButton IBReplyBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBSubjectLbl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (IBSubjectLbl != null) {
				IBSubjectLbl.Dispose ();
				IBSubjectLbl = null;
			}

			if (IBInboxbtn != null) {
				IBInboxbtn.Dispose ();
				IBInboxbtn = null;
			}

			if (IBNameIconLbl != null) {
				IBNameIconLbl.Dispose ();
				IBNameIconLbl = null;
			}

			if (IBNameLbl != null) {
				IBNameLbl.Dispose ();
				IBNameLbl = null;
			}

			if (IBMenuBtn != null) {
				IBMenuBtn.Dispose ();
				IBMenuBtn = null;
			}

			if (IBReplyBtn != null) {
				IBReplyBtn.Dispose ();
				IBReplyBtn = null;
			}

			if (IBContnTxt != null) {
				IBContnTxt.Dispose ();
				IBContnTxt = null;
			}

			if (IBForwardBtn != null) {
				IBForwardBtn.Dispose ();
				IBForwardBtn = null;
			}

			if (IBReplyAllBtn != null) {
				IBReplyAllBtn.Dispose ();
				IBReplyAllBtn = null;
			}

			if (IBBtmReplyBtn != null) {
				IBBtmReplyBtn.Dispose ();
				IBBtmReplyBtn = null;
			}

			if (IBForwardLbl != null) {
				IBForwardLbl.Dispose ();
				IBForwardLbl = null;
			}

			if (IBReplyAllLbl != null) {
				IBReplyAllLbl.Dispose ();
				IBReplyAllLbl = null;
			}

			if (IBBtmReplyLbl != null) {
				IBBtmReplyLbl.Dispose ();
				IBBtmReplyLbl = null;
			}
		}
	}
}
