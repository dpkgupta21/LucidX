using System;

using UIKit;

namespace LucidX.iOS
{
	public partial class AddOrderItemController : UIViewController
	{
		public AddOrderItemController() : base("AddOrderItemController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
		}

		void ConfigureView()
		{
			IosUtils.IosUtility.setcornerRadius(BtnOk);
			IosUtils.IosUtility.setcornerRadius(BtnCancel);
			TxtRevenue.InputView = RevenuePicker;
			TxtRevenue.InputAccessoryView = RevenueDoneBar;

			TxtTaxType.InputView = TaxtTypePicker;
			TxtTaxType.InputAccessoryView = TaxTypeDoneBar;

			TxtAmount.InputAccessoryView = AmountDoneBar;
		}

		partial void CancelClicked(Foundation.NSObject sender)
		{
			this.DismissViewController(true, null);
		}

		partial void AmountDoneClicked(Foundation.NSObject sender)
		{
			TxtAmount.EndEditing(true);
		}

		partial void BtnDeleteClicked(Foundation.NSObject sender)
		{

		}

		partial void BtnOkClicked(Foundation.NSObject sender)
		{

		}

		partial void RevenueDoneClicked(Foundation.NSObject sender)
		{
			TxtRevenue.EndEditing(true);
		}

		partial void TaxDoneClicked(Foundation.NSObject sender)
		{
			TxtTaxType.EndEditing(true);
		}

		partial void RevenueEditingEnded(Foundation.NSObject sender) { 
		
		}

		partial void AmountEditingEnded(Foundation.NSObject sender) { 
		
		}

		partial void TaxTypeEditingEnded(Foundation.NSObject sender) { 
		
		}


	}
}

