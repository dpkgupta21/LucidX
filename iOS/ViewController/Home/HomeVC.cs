using System;
using UIKit;
using Plugin.Connectivity;
using Xamarin.SWRevealViewController;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Foundation;
using CustomCells;
using IosUtils;

namespace LucidX.iOS
{
	public partial class HomeVC : UIViewController, IUISearchBarDelegate, IUITableViewDelegate, IUITableViewDataSource
	{
		public string number;
		public SWRevealViewController revealVC;

		public HomeVC() : base("HomeVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


		#region Helping Methods

		/// <summary>
		/// Configures the view.
		/// </summary>
		void ConfigureView()
		{
			this.EdgesForExtendedLayout = UIRectEdge.None;
			this.NavigationItem.Title = "";
			var menuBtn = new UIBarButtonItem(UIImage.FromBundle("User"),
											  UIBarButtonItemStyle.Plain,
											  MenuClicked);
			this.NavigationItem.LeftBarButtonItem = menuBtn;
			this.IBCancelWidth.Constant = 0;
			IBContntTbl.RegisterNibForCellReuse(MailDetailsCell.Nib, MailDetailsCell.Key);
		}


		#endregion


		#region SearchBar Delegate Methods

		[Export("searchBarShouldBeginEditing:")]
		public bool ShouldBeginEditing(UISearchBar searchBar)
		{
			UIView.Animate(0.2f, () =>
			{
				this.IBCancelWidth.Constant = 60;
				this.View.LayoutIfNeeded();
			});
			return true;
		}

		#endregion
		#region IBAction Methods

		void MenuClicked(object sender, EventArgs e)
		{
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBCancelClicked(Foundation.NSObject sender)
		{
			IBSearchBar.EndEditing(true);
			UIView.Animate(0.2f, () =>
			{
				this.IBCancelWidth.Constant = 0;
				this.View.LayoutIfNeeded();
			});
		}

		#endregion

		#region Tableview delegate and database methods

		[Export("numberOfSectionsInTableView:")]
		public nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public nint RowsInSection(UITableView tableView, nint section)
		{
			return 5;
		}

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(MailDetailsCell.Key) as MailDetailsCell;
			cell.ConfigureView();
			return cell;
		}
		[Export("tableView:heightForRowAtIndexPath:")]
		public nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return HeightConstants.CellHeight70;
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{ 
		
		}


  #endregion



	}
}