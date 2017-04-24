using System;
using System.Collections.Generic;
using Foundation;
using IosUtils;
using LucidX.ResponseModels;
using LucidX.Webservices;
using UIKit;
using Xamarin.SWRevealViewController;
using LucidX.iOS.CustomCells;
using LucidX.iOS.PickerModels;

namespace LucidX.iOS.Notes
{
	public partial class ViewNotesVC : UIViewController,IUITabBarDelegate,IUITableViewDataSource,IUITextFieldDelegate
	{

		public SWRevealViewController revealVC;

		List<CrmNotesResponse> notes = new List<CrmNotesResponse>();
		List<EntityCodesResponse> entitylst = new List<EntityCodesResponse>();
		List<AccountCodesResponse> accountlst = new List<AccountCodesResponse>();
		

		string EntityCode;
		string AccountCode;
		UITextField selectedTextFeild;

		public ViewNotesVC() : base("ViewNotesVC", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}



		#region helping Methods

		async void GetNotes()
		{
			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				var res = await WebServiceMethods.ShowNotes(EntityCode, AccountCode, false);
				if (res != null)
				{
					notes = res;
				}
				else
				{

				}
				IBNotesTbl.ReloadData();
				IosUtils.Utility.hideProgressHud();
			}
		}

		async void GetEntityCodeList() { 
			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				var res = await WebServiceMethods.GetEntityCode();
				if (res != null)
				{
					entitylst = res;
					var model = new EntityPickerModel(entitylst, IBEntityTxt);
					IBEntityPicker.Model = model;
				}
				else
				{

				}

				IosUtils.Utility.hideProgressHud();
			}
		
		}


		async void GetAccountCodeList() { 
		
			if (IosUtils.Utility.IsReachable())
			{
				IosUtils.Utility.showProgressHud("");
				var res = await WebServiceMethods.GetAccountCodes(EntityCode);
				if (res != null)
				{
					accountlst = res;
					var model = new AccountCodePickerModel(accountlst, IBEntityTxt);
					IBAccountCodePicker.Model = model;
				}
				else
				{

				}

				IosUtils.Utility.hideProgressHud();
			}
		
		}

		/// <summary>
		/// Configures the view.
		/// </summary>
		void ConfigureView()
		{
			this.EdgesForExtendedLayout = UIRectEdge.None;
			this.NavigationItem.Title = "";
			var menuBtn = new UIBarButtonItem(UIImage.FromBundle("Menu"),
											  UIBarButtonItemStyle.Plain,
											  MenuClicked);
			this.NavigationItem.LeftBarButtonItem = menuBtn;

			IBNotesTbl.RegisterNibForCellReuse(NotesCell.Nib, NotesCell.Key);
			IBNotesTbl.TableFooterView = new UIView();
			this.NavigationItem.Title = "Notes";
			this.NavigationItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null, null);

			IosUtils.Utility.setLeftPadding(IBEntityTxt);
			IosUtils.Utility.setLeftPadding(IBAccountCodeTxt);
			IosUtils.Utility.setLeftPadding(IBFromDateTxt);
			IosUtils.Utility.setLeftPadding(IBToDateTxt);

			IBEntityTxt.InputView = IBEntityPicker;
			IBEntityTxt.InputAccessoryView = IBEntityDoneBar;

			IBAccountCodeTxt.InputView = IBAccountCodePicker;
			IBAccountCodeTxt.InputAccessoryView = IBAccountCodeDoneBar;

			IBFromDateTxt.InputView = IBDateTimePicker;
			IBFromDateTxt.InputAccessoryView = IBDateTimeDoneBar;
			IBToDateTxt.InputView = IBDateTimePicker;
			IBToDateTxt.InputAccessoryView = IBDateTimeDoneBar;

			GetEntityCodeList();
			
		}

		#endregion

		[Export("textFieldShouldBeginEditing:")]
		public bool ShouldBeginEditing(UITextField textField)
		{
			selectedTextFeild = textField;
			if (textField == IBAccountCodeTxt && string.IsNullOrEmpty(IBEntityTxt.Text)) {

				IosUtils.Utility.showAlertWithInfo("Error","Select a entity code first");
				return false;
			}
			return true;
		}

		#region IBAction Methods

		void MenuClicked(object sender, EventArgs e)
		{
			revealVC.RevealToggleAnimated(true);
		}


		void EditClicked(object sender, EventArgs e)
		{

		}

		partial void IBAccountDoneClicked(Foundation.NSObject sender) {
			AccountCode = IBAccountCodeTxt.Text;
			selectedTextFeild.EndEditing(true);
			GetNotes();
			
		}

		partial void IBDateTimeDoneClicked(Foundation.NSObject sender) {
			selectedTextFeild.Text = IosUtils.Utility.ConvertToDateTime(IBDateTimePicker.Date).ToString("g");
			selectedTextFeild.EndEditing(true);
		}

		partial void IBEntityDoneClicked(Foundation.NSObject sender) {
			EntityCode = IBEntityTxt.Text;
			GetAccountCodeList();
			selectedTextFeild.EndEditing(true);
			
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
			return notes.Count;
		}

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(NotesCell.Key) as NotesCell;
			cell.ConfigureCell(notes[indexPath.Row]);
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
			//if (IosUtils.Utility.IsReachable())
			//{
			//	notes[indexPath.Row].Unread = false;
			//	markRead(notes[indexPath.Row].MailId);
			//	IBContntTbl.ReloadData();
			//	var detailsVC = new MailDetails.MailDetailsVC();
			//	detailsVC.mail = notes[indexPath.Row];
			//	this.NavigationController.PushViewController(detailsVC, true);
			//}
		}


		#endregion




	}
}

