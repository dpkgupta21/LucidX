using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using LucidX.iOS;
using LucidX.ResponseModels;
using LucidX.Webservices;
using Plugin.Connectivity;
using UIKit;
using Xamarin.SWRevealViewController;
using LucidX.iOS.PickerModels;
using LucidX.iOS.CustomCells;

namespace LucidX.iOS.Calendar
{
	public partial class CalendarVC : UIViewController, IUITextFieldDelegate
	{
		public CalendarVC() : base("CalendarVC", null)
		{
		}

		public SWRevealViewController revealVC;

		List<RefUsersResponse> responseList = new List<RefUsersResponse>();
		List<NotesTypeResponse> _notesTypeList = new List<NotesTypeResponse>();

		List<NotesTypeResponse> _selectedNotesList;

		List<CalendarEventResponse> Events = new List<CalendarEventResponse>();
		RefUsersResponse selectedUser;
		UserRefPicker userPickerModel;
		UITextField selectedFeild;

		String SelectedTypes;

		DateTime StartDate;
		DateTime EndDate;
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureView();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			GetValues();
		}
		#region Helping Methods
		/// <summary>
		/// Configures the view.
		/// </summary>
		void ConfigureView()
		{
			this.EdgesForExtendedLayout = UIRectEdge.None;
			this.NavigationItem.Title = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSCalendar", "");
			var menuBtn = new UIBarButtonItem(UIImage.FromBundle("Menu"),
											  UIBarButtonItemStyle.Plain,
											  MenuClicked);
			this.NavigationItem.LeftBarButtonItem = menuBtn;
			IBContntTbl.RegisterNibForCellReuse(NotesCell.Nib, NotesCell.Key);
			IBContntTbl.TableFooterView = new UIView();

			IBAssignedToTxt.InputView = IBAssignedToPicker;
			IBAssignedToTxt.InputAccessoryView = IBAssignedDoneBar;

			var createBtn = new UIBarButtonItem(UIImage.FromBundle("Add"),
											  UIBarButtonItemStyle.Plain,
												EditClicked);
			this.NavigationItem.RightBarButtonItem = createBtn;

			IBDateTimePicker.Mode = UIDatePickerMode.Date;
			IBFromDateTxt.InputView = IBDateTimePicker;
			IBFromDateTxt.InputAccessoryView = IBDateTimeDoneBar;
			IBToDateTxt.InputView = IBDateTimePicker;
			IBToDateTxt.InputAccessoryView = IBDateTimeDoneBar;
			SetupLanguageString();
		}

		void SetupLanguageString()
		{
			IBToLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSToTitle", "");
			IBEmptyLbl.Text = IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSNoNotes", "");
		}

		private async void GetValues()
		{
			try
			{
				if (CrossConnectivity.Current.IsConnected)
				{
					IosUtils.Utility.showProgressHud("");

					responseList = await WebServiceMethods.ShowRefUsers();

					if (responseList != null && responseList.Count > 0)
					{
						selectedUser = responseList[0];
						IBAssignedToTxt.Text = selectedUser.UserName;
						userPickerModel = new UserRefPicker(responseList, IBAssignedToTxt, selectedUser);
						IBAssignedToPicker.Model = userPickerModel;
					}

					_notesTypeList = await WebServiceMethods.ShowNotesType();

					GetNotesTypeResult(_notesTypeList);

					IosUtils.Utility.hideProgressHud();
					SetDateTime();
				}
			}
			catch (Exception e)
			{
				IosUtils.Utility.hideProgressHud();
			}
		}

		void SetDateTime()
		{
			DateTime now = DateTime.Now;
			StartDate = new DateTime(now.Year, now.Month, 1);
			EndDate = StartDate.AddMonths(1).AddDays(-1);
			IBToDateTxt.Text = EndDate.ToString("d");
			IBFromDateTxt.Text = StartDate.ToString("d");
			getEvents();
		}

		public void GetNotesTypeResult(List<NotesTypeResponse> _notesTypeList)
		{
			this._notesTypeList = _notesTypeList;

			_selectedNotesList = _notesTypeList.Where(x => x.IsSelected == true).ToList();
			if (_selectedNotesList != null && _selectedNotesList.Count != 0)
			{
				IBCalendarTypeTxt.Text = "Journal (" + _selectedNotesList.Count + ")";
			}
			SelectedTypes = string.Empty;
			foreach (var e in _selectedNotesList) {
				SelectedTypes += e.NotesTypeId + ",";
			}
		}

		public async void getEvents()
		{
			try
			{
				if (CrossConnectivity.Current.IsConnected)
				{
					IosUtils.Utility.showProgressHud("");

					var res = await WebServiceMethods.GetCalendarEvents(selectedUser.UserID,
					                                              SelectedTypes,
					                                              StartDate.ToString("d"),
					                                              EndDate.ToString("d")
					                                             );
					if (res != null && res.Count > 0)
					{
						Events = res;
						IBEmptyLbl.Hidden = true;
					}
					else {
						IBEmptyLbl.Hidden = false;
					}

					IosUtils.Utility.hideProgressHud();
				}
			}
			catch (Exception e)
			{
				IosUtils.Utility.hideProgressHud();
			}

		}

		#endregion

		#region IBAction Methods

		void EditClicked(object sender, EventArgs e)
		{
			var createNotesVc = new CreateCalendarEventVC();
			//createNotesVc.isEdit = false;
			this.NavigationController.PushViewController(createNotesVc, true);
		}

		void MenuClicked(object sender, EventArgs e)
		{
			revealVC.RevealToggleAnimated(true);
		}

		partial void IBAssignedDoneClicked(Foundation.NSObject sender)
		{
			selectedUser = userPickerModel.selectedModel;
			IBAssignedToTxt.EndEditing(true);
		}

		partial void IBDateTimeDoneClicked(Foundation.NSObject sender)
		{
			if (selectedFeild == IBFromDateTxt)
			{
				StartDate = IosUtils.Utility.ConvertToDateTime(IBDateTimePicker.Date);
			}
			else
			{
				EndDate = IosUtils.Utility.ConvertToDateTime(IBDateTimePicker.Date);
			}
			selectedFeild.Text = IosUtils.Utility.ConvertToDateTime(IBDateTimePicker.Date).ToString("d");
		}

		[Export("textFieldDidEndEditing:")]
		public void EditingEnded(UITextField textField)
		{
			selectedUser = userPickerModel.selectedModel;
		}

		#endregion

		[Export("textFieldShouldBeginEditing:")]
		public bool ShouldBeginEditing(UITextField textField)
		{
			if (responseList.Count > 0 && _notesTypeList.Count > 0)
			{
				if (textField == IBCalendarTypeTxt)
				{
					var dialog = MultiSelectionDialog.Create();
					dialog.Configure(_notesTypeList, "Calendar Types");
					dialog.SaveClicked -= Dialog_SaveClicked;
					dialog.SaveClicked += Dialog_SaveClicked;
					return false;
				}
				else if (textField == IBToDateTxt && string.IsNullOrEmpty(IBFromDateTxt.Text))
				{
					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
														   IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSFromDateEmpty", "LSErrorTitle"));
					return false;
				}
				else if (textField == IBFromDateTxt)
				{
					IBDateTimePicker.Date = IosUtils.Utility.ConvertToNSDate(StartDate);
					IBDateTimePicker.MinimumDate = NSDate.DistantPast; //IosUtils.Utility.ConvertToNSDate(new DateTime(2001, 1, 1, 0, 0, 0));
				}
				else if (textField == IBToDateTxt && string.IsNullOrEmpty(IBFromDateTxt.Text))
				{

					IosUtils.Utility.showAlertWithInfo(IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSErrorTitle", "LSErrorTitle"),
													   IosUtils.LocalizedString.sharedInstance.GetLocalizedString("LSFromDateEmpty", "LSErrorTitle"));
					return false;
				}
				else if (textField == IBToDateTxt)
				{
					IBDateTimePicker.Date = IosUtils.Utility.ConvertToNSDate(EndDate);
					IBDateTimePicker.MinimumDate = IosUtils.Utility.ConvertToNSDate(StartDate);

				}

				selectedFeild = textField;
				return true;
			}
			else
			{
				return false;
			}
		}

		void Dialog_SaveClicked(object sender, List<LucidX.ResponseModels.NotesTypeResponse> e)
		{
			_notesTypeList = e;
			GetNotesTypeResult(e);
		}


		#region Tableview delegate and database methods

		[Export("numberOfSectionsInTableView:")]
		public nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public nint RowsInSection(UITableView tableView, nint section)
		{
			return Events.Count;
		}

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(NotesCell.Key) as NotesCell;
			cell.ConfigureCell(Events[indexPath.Row]);
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
			if (IosUtils.Utility.IsReachable())
			{
				//var createNotesVc = new CreateNotesVC();
				//createNotesVc.isEdit = true;
				//createNotesVc.notes = notes[indexPath.Row];
				//this.NavigationController.PushViewController(createNotesVc, true);
			}
		}


		#endregion

	}
}

