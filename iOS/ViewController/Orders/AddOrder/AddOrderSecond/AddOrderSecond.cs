using System;
using IosUtils;
using LucidX.iOS.OrderCell;
using UIKit;

namespace LucidX.iOS
{
	public partial class AddOrderSecond : BaseAddOrderVC
	{
		public AddOrderSecond() : base("AddOrderSecond", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
		}


		void ConfigureView() {
			ContntTbl.RegisterNibForCellReuse(OrderListCell.Nib, OrderListCell.Key);
			ContntTbl.TableFooterView = new UIView();
			ContntTbl.EstimatedRowHeight = HeightConstants.CellHeight70;
			IosUtility.setcornerRadius(BtnAdd);
			IosUtility.setcornerRadius(BtnNext);

		}


		partial void BtnAddClicked(Foundation.NSObject sender) {
			
			var addItemVC = new AddOrderItemController();
			addItemVC.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
			//addItemVC.conte
			this.PresentViewController(addItemVC, true, null);
		}


		partial void BtnNextClicked(Foundation.NSObject sender) {
			SuperVC.index++;
			SuperVC.ChangePage();
		}


	}
}

