// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WSI_NintaBlackBoxAlert_App.iOS
{
	[Register ("SettingsVc")]
	partial class SettingsVc
	{
		[Outlet]
		UIKit.UIImageView IBBackGroundImg { get; set; }

		[Outlet]
		UIKit.UIButton IBCalendarBtn { get; set; }

		[Outlet]
		UIKit.UIImageView IBCalendarIconImg { get; set; }

		[Outlet]
		UIKit.UILabel IBCalendarLbl { get; set; }

		[Outlet]
		UIKit.UIView IBCalendarVw { get; set; }

		[Outlet]
		UIKit.UIButton IBDraftBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBDraftCountLbl { get; set; }

		[Outlet]
		UIKit.UIImageView IBDraftIconImg { get; set; }

		[Outlet]
		UIKit.UILabel IBDraftLbl { get; set; }

		[Outlet]
		UIKit.UIView IBDraftVw { get; set; }

		[Outlet]
		UIKit.UIImageView IBDropImg { get; set; }

		[Outlet]
		UIKit.UIButton IBInboxBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBInboxCountLbl { get; set; }

		[Outlet]
		UIKit.UIImageView IBInboxIconImg { get; set; }

		[Outlet]
		UIKit.UILabel IBInboxLbl { get; set; }

		[Outlet]
		UIKit.UIView IBInboxVw { get; set; }

		[Outlet]
		UIKit.UIButton IBInvoiceBtn { get; set; }

		[Outlet]
		UIKit.UIImageView IBInvoiceIconImg { get; set; }

		[Outlet]
		UIKit.UILabel IBInvoiceLbl { get; set; }

		[Outlet]
		UIKit.UIView IBInvoiceVw { get; set; }

		[Outlet]
		UIKit.UILabel IBMailAddLbl { get; set; }

		[Outlet]
		UIKit.UILabel IBMailTitleLbl { get; set; }

		[Outlet]
		UIKit.UIView IBMailVw { get; set; }

		[Outlet]
		UIKit.UILabel IBNameLbl { get; set; }

		[Outlet]
		UIKit.UIImageView IBProfileImg { get; set; }

		[Outlet]
		UIKit.UIView IBProfileVw { get; set; }

		[Outlet]
		UIKit.UIButton IBSentBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBSentCountLbl { get; set; }

		[Outlet]
		UIKit.UIImageView IBSentIconImg { get; set; }

		[Outlet]
		UIKit.UILabel IBSentLbl { get; set; }

		[Outlet]
		UIKit.UIView IBSentVw { get; set; }

		[Outlet]
		UIKit.UIButton IBTrashBtn { get; set; }

		[Outlet]
		UIKit.UILabel IBTrashCountLbl { get; set; }

		[Outlet]
		UIKit.UIImageView IBTrashIconImg { get; set; }

		[Outlet]
		UIKit.UILabel IBTrashLbl { get; set; }

		[Outlet]
		UIKit.UIView IBTrashVw { get; set; }

		[Action ("CloseBtnClicked:")]
		partial void CloseBtnClicked (Foundation.NSObject sender);

		[Action ("IBCalendarClicked:")]
		partial void IBCalendarClicked (Foundation.NSObject sender);

		[Action ("IBDraftClicked:")]
		partial void IBDraftClicked (Foundation.NSObject sender);

		[Action ("IBInboxClicked:")]
		partial void IBInboxClicked (Foundation.NSObject sender);

		[Action ("IBInvoiceClicked:")]
		partial void IBInvoiceClicked (Foundation.NSObject sender);

		[Action ("IBSentClicked:")]
		partial void IBSentClicked (Foundation.NSObject sender);

		[Action ("IBTrashClicked:")]
		partial void IBTrashClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (IBBackGroundImg != null) {
				IBBackGroundImg.Dispose ();
				IBBackGroundImg = null;
			}

			if (IBProfileVw != null) {
				IBProfileVw.Dispose ();
				IBProfileVw = null;
			}

			if (IBProfileImg != null) {
				IBProfileImg.Dispose ();
				IBProfileImg = null;
			}

			if (IBNameLbl != null) {
				IBNameLbl.Dispose ();
				IBNameLbl = null;
			}

			if (IBMailAddLbl != null) {
				IBMailAddLbl.Dispose ();
				IBMailAddLbl = null;
			}

			if (IBMailVw != null) {
				IBMailVw.Dispose ();
				IBMailVw = null;
			}

			if (IBMailTitleLbl != null) {
				IBMailTitleLbl.Dispose ();
				IBMailTitleLbl = null;
			}

			if (IBDropImg != null) {
				IBDropImg.Dispose ();
				IBDropImg = null;
			}

			if (IBInboxLbl != null) {
				IBInboxLbl.Dispose ();
				IBInboxLbl = null;
			}

			if (IBInboxCountLbl != null) {
				IBInboxCountLbl.Dispose ();
				IBInboxCountLbl = null;
			}

			if (IBInboxIconImg != null) {
				IBInboxIconImg.Dispose ();
				IBInboxIconImg = null;
			}

			if (IBInboxBtn != null) {
				IBInboxBtn.Dispose ();
				IBInboxBtn = null;
			}

			if (IBInboxVw != null) {
				IBInboxVw.Dispose ();
				IBInboxVw = null;
			}

			if (IBDraftLbl != null) {
				IBDraftLbl.Dispose ();
				IBDraftLbl = null;
			}

			if (IBDraftCountLbl != null) {
				IBDraftCountLbl.Dispose ();
				IBDraftCountLbl = null;
			}

			if (IBDraftIconImg != null) {
				IBDraftIconImg.Dispose ();
				IBDraftIconImg = null;
			}

			if (IBDraftBtn != null) {
				IBDraftBtn.Dispose ();
				IBDraftBtn = null;
			}

			if (IBDraftVw != null) {
				IBDraftVw.Dispose ();
				IBDraftVw = null;
			}

			if (IBSentLbl != null) {
				IBSentLbl.Dispose ();
				IBSentLbl = null;
			}

			if (IBSentCountLbl != null) {
				IBSentCountLbl.Dispose ();
				IBSentCountLbl = null;
			}

			if (IBSentIconImg != null) {
				IBSentIconImg.Dispose ();
				IBSentIconImg = null;
			}

			if (IBSentBtn != null) {
				IBSentBtn.Dispose ();
				IBSentBtn = null;
			}

			if (IBSentVw != null) {
				IBSentVw.Dispose ();
				IBSentVw = null;
			}

			if (IBTrashLbl != null) {
				IBTrashLbl.Dispose ();
				IBTrashLbl = null;
			}

			if (IBTrashCountLbl != null) {
				IBTrashCountLbl.Dispose ();
				IBTrashCountLbl = null;
			}

			if (IBTrashIconImg != null) {
				IBTrashIconImg.Dispose ();
				IBTrashIconImg = null;
			}

			if (IBTrashBtn != null) {
				IBTrashBtn.Dispose ();
				IBTrashBtn = null;
			}

			if (IBTrashVw != null) {
				IBTrashVw.Dispose ();
				IBTrashVw = null;
			}

			if (IBCalendarLbl != null) {
				IBCalendarLbl.Dispose ();
				IBCalendarLbl = null;
			}

			if (IBCalendarIconImg != null) {
				IBCalendarIconImg.Dispose ();
				IBCalendarIconImg = null;
			}

			if (IBCalendarBtn != null) {
				IBCalendarBtn.Dispose ();
				IBCalendarBtn = null;
			}

			if (IBCalendarVw != null) {
				IBCalendarVw.Dispose ();
				IBCalendarVw = null;
			}

			if (IBInvoiceLbl != null) {
				IBInvoiceLbl.Dispose ();
				IBInvoiceLbl = null;
			}

			if (IBInvoiceIconImg != null) {
				IBInvoiceIconImg.Dispose ();
				IBInvoiceIconImg = null;
			}

			if (IBInvoiceBtn != null) {
				IBInvoiceBtn.Dispose ();
				IBInvoiceBtn = null;
			}

			if (IBInvoiceVw != null) {
				IBInvoiceVw.Dispose ();
				IBInvoiceVw = null;
			}
		}
	}
}
