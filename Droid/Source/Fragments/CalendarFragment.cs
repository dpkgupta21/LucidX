
using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;
using LucidX.ResponseModels;
using LucidX.Droid.Source.Adapters;
using LucidX.Droid.Source.Activities;
using Android.Support.V4.App;
using Activity = Android.App.Activity;
using LucidX.Droid.Source.CustomDialogFragment;
using LucidX.Droid.Source.Picker;
using LucidX.Droid.Source.Utilities;
using LucidX.Droid.Source.CustomSpinner.Adapter;
using LucidX.Droid.Source.Models;
using Newtonsoft.Json;
using LucidX.Droid.Source.CustomSpinner.Model;

namespace LucidX.Droid.Source.Fragments
{
    /// <summary>
    /// Class CalendarFragment.
    /// </summary>
    public class CalendarFragment : Fragment
    {
        /// <summary>
        /// Calendar type dialog fragment request code
        /// </summary>
        public const int CALENDAR_TYPE_DIALOG_REQUEST_CODE = 1001;
        /// <summary>
        /// The tag
        /// </summary>
        private const string TAG = "CalendarFragment";
        /// <summary>
        /// The expandable view
        /// </summary>
        private ExpandableListView expandableListView;

        /// <summary>
        /// The run list object
        /// </summary>
       // private List<CalendarEventResponse> calendarList;

        /// <summary>
        /// The run list adapter
        /// </summary>
        private CalendarListExpandableAdapter calendarListAdapter;
        /// <summary>
        /// The m activity
        /// </summary>
        private Activity mActivity;

        private View view;

        private LinearLayout linear_user_and_type;
        private RelativeLayout relative_selected_layout;
        private RelativeLayout relative_date_layout;
        private TextView txt_from_date;
        private TextView txt_to_date;
        private DateTime fromDateTime = DateTime.Now;
        private DateTime toDateTime = DateTime.Now;



        private Spinner spin_users;
        private SpinnerItemModel _selectedUsersItem;
        private SpinnerAdapter _userSpinnerAdapter;
        private List<SpinnerItemModel> _userSpinnerItemModelList;

        #region "Functions"
        public static Fragment GetInstance()
        {
            CalendarFragment fragment = new CalendarFragment();
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.fragment_calendar_expandable, container, false);
            HasOptionsMenu = true;

            mActivity = Activity;

            linear_user_and_type = view.FindViewById<LinearLayout>(
                Resource.Id.linear_user_and_type);
            relative_date_layout = view.FindViewById<RelativeLayout>(
               Resource.Id.relative_date_layout);
            relative_selected_layout = view.FindViewById<RelativeLayout>(
             Resource.Id.relative_selected_layout);

            ImageView img_search = view.FindViewById<ImageView>(
               Resource.Id.img_search);
            img_search.Click += Img_search_Click;

            ImageView img_return = view.FindViewById<ImageView>(
               Resource.Id.img_return);
            img_return.Click += Img_return_Click;

            TextView txt_calendar_type = view.FindViewById<TextView>(
                Resource.Id.txt_calendar_type);
            txt_calendar_type.Click += Txt_calendar_type_Click;

            txt_from_date = view.FindViewById<TextView>(
                Resource.Id.txt_from_date);
            txt_from_date.Click += Edt_from_date_Click;

            txt_to_date = view.FindViewById<TextView>(
                Resource.Id.txt_to_date);
            txt_to_date.Click += Edt_to_date_Click;

            spin_users = view.FindViewById<Spinner>(
              Resource.Id.spin_users);

            ((HomeActivity)mActivity).SetTitle(GetString(Resource.String.calendar_title));

            // Set users in spinner
            InitUserSpinnerValues();
            SetUserSpinnerAdapter();

            // Initialize listener for spinner
            InitializeListeners();
         
            return view;
        }

        /// <summary>
        /// Init values for User spinner
        /// </summary>
        private void InitUserSpinnerValues()
        {
            string[] items = Resources.GetStringArray(Resource.Array.user_entries);

            _userSpinnerItemModelList = new List<SpinnerItemModel>();

            for (int i = 0; i < items.Length; i++)
            {
                SpinnerItemModel item = new SpinnerItemModel
                {
                    Id = (i + 1) + "",
                    TEXT = items[i] + "",
                    STATE = false
                };
                _userSpinnerItemModelList.Add(item);
            }
        }

        /// <summary>
        /// Set Account Code spinner adapter
        /// </summary>
        private void SetUserSpinnerAdapter()
        {
            _userSpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
                   _userSpinnerItemModelList);
            spin_users.Adapter = _userSpinnerAdapter;
        }



        private void InitializeListeners()
        {        
            // User Spinner
            spin_users.ItemSelected += (sender, args) =>
            {
                _selectedUsersItem = _userSpinnerItemModelList[args.Position];
                _userSpinnerItemModelList[args.Position].STATE = true;
                // update spinner item list state
                for (int i = 0; i < _userSpinnerItemModelList.Count; i++)
                {
                    if (i == args.Position)
                    {
                        _userSpinnerItemModelList[i].STATE = true;
                    }
                    else
                    {
                        _userSpinnerItemModelList[i].STATE = false;
                    }
                }
                _userSpinnerAdapter.NotifyDataSetChanged();
            };
        }


        /// <summary>
        /// Initializes the contents of the Activity's standard options menu
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="inflater"></param>
        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.menu_calendar, menu);
            try
            {

            }
            catch (Exception e)
            {

            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_add:
                    // Show Add event screen
                    Intent intent = new Intent(mActivity, typeof(AddCalendarEventActivity));
                    intent.PutExtra("isAddEvent", true);
                    StartActivity(intent);
                    mActivity.OverridePendingTransition(Resource.Animation.animation_enter,
                                Resource.Animation.animation_leave);
                    break;
            }
            return true;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);


            expandableListView = view.FindViewById<ExpandableListView>(Resource.Id.expandable_list_view);

            expandableListView.GroupClick += (object pobjSender,
                ExpandableListView.GroupClickEventArgs pArgs) =>
            {

            };

            InitailizeCalendarListExpandableAdapter(GetCalendarResponse());
        }


        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            if (requestCode == CALENDAR_TYPE_DIALOG_REQUEST_CODE)
            {

                string selectedUserListObj = data.GetStringExtra("selectedUserListObj");
                List<UserListModel> selectedUserList = null;

                if (!string.IsNullOrEmpty(selectedUserListObj))
                {
                    selectedUserList = JsonConvert.DeserializeObject<List<UserListModel>>
                        (selectedUserListObj);

                    if (selectedUserList != null && selectedUserList.Count != 0)
                    {
                        TextView txt_calendar_type_val = view.FindViewById<TextView>(
                            Resource.Id.txt_calendar_type_val);
                        txt_calendar_type_val.Text = "Journal (" + selectedUserList.Count + ")";
                    }
                }
            }

        }

        private List<UserListModel> GetUserListModel()
        {
            List<UserListModel> userList = new List<UserListModel>();
            for (int i = 0; i < 5; i++)
            {
                UserListModel userObj = new UserListModel
                {
                    UserName = "Deepak " + i
                };
            }
            return userList;
        }
        private List<CalendarEventResponse> GetCalendarResponse()
        {
            List<CalendarEventResponse> calendarList = new List<CalendarEventResponse>();

            for (int i = 0; i < 5; i++)
            {
                CalendarEventResponse calendarObj = new CalendarEventResponse();
                calendarObj.DisplayDate = (i + 5) + " Dec 2017";

                List<EventResponse> eventList = new List<EventResponse>();
                for (int j = 0; j < 2; j++)
                {
                    EventResponse eventObj = new EventResponse()
                    {
                        EventName = "Deepak",
                        EventDetail = "Has a meeting",
                        EventDateTime = "10:06 PM"

                    };
                    eventList.Add(eventObj);
                }
                calendarObj.EventListResponse = eventList;
                calendarList.Add(calendarObj);

            }

            return calendarList;
        }

        /// <summary>
        /// Sets Calendar event list in listview using adapter,
        /// In case of no events "No Events" will be displayed
        /// </summary>
        /// <param name="CalendarListObj">List of run</param>
        private void InitailizeCalendarListExpandableAdapter(List<CalendarEventResponse> CalendarListObj)
        {
            try
            {
                if (CalendarListObj != null && CalendarListObj.Count > 0)
                {
                    if (calendarListAdapter == null)
                    {
                        calendarListAdapter = new CalendarListExpandableAdapter(mActivity, CalendarListObj);
                        expandableListView.SetAdapter(calendarListAdapter);
                    }
                    else
                    {
                        calendarListAdapter.SetCalendarList(CalendarListObj);
                        calendarListAdapter.NotifyDataSetChanged();
                    }
                    expandableListView.ExpandGroup(0);
                }

            }
            catch (Exception e)
            {
            }

        }


        /// <summary>
        /// Handles the ChildClick event of the ListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExpandableListView.ChildClickEventArgs"/> instance containing the event data.</param>
        private void ListView_ChildClick(object sender, ExpandableListView.ChildClickEventArgs e)
        {
            try
            {
                int groupPosition = e.GroupPosition;
                int childPosition = e.ChildPosition;


                Intent intent = new Intent(mActivity, typeof(HomeActivity));
                StartActivity(intent);
            }
            catch (Exception ex)
            {
            }
        }

        private void Img_return_Click(object sender, EventArgs e)
        {
            relative_selected_layout.Visibility = ViewStates.Gone;
            linear_user_and_type.Visibility = ViewStates.Visible;
            relative_date_layout.Visibility = ViewStates.Visible;
        }

        private void Img_search_Click(object sender, EventArgs e)
        {
            relative_selected_layout.Visibility = ViewStates.Visible;
            linear_user_and_type.Visibility = ViewStates.Gone;
            relative_date_layout.Visibility = ViewStates.Gone;
        }
        private void Txt_calendar_type_Click(object sender, EventArgs e)
        {
            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();

            //remove fragment from backstack if any exists
            Fragment fragmentPrev = FragmentManager.FindFragmentByTag("dialog");
            if (fragmentPrev != null)
                fragmentTransaction.Remove(fragmentPrev);

            fragmentTransaction.AddToBackStack(null);
            //create and show the dialog
            CustomDialogFrag dialogFragment = CustomDialogFrag.NewInstance();
            dialogFragment.SetTargetFragment(this, CALENDAR_TYPE_DIALOG_REQUEST_CODE);
            dialogFragment.Show(fragmentTransaction, "dialog");
        }

        private void Edt_to_date_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                try
                {
                    if (time.Date < fromDateTime.Date)
                    {
                        UtilityDroid.GetInstance().ShowAlertDialog(mActivity,
                           Resources.GetString(Resource.String.error_alert_title),
                           Resources.GetString(Resource.String.alert_message_not_less_than_from_date),
                           Resources.GetString(Resource.String.alert_cancel_btn),
                           Resources.GetString(Resource.String.alert_ok_btn));
                    }
                    else
                    {
                        toDateTime = time;
                        txt_to_date.Text = time.ToShortDateString();
                    }
                }
                catch (Exception ex)
                {
                }
            }, toDateTime);
            frag.Show(Activity.FragmentManager, DatePickerFragment.TAG);
        }

        private void Edt_from_date_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                try
                {
                    if (time.Date < DateTime.Now.Date)
                    {
                        UtilityDroid.GetInstance().ShowAlertDialog(mActivity,
                            Resources.GetString(Resource.String.error_alert_title),
                            Resources.GetString(Resource.String.alert_message_not_less_than_current_date),
                            Resources.GetString(Resource.String.alert_cancel_btn),
                            Resources.GetString(Resource.String.alert_ok_btn));
                    }
                    else
                    {
                        fromDateTime = time;
                        txt_from_date.Text = time.ToShortDateString();
                    }
                }
                catch (Exception ex)
                {
                }
            }, fromDateTime);
            frag.Show(Activity.FragmentManager, DatePickerFragment.TAG);
        }

        #endregion
    }
}


