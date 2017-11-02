using System;

using UIKit;

namespace LucidX.iOS
{
	public partial class AddOrderThird : BaseAddOrderVC
	{
		public AddOrderThird() : base("AddOrderThird", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
		}

		void ConfigureView() {
			IosUtils.IosUtility.setcornerRadius(BtnSave);
			IosUtils.IosUtility.setcornerRadius(BtnCancel);
		}

		partial void BtnCancelClicked(Foundation.NSObject sender) { 
		
		}

		partial void BtnSaveClicked(Foundation.NSObject sender) { 
		
		
		}

	}
}

