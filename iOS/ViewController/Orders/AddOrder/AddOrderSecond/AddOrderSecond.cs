using System;
using IosUtils;
using LucidX.iOS.OrderCell;
using UIKit;
using LucidX.ResponseModels;
using System.Collections.Generic;
using Foundation;

namespace LucidX.iOS
{
	public partial class AddOrderSecond : BaseAddOrderVC, IUITableViewDelegate, IUITableViewDataSource
	{
		int selctedIndex = -1;
		public AddOrderSecond() : base("AddOrderSecond", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
<<<<<<< HEAD
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
=======
		}

		void ConfigureView()
		{
			if (SuperVC.LedgerOrderObj.LedgerOrderItems == null)
			{
				SuperVC.LedgerOrderObj.LedgerOrderItems = new List<LedgerOrderItem>();
			}
			ContntTbl.RegisterNibForCellReuse(AddOrderSecondTVCell.Nib, AddOrderSecondTVCell.Key);
			ContntTbl.TableFooterView = new UIView();
			ContntTbl.EstimatedRowHeight = HeightConstants.CellHeight70;
			ContntTbl.RowHeight = UITableView.AutomaticDimension;
			ContntTbl.ReloadData();
			IosUtility.setcornerRadius(BtnAdd);
			IosUtility.setcornerRadius(BtnNext);
		}

		partial void BtnAddClicked(Foundation.NSObject sender)
		{
			selctedIndex = -1;
			var addItemVC = new AddOrderItemController();
			addItemVC.ConutryCode = SuperVC.LedgerOrderObj.CountryCode;
			addItemVC.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
			addItemVC.compCode = SuperVC.LedgerOrderObj.CompCode;
			addItemVC.ItemAdded += AddItemVC_ItemAdded;
			this.PresentViewController(addItemVC, true, null);
		}


		partial void BtnNextClicked(Foundation.NSObject sender)
		{
>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
			SuperVC.index++;
			SuperVC.ChangePage();
		}


<<<<<<< HEAD
=======
		void AddItemVC_ItemAdded(object sender, EventArgs e)
		{
			try
			{
				var item = (LedgerOrderItem)sender;
				if (selctedIndex != -1)
				{
					SuperVC.LedgerOrderObj.LedgerOrderItems[selctedIndex] = item;
				}
				else
				{
					SuperVC.LedgerOrderObj.LedgerOrderItems.Add(item);
				}
				ContntTbl.ReloadData();
			}
			catch
			{

			}
		}


		#region Tableview delegate and database methods

		[Export("numberOfSectionsInTableView:")]
		public nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public nint RowsInSection(UITableView tableView, nint section)
		{
			return SuperVC.LedgerOrderObj.LedgerOrderItems.Count;
		}

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(AddOrderSecondTVCell.Key) as AddOrderSecondTVCell;
			cell.configure(SuperVC.LedgerOrderObj.LedgerOrderItems[indexPath.Row],indexPath.Row);
			cell.EditClicked += Cell_EditClicked;
			return cell;
		}

		[Export("tableView:heightForRowAtIndexPath:")]
		public nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return UITableView.AutomaticDimension;
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			selctedIndex = indexPath.Row;
			var addItemVC = new AddOrderItemController();
			addItemVC.Enable = false;
			addItemVC.ledgerItem = SuperVC.LedgerOrderObj.LedgerOrderItems[indexPath.Row];
			addItemVC.ConutryCode = SuperVC.LedgerOrderObj.CountryCode;
			addItemVC.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
			addItemVC.compCode = SuperVC.LedgerOrderObj.CompCode;
			addItemVC.ItemAdded += AddItemVC_ItemAdded;
			this.PresentViewController(addItemVC, true, null);
		}

		void Cell_EditClicked(object sender, EventArgs e)
		{
			selctedIndex = (int)sender;
			var addItemVC = new AddOrderItemController();
			addItemVC.Enable = true;
			addItemVC.ledgerItem = SuperVC.LedgerOrderObj.LedgerOrderItems[selctedIndex];
			addItemVC.ConutryCode = SuperVC.LedgerOrderObj.CountryCode;
			addItemVC.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
			addItemVC.compCode = SuperVC.LedgerOrderObj.CompCode;
			addItemVC.ItemAdded += AddItemVC_ItemAdded;
			this.PresentViewController(addItemVC, true, null);
		}

		#endregion



>>>>>>> 90563ad437153d848b6e26c760a9f4acf76903c7
	}
}

