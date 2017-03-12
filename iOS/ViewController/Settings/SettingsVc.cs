using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using Xamarin.SWRevealViewController;

namespace WSI_NintaBlackBoxAlert_App.iOS
{
	public partial class SettingsVc : UIViewController,IUITableViewDelegate,IUITableViewDataSource
	{
		List<String> menu = new List<string>();

		public SWRevealViewController revealVC;

		public SettingsVc() : base("SettingsVc", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			menu.Add("Change Phone Number");
			IBCopyRightLbl.Text = StringConstants.Instance.SettingsCopyRightText;
			IBMenuTbl.DataSource = this;
			IBMenuTbl.Delegate = this;
			IBMenuTbl.TableFooterView = new UIView();
			IBMenuTbl.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		#region TableView Delegate and DataSource Methods

		[Export("numberOfSectionsInTableView:")]
		public nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public nint RowsInSection(UITableView tableview, nint section)
		{
			return menu.Count;
		}

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = new UITableViewCell(UITableViewCellStyle.Default,"SettingCell");
			cell.TextLabel.Text = menu[indexPath.Row];
			cell.TextLabel.TextColor = UIColor.White;
			cell.TextLabel.Font = UIFont.SystemFontOfSize(15,UIFontWeight.Light);
			cell.ImageView.Image = UIImage.FromBundle("Phone");
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.BackgroundColor = UIColor.Clear;
			return cell;
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			revealVC.RightRevealToggleAnimated(true);
			var vc = new NumberChangeVC();
			(revealVC.FrontViewController as UINavigationController).PushViewController(vc, true);
		}

		#endregion
		partial void CloseBtnClicked(Foundation.NSObject sender) {
			revealVC.RevealToggleAnimated(true);
		}
	}
}

