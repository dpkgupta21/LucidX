
using Android.OS;
using Android.Views;
using LucidX.Droid.Source.SharedPreference;
using LucidX.Droid.Source.Utilities;
using System;
using Android.Support.V7.App;
using LucidX.Droid.Source.Picker;
using Android.Widget;
using Android.App;
using LucidX.Droid.Source.CustomSpinner.Model;
using LucidX.Droid.Source.CustomSpinner.Adapter;
using System.Collections.Generic;
using Android.Graphics;

namespace LucidX.Droid.Source.Activities
{
    [Activity(Label = "LucidX", Icon = "@mipmap/icon", Theme = "@style/AppTheme",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AddCalendarEventActivity : AppCompatActivity
    {
        /// <summary>
        /// Calendar type dialog fragment request code
        /// </summary>
        public const int CALENDAR_TYPE_DIALOG_REQUEST_CODE = 1001;
        /// <summary>
        /// The toolbar
        /// </summary>
        private Android.Support.V7.Widget.Toolbar toolbar;

        private Activity mActivity;

        private SharedPreferencesManager mSharedPreferencesManager;
        private bool isAddEvent;

        private TextView txt_start_date_val;
        private TextView txt_end_date_val;
        private TextView txt_start_time_val;
        private TextView txt_end_time_val;
        private DateTime startDateTime = DateTime.Now;
        private DateTime endDateTime = DateTime.Now;

        private TimeSpan startTimeSpan;
        private TimeSpan endTimeSpan;

        private Spinner spin_calendar_type;
        private SpinnerItemModel _selectedCalendarTypeItem;
        private SpinnerAdapter _calendarTypeSpinnerAdapter;
        private List<SpinnerItemModel> _calendarTypeSpinnerItemModelList;

        private Spinner spin_users;
        private SpinnerItemModel _selectedUsersItem;
        private SpinnerAdapter _userSpinnerAdapter;
        private List<SpinnerItemModel> _userSpinnerItemModelList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_add_calendar_event);

            mActivity = this;

            /// Shared Preference manager
            mSharedPreferencesManager = UtilityDroid.GetInstance().
                       GetSharedPreferenceManagerWithEncriptionEnabled(mActivity.ApplicationContext);

            isAddEvent = Intent.GetBooleanExtra("isAddEvent", false);
            try
            {
                Init();
            }
            catch (Exception)
            {

            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.delete, menu);


            IMenuItem menuItem = menu.FindItem(Resource.Id.menu_delete);
            if (isAddEvent)
            {
                menuItem.SetVisible(false);
            }
            else
            {
                menuItem.SetVisible(true);
            }
            return true;
        }


        /// <summary>
        /// Init this instance.
        /// </summary>
        private void Init()
        {
            // Init toolbar
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);

            // Set toolbar title Add or Edit according to condition
            SetToolbarTitle();
            // Set font for title
            ApplyFontForToolbarTitle();

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            txt_start_date_val = FindViewById<TextView>(Resource.Id.txt_start_date_val);
            txt_start_date_val.Click += Txt_start_date_val_Click;

            txt_end_date_val = FindViewById<TextView>(Resource.Id.txt_end_date_val);
            txt_end_date_val.Click += Txt_end_date_val_Click;

            txt_start_time_val = FindViewById<TextView>(Resource.Id.txt_start_time_val);
            txt_start_time_val.Click += Txt_start_time_val_Click;

            txt_end_time_val = FindViewById<TextView>(Resource.Id.txt_end_time_val);
            txt_end_time_val.Click += Txt_end_time_val_Click;

            spin_users = FindViewById<Spinner>(Resource.Id.spin_users);
            spin_calendar_type = FindViewById<Spinner>(Resource.Id.spin_calendar_type);

            Button btn_cancel = FindViewById<Button>(Resource.Id.btn_cancel);
            btn_cancel.Click += Btn_cancel_Click;

            Button btn_save = FindViewById<Button>(Resource.Id.btn_save);
            btn_save.Click += Btn_save_Click;

            // Set CalendarTypes in spinner;
            InitCalendarTypeSpinnerValues();
            SetCalendarTypeSpinnerAdapter();

            // Set users in spinner
            InitUserSpinnerValues();
            SetUserSpinnerAdapter();

            // Initialize listener for spinner
            InitializeListeners();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void SetToolbarTitle()
        {
            if (isAddEvent)
            {
                SupportActionBar.SetTitle(Resource.String.add_event_title);
            }
            else
            {
                SupportActionBar.SetTitle(Resource.String.edit_event_title);
            }

        }

        public void ApplyFontForToolbarTitle()
        {
            for (int i = 0; i < toolbar.ChildCount; i++)
            {
                View view = toolbar.GetChildAt(i);
                if (view is TextView)
                {
                    TextView tv = (TextView)view;
                    Typeface titleFont = Typeface.
                       CreateFromAsset(mActivity.Assets, "Fonts/century-gothic.ttf");
                    if (tv.Text.Equals(toolbar.Title))
                    {
                        tv.Typeface = titleFont;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Init values for Calendar Type spinner
        /// </summary>
        private void InitCalendarTypeSpinnerValues()
        {
            string[] items = Resources.GetStringArray(Resource.Array.calendar_entries);

            _calendarTypeSpinnerItemModelList = new List<SpinnerItemModel>();

            for (int i = 0; i < items.Length; i++)
            {
                SpinnerItemModel item = new SpinnerItemModel
                {
                    Id = (i + 1) + "",
                    TEXT = items[i] + "",
                    STATE = false
                };

                _calendarTypeSpinnerItemModelList.Add(item);
            }
        }




        /// <summary>
        /// Set Calendar Type spinner adapter
        /// </summary>
        private void SetCalendarTypeSpinnerAdapter()
        {
            _calendarTypeSpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
                   _calendarTypeSpinnerItemModelList);
            spin_calendar_type.Adapter = _calendarTypeSpinnerAdapter;
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
        /// Set User spinner adapter
        /// </summary>
        private void SetUserSpinnerAdapter()
        {
            _userSpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
                   _userSpinnerItemModelList);
            spin_users.Adapter = _userSpinnerAdapter;
        }



        private void InitializeListeners()
        {
            // Calendar Type Spinner
            spin_calendar_type.ItemSelected += (sender, args) =>
            {
                _selectedCalendarTypeItem = _calendarTypeSpinnerItemModelList[args.Position];

                _calendarTypeSpinnerItemModelList[args.Position].STATE = true;
                // update spinner item list state
                for (int i = 0; i < _calendarTypeSpinnerItemModelList.Count; i++)
                {
                    if (i == args.Position)
                    {
                        _calendarTypeSpinnerItemModelList[i].STATE = true;
                    }
                    else
                    {
                        _calendarTypeSpinnerItemModelList[i].STATE = false;
                    }
                }
                _calendarTypeSpinnerAdapter.NotifyDataSetChanged();
            };


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




        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            Finish();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;

            }
            return true;
        }


        /// <summary>
        /// Shows Date picker for start Date time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_start_date_val_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime date)
            {
                try
                {
                    if (date.Date < DateTime.Now.Date)
                    {
                        UtilityDroid.GetInstance().ShowAlertDialog(mActivity,
                            Resources.GetString(Resource.String.error_alert_title),
                            Resources.GetString(Resource.String.alert_message_not_less_than_current_date),
                            Resources.GetString(Resource.String.alert_cancel_btn),
                            Resources.GetString(Resource.String.alert_ok_btn));
                    }
                    else
                    {
                        startDateTime = date;
                        txt_start_date_val.Text = date.ToShortDateString();
                    }
                }
                catch (Exception ex)
                {
                }
            }, startDateTime);
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }


        /// <summary>
        /// Shows Date picker for end Date time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_end_date_val_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime date)
            {
                try
                {
                    if (date.Date < startDateTime.Date)
                    {
                        UtilityDroid.GetInstance().ShowAlertDialog(mActivity,
                           Resources.GetString(Resource.String.error_alert_title),
                           Resources.GetString(Resource.String.alert_message_not_less_than_from_date),
                           Resources.GetString(Resource.String.alert_cancel_btn),
                           Resources.GetString(Resource.String.alert_ok_btn));
                    }
                    else
                    {
                        endDateTime = date;
                        txt_end_date_val.Text = date.ToShortDateString();
                    }
                }
                catch (Exception ex)
                {
                }
            }, endDateTime);
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void Txt_end_time_val_Click(object sender, EventArgs e)
        {
            TimePickerFragment frag = TimePickerFragment.NewInstance(delegate (TimeSpan time)
            {
                endTimeSpan = time;
                txt_end_time_val.Text = endTimeSpan.ToString();


            });
            frag.Show(FragmentManager, TimePickerFragment.TAG);
        }

        private void Txt_start_time_val_Click(object sender, EventArgs e)
        {
            TimePickerFragment frag = TimePickerFragment.NewInstance(delegate (TimeSpan time)
            {
                startTimeSpan = time;
                txt_start_time_val.Text = startTimeSpan.ToString();


            });
            frag.Show(FragmentManager, TimePickerFragment.TAG);
        }


    }

}

