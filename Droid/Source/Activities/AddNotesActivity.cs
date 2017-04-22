
using Android.OS;
using Android.Views;
using LucidX.Droid.Source.SharedPreference;
using LucidX.Droid.Source.Utilities;
using System;
using Android.Support.V7.App;
using LucidX.Droid.Source.Picker;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using LucidX.Droid.Source.CustomSpinner.Model;
using LucidX.Droid.Source.CustomSpinner.Adapter;
using Android.Graphics;

namespace LucidX.Droid.Source.Activities
{
    [Activity(Label = "LucidX", Icon = "@mipmap/icon", Theme = "@style/AppTheme",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AddNotesActivity : AppCompatActivity
    {

        /// <summary>
        /// The toolbar
        /// </summary>
        private Android.Support.V7.Widget.Toolbar toolbar;
        private Activity mActivity;
        private SharedPreferencesManager mSharedPreferencesManager;
        private bool isAddNote;

        private TextView txt_start_date_val;
        private DateTime noteDateTime = DateTime.Now;

        
        private TextView txt_calendar_type;

        private Spinner spin_account_code;
        private SpinnerItemModel _selectedAccountCodeItem;
        private SpinnerAdapter _accountCodeSpinnerAdapter;
        private List<SpinnerItemModel> _accountCodeSpinnerItemModelList;

        private Spinner spin_current_entity;
        private SpinnerItemModel _selectedCurrentEntitysItem;
        private SpinnerAdapter _entitySpinnerAdapter;
        private List<SpinnerItemModel> _entitySpinnerItemModelList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_add_notes);

            mActivity = this;

            /// Shared Preference manager
            mSharedPreferencesManager = UtilityDroid.GetInstance().
                       GetSharedPreferenceManagerWithEncriptionEnabled(mActivity.ApplicationContext);


            isAddNote = Intent.GetBooleanExtra("isAddNote", false);
            try
            {
                Init();
            }
            catch (Exception e)
            {

            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.delete, menu);

           
            IMenuItem menuItem= menu.FindItem(Resource.Id.menu_delete);
            if (isAddNote) {
                menuItem.SetVisible(false);
            } else
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

            spin_current_entity = FindViewById<Spinner>(Resource.Id.spin_current_entity);
            spin_account_code = FindViewById<Spinner>(Resource.Id.spin_account_code);

            txt_start_date_val = FindViewById<TextView>(Resource.Id.txt_start_date_val);
            txt_start_date_val.Click += Txt_order_date_val_Click;

            Button btn_save = FindViewById<Button>(Resource.Id.btn_save);
            btn_save.Click += Btn_save_Click;

            Button btn_cancel = FindViewById<Button>(Resource.Id.btn_cancel);
            btn_cancel.Click += Btn_cancel_Click;

            txt_calendar_type = FindViewById<TextView>(Resource.Id.txt_calendar_type);

            RadioGroup radio_group = FindViewById<RadioGroup>(Resource.Id.radio_group);
            radio_group.CheckedChange += Radio_group_CheckedChange;

            // Set Current Entity in Spinner
            InitEntitySpinnerValues();
            SetEntitySpinnerAdapter();

            // Set Account Code in Spinner
            InitAccountCodeSpinnerValues();
            SetAccountCodeSpinnerAdapter();

            // Initialize listener for spinner
            InitializeListeners();
        }

        private void SetToolbarTitle()
        {
            if (isAddNote)
            {
                SupportActionBar.SetTitle(Resource.String.add_note_title);
            }
            else
            {
                SupportActionBar.SetTitle(Resource.String.edit_note_title);
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


        private void Radio_group_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            RadioGroup radioGroup = (RadioGroup)sender;
            int selectedGroupId = radioGroup.CheckedRadioButtonId;
            if (selectedGroupId == Resource.Id.radio_btn_select)
            {
                txt_calendar_type.Visibility = ViewStates.Visible;
            }
            else
            {
                txt_calendar_type.Visibility = ViewStates.Gone;
            }
        }

        /// <summary>
        /// Init values for Current Entity spinner
        /// </summary>
        private void InitEntitySpinnerValues()
        {
            List<string> entityItems = new List<string> { "Select Current Entity", "Entity1",
                "Entity2", "Entity3"};

            _entitySpinnerItemModelList = new List<SpinnerItemModel>();

            for (int i = 0; i < entityItems.Count; i++)
            {               
                    SpinnerItemModel item = new SpinnerItemModel
                    {
                        Id = (i+1)+"",
                        TEXT = entityItems[i]+"",
                        STATE = false
                    };

                _entitySpinnerItemModelList.Add(item);              
            }
        }




        /// <summary>
        /// Set Current Entity spinner adapter
        /// </summary>
        private void SetEntitySpinnerAdapter()
        {
            _entitySpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
                   _entitySpinnerItemModelList);
            spin_current_entity.Adapter = _entitySpinnerAdapter;
        }



        /// <summary>
        /// Init values for Account Code spinner
        /// </summary>
        private void InitAccountCodeSpinnerValues()
        {
            List<string> accountCodeItems = new List<string> { "Select Account Code", "Account Code1",
                "Account Code2", "Account Code2" };

            _accountCodeSpinnerItemModelList = new List<SpinnerItemModel>();

            for (int i = 0; i < accountCodeItems.Count; i++)
            {
                SpinnerItemModel item = new SpinnerItemModel
                {
                    Id = (i + 1) + "",
                    TEXT = accountCodeItems[i] + "",
                    STATE = false
                };
                _accountCodeSpinnerItemModelList.Add(item);
            }
        }

        /// <summary>
        /// Set Account Code spinner adapter
        /// </summary>
        private void SetAccountCodeSpinnerAdapter()
        {
            _accountCodeSpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
                   _accountCodeSpinnerItemModelList);
            spin_account_code.Adapter = _accountCodeSpinnerAdapter;
        }



        private void InitializeListeners()
        {
            // Current Entity Spinner
            spin_current_entity.ItemSelected += (sender, args) =>
            {
                _selectedCurrentEntitysItem = _entitySpinnerItemModelList[args.Position];

                _entitySpinnerItemModelList[args.Position].STATE = true;
                // update spinner item list state
                for (int i = 0; i < _entitySpinnerItemModelList.Count; i++)
                {
                    if (i == args.Position)
                    {
                        _entitySpinnerItemModelList[i].STATE = true;
                    }
                    else
                    {
                        _entitySpinnerItemModelList[i].STATE = false;
                    }
                }
                _entitySpinnerAdapter.NotifyDataSetChanged();
            };


            // Account Code Spinner
            spin_account_code.ItemSelected += (sender, args) =>
            {
                _selectedAccountCodeItem = _accountCodeSpinnerItemModelList[args.Position];
                _accountCodeSpinnerItemModelList[args.Position].STATE = true;
                // update spinner item list state
                for (int i = 0; i < _accountCodeSpinnerItemModelList.Count; i++)
                {
                    if (i == args.Position)
                    {
                        _accountCodeSpinnerItemModelList[i].STATE = true;
                    }
                    else
                    {
                        _accountCodeSpinnerItemModelList[i].STATE = false;
                    }
                }
                _accountCodeSpinnerAdapter.NotifyDataSetChanged();
            };
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Btn_save_Click(object sender, EventArgs e)
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
                case Resource.Id.menu_delete:
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
        private void Txt_order_date_val_Click(object sender, EventArgs e)
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
                        noteDateTime = date;
                        txt_start_date_val.Text = date.ToShortDateString();
                    }
                }
                catch (Exception ex)
                {
                }
            }, noteDateTime);
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }




    }

}

