using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.SWRevealViewController;
using LucidX.iOS.CustomCells;

namespace LucidX.iOS
{
	public partial class SettingsVc : UIViewController, IUITableViewDelegate, IUITableViewDataSource
	{
		public SWRevealViewController revealVC;

		Calendar.CalendarVC calendarVc;
		public Inbox.InboxVC inboxVc;
		public Notes.ViewNotesVC notesVC;

		public SettingsVc() : base("SettingsVc", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			configureView();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		#region HelperMethods

		void configureView()
		{
			IBProfileImg.Layer.CornerRadius = IBProfileImg.Frame.Width / 2;
			IBProfileImg.Layer.BorderWidth = 1;
			IBProfileImg.Layer.BorderColor = UIColor.White.CGColor;
			IBProfileImg.ClipsToBounds = true;
			GetLaguageStrings();
			IBNameLbl.Text = IosUtils.Settings.Name;
			IBMailAddLbl.Text = IosUtils.Settings.UserMail;
			IBContntTbl.RegisterNibForCellReuse(MenuCell.Nib, MenuCell.Key);
			GetCount();
			IBContntTbl.EstimatedRowHeight = 50;
		}

		async void GetCount()
		{
			if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
			{
				var res = await Webservices.WebServiceMethods.EmailCount(IosUtils.Settings.UserId);
				if (res != null)
				{
				}
			}
		}


		void GetLaguageStrings()
		{
			SectionTitle.Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSMailTitle", ""));
			SectionTitle.Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSCalendar", ""));
			SectionTitle.Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Order", ""));
			SectionTitle.Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Notes", ""));
			SectionTitle.Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Logout", ""));


			RowsTitle[0].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSInbox", ""));
			RowsTitle[0].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSDrafts", ""));
			RowsTitle[0].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSSent", ""));
			RowsTitle[0].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSTrash", ""));

			RowsTitle[1].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("List", ""));
			RowsTitle[1].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Add", ""));

			RowsTitle[2].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("View Order", ""));
			RowsTitle[2].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Amend Order", ""));
			RowsTitle[2].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Create Order", ""));
			RowsTitle[2].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Convert Order", ""));
			RowsTitle[2].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Delete Order", ""));

			RowsTitle[3].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("View Notes", ""));
			RowsTitle[3].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Amend Notes", ""));
			RowsTitle[3].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Create Notes", ""));
			RowsTitle[3].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Delete Notes", ""));

			RowsTitle[4].Add(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("Delete Notes", ""));

			IBContntTbl.ReloadData();
		}

		#endregion

		#region IBAction Methods

		void ShowVC(UIViewController VC)
		{
			var navVc = new UINavigationController(VC);
			var fixitVw = new UIView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
			fixitVw.BackgroundColor = IosUtils.IosColorConstant.ThemeNavBlue;
			navVc.View.AddSubview(fixitVw);
			revealVC.FrontViewController = navVc;
			revealVC.RevealToggleAnimated(true);
		}


		#endregion


		#region TableView Delegate and data source methods

		List<int> RowsCount = new List<int> { 4, 2, 5, 4, 0 };
		bool IsExpanded;
		int SelectedSection;
		List<string> SectionTitle = new List<string>();
		List<List<string>> RowsTitle = new List<List<string>>() { new List<string>(),
			new List<string> (),
			new List<string> (),
			new List<string> (),
			new List<string> (),
		};

		[Export("numberOfSectionsInTableView:")]
		public nint NumberOfSections(UITableView tableView)
		{
			return 5;
		}


		[Export("tableView:viewForHeaderInSection:")]
		public UIView GetViewForHeader(UITableView tableView, nint section)
		{
			var header = MenuHeader.Create();
			header.Frame = new CGRect(0, 0, tableView.Bounds.Width, 70);
			if (section == SelectedSection)
			{
				header.Configure(SectionTitle[(int)section], (int)section, IsExpanded);
			}
			else
			{
				header.Configure(SectionTitle[(int)section], (int)section);
			}

			header.Clicked -= Header_Clicked;
			header.Clicked += Header_Clicked;
			return header;
		}

		[Export("tableView:heightForHeaderInSection:")]
		public nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			return 50;
		}

		[Export("tableView:cellForRowAtIndexPath:")]
		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(MenuCell.Key) as MenuCell;
			cell.ConfigureCell(RowsTitle[indexPath.Section][indexPath.Row], null, 0);
			return cell;
		}

		[Export("tableView:numberOfRowsInSection:")]
		public nint RowsInSection(UITableView tableView, nint section)
		{
			if (section == SelectedSection)
			{
				return IsExpanded ? RowsCount[(int)section] : 0;
			}
			return 0;
		}

		[Export("tableView:heightForRowAtIndexPath:")]
		public nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return UITableView.AutomaticDimension;
		}

		void Header_Clicked(object sender, bool e)
		{
			var vw = sender as MenuHeader;
			IsExpanded = e;
			SelectedSection = (int)vw.Tag;
			UIView.Animate(0.5, () =>
			{
				this.IBContntTbl.ReloadData();
			});
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			if (indexPath.Section == 0)
			{
				if (inboxVc == null)
				{
					inboxVc = new Inbox.InboxVC();
					inboxVc.revealVC = revealVC;
				}

				//if (indexPath.Row == 0)
				//{
				//	inboxVc.MailTypeId = 1;
				//}
				//else if (indexPath.Row == 1)
				//{
				//	inboxVc.MailTypeId = 2;
				//}
				//else if (indexPath.Row == 2)
				//{
				//	inboxVc.
				//}
				//else if (indexPath.Row == 3)
				//{

				//}

				ShowVC(inboxVc);
				inboxVc.MailTypeId = indexPath.Row + 1;

			}
			else if (indexPath.Section == 1)
			{

			}
			else if (indexPath.Section == 2)
			{

			}
			else if (indexPath.Section == 3)
			{
				if (indexPath.Row == 0)
				{
					if (notesVC == null)
					{
						notesVC = new Notes.ViewNotesVC();
						notesVC.revealVC = revealVC;
					}
					ShowVC(notesVC);

				}
				else if (indexPath.Row == 1)
				{

				}
				else if (indexPath.Row == 2)
				{

				}
				else if (indexPath.Row == 3)
				{

				}

			}
			else if (indexPath.Section == 4)
			{


			}

		}




		#endregion

	}
}

