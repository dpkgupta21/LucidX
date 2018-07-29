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
	[Register ("AddOrderItemController")]
	partial class AddOrderItemController
	{
		[Outlet]
		UIKit.UIToolbar AmountDoneBar { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem AmountDoneBtn { get; set; }

		[Outlet]
		UIKit.UIButton BtnCancel { get; set; }

		[Outlet]
<<<<<<< HEAD
=======
		UIKit.UIButton BtnClose { get; set; }

		[Outlet]
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
		UIKit.UIButton BtnDelete { get; set; }

		[Outlet]
		UIKit.UIButton BtnOk { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem BtnRevenueDone { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem BtnTaxDone { get; set; }

		[Outlet]
		UIKit.UILabel LblAmount { get; set; }

		[Outlet]
		UIKit.UILabel LblDescription { get; set; }

		[Outlet]
		UIKit.UILabel LblRevenue { get; set; }

		[Outlet]
		UIKit.UILabel LblTaxType { get; set; }

		[Outlet]
		UIKit.UILabel LblTitle { get; set; }

		[Outlet]
		UIKit.UILabel LblVat { get; set; }

		[Outlet]
		UIKit.UIToolbar RevenueDoneBar { get; set; }

		[Outlet]
		UIKit.UIPickerView RevenuePicker { get; set; }

		[Outlet]
		TPKeyboardAvoiding.TPKeyboardAvoidingScrollView ScrollVw { get; set; }

		[Outlet]
		UIKit.UIPickerView TaxtTypePicker { get; set; }

		[Outlet]
		UIKit.UIToolbar TaxTypeDoneBar { get; set; }

		[Outlet]
		UIKit.UITextField TxtAmount { get; set; }

		[Outlet]
		UIKit.UITextField TxtDescription { get; set; }

		[Outlet]
		UIKit.UITextField TxtRevenue { get; set; }

		[Outlet]
		UIKit.UITextField TxtTaxType { get; set; }

		[Outlet]
		UIKit.UITextField TxtVat { get; set; }

		[Action ("AmountDoneClicked:")]
		partial void AmountDoneClicked (Foundation.NSObject sender);

		[Action ("AmountEditingEnded:")]
		partial void AmountEditingEnded (Foundation.NSObject sender);

<<<<<<< HEAD
=======
		[Action ("BtnCloseClicked:")]
		partial void BtnCloseClicked (Foundation.NSObject sender);

>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
		[Action ("BtnDeleteClicked:")]
		partial void BtnDeleteClicked (Foundation.NSObject sender);

		[Action ("BtnOkClicked:")]
		partial void BtnOkClicked (Foundation.NSObject sender);

		[Action ("CancelClicked:")]
		partial void CancelClicked (Foundation.NSObject sender);

		[Action ("RevenueDoneClicked:")]
		partial void RevenueDoneClicked (Foundation.NSObject sender);

		[Action ("RevenueEditingEnded:")]
		partial void RevenueEditingEnded (Foundation.NSObject sender);

		[Action ("TaxDoneClicked:")]
		partial void TaxDoneClicked (Foundation.NSObject sender);

		[Action ("TaxTypeEditingEnded:")]
		partial void TaxTypeEditingEnded (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
<<<<<<< HEAD
			if (ScrollVw != null) {
				ScrollVw.Dispose ();
				ScrollVw = null;
			}

			if (LblTitle != null) {
				LblTitle.Dispose ();
				LblTitle = null;
=======
			if (BtnClose != null) {
				BtnClose.Dispose ();
				BtnClose = null;
			}

			if (AmountDoneBar != null) {
				AmountDoneBar.Dispose ();
				AmountDoneBar = null;
			}

			if (AmountDoneBtn != null) {
				AmountDoneBtn.Dispose ();
				AmountDoneBtn = null;
			}

			if (BtnCancel != null) {
				BtnCancel.Dispose ();
				BtnCancel = null;
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
			}

			if (BtnDelete != null) {
				BtnDelete.Dispose ();
				BtnDelete = null;
			}

<<<<<<< HEAD
=======
			if (BtnOk != null) {
				BtnOk.Dispose ();
				BtnOk = null;
			}

			if (BtnRevenueDone != null) {
				BtnRevenueDone.Dispose ();
				BtnRevenueDone = null;
			}

			if (BtnTaxDone != null) {
				BtnTaxDone.Dispose ();
				BtnTaxDone = null;
			}

			if (LblAmount != null) {
				LblAmount.Dispose ();
				LblAmount = null;
			}

>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
			if (LblDescription != null) {
				LblDescription.Dispose ();
				LblDescription = null;
			}

<<<<<<< HEAD
			if (TxtDescription != null) {
				TxtDescription.Dispose ();
				TxtDescription = null;
			}

=======
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
			if (LblRevenue != null) {
				LblRevenue.Dispose ();
				LblRevenue = null;
			}

<<<<<<< HEAD
			if (TxtRevenue != null) {
				TxtRevenue.Dispose ();
				TxtRevenue = null;
			}

=======
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
			if (LblTaxType != null) {
				LblTaxType.Dispose ();
				LblTaxType = null;
			}

<<<<<<< HEAD
			if (TxtTaxType != null) {
				TxtTaxType.Dispose ();
				TxtTaxType = null;
			}

			if (LblAmount != null) {
				LblAmount.Dispose ();
				LblAmount = null;
			}

			if (TxtAmount != null) {
				TxtAmount.Dispose ();
				TxtAmount = null;
=======
			if (LblTitle != null) {
				LblTitle.Dispose ();
				LblTitle = null;
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
			}

			if (LblVat != null) {
				LblVat.Dispose ();
				LblVat = null;
			}

<<<<<<< HEAD
			if (TxtVat != null) {
				TxtVat.Dispose ();
				TxtVat = null;
			}

			if (BtnOk != null) {
				BtnOk.Dispose ();
				BtnOk = null;
			}

			if (BtnCancel != null) {
				BtnCancel.Dispose ();
				BtnCancel = null;
			}

			if (RevenueDoneBar != null) {
				RevenueDoneBar.Dispose ();
				RevenueDoneBar = null;
			}

			if (BtnRevenueDone != null) {
				BtnRevenueDone.Dispose ();
				BtnRevenueDone = null;
=======
			if (RevenueDoneBar != null) {
				RevenueDoneBar.Dispose ();
				RevenueDoneBar = null;
			}

			if (RevenuePicker != null) {
				RevenuePicker.Dispose ();
				RevenuePicker = null;
			}

			if (ScrollVw != null) {
				ScrollVw.Dispose ();
				ScrollVw = null;
			}

			if (TaxtTypePicker != null) {
				TaxtTypePicker.Dispose ();
				TaxtTypePicker = null;
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
			}

			if (TaxTypeDoneBar != null) {
				TaxTypeDoneBar.Dispose ();
				TaxTypeDoneBar = null;
			}

<<<<<<< HEAD
			if (BtnTaxDone != null) {
				BtnTaxDone.Dispose ();
				BtnTaxDone = null;
			}

			if (AmountDoneBar != null) {
				AmountDoneBar.Dispose ();
				AmountDoneBar = null;
			}

			if (AmountDoneBtn != null) {
				AmountDoneBtn.Dispose ();
				AmountDoneBtn = null;
			}

			if (RevenuePicker != null) {
				RevenuePicker.Dispose ();
				RevenuePicker = null;
			}

			if (TaxtTypePicker != null) {
				TaxtTypePicker.Dispose ();
				TaxtTypePicker = null;
=======
			if (TxtAmount != null) {
				TxtAmount.Dispose ();
				TxtAmount = null;
			}

			if (TxtDescription != null) {
				TxtDescription.Dispose ();
				TxtDescription = null;
			}

			if (TxtRevenue != null) {
				TxtRevenue.Dispose ();
				TxtRevenue = null;
			}

			if (TxtTaxType != null) {
				TxtTaxType.Dispose ();
				TxtTaxType = null;
			}

			if (TxtVat != null) {
				TxtVat.Dispose ();
				TxtVat = null;
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
			}
		}
	}
}
