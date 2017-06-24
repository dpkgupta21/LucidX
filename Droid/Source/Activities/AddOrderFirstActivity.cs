
using Android.OS;
using Android.Views;
using LucidX.Droid.Source.SharedPreference;
using LucidX.Droid.Source.Utilities;
using System;
using Android.Support.V7.App;
using LucidX.Droid.Source.Picker;
using Android.Widget;
using Android.App;
using Android.Content;
using LucidX.Droid.Source.CustomSpinner.Model;
using System.Collections.Generic;
using LucidX.Droid.Source.CustomSpinner.Adapter;
using Android.Graphics;
using LucidX.ResponseModels;
using Newtonsoft.Json;
using LucidX.Droid.Source.Fragments;

namespace LucidX.Droid.Source.Activities
{
    [Activity(Label = "LucidX", Icon = "@mipmap/icon", Theme = "@style/AppTheme",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AddOrderFirstActivity : AppCompatActivity
    {

        /// <summary>
        /// The toolbar
        /// </summary>
        private Android.Support.V7.Widget.Toolbar toolbar;
        private Activity mActivity;
        private SharedPreferencesManager mSharedPreferencesManager;

        public OrdersResponse orderObj { get; set; }

        ////private TextView txt_order_date_val;
        ////private DateTime orderDateTime = DateTime.Now;

        ////private Spinner spin_customer;
        ////private SpinnerItemModel _selectedCustomerItem;
        ////private SpinnerAdapter _customerSpinnerAdapter;
        ////private List<SpinnerItemModel> _customerSpinnerItemModelList;

        ////private Spinner spin_currency;
        ////private SpinnerItemModel _selectedCurrencyItem;
        ////private SpinnerAdapter _currencySpinnerAdapter;
        ////private List<SpinnerItemModel> _currencySpinnerItemModelList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_add_first_order);

            mActivity = this;

            /// Shared Preference manager
            mSharedPreferencesManager = UtilityDroid.GetInstance().
                       GetSharedPreferenceManagerWithEncriptionEnabled(mActivity.ApplicationContext);

            string orderObjString = Intent.GetStringExtra("orderObj");
            orderObj = JsonConvert.DeserializeObject<OrdersResponse>(orderObjString);

            try
            {
                Init();

                DisplayFragment();
            }
            catch (Exception e)
            {

            }
        }

        private void DisplayFragment()
        {
            Fragment fragment = AddOrderFirstFragment.GetInstance();
            var ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frame_container, fragment, fragment.Class.Name);
            ft.Commit();
        }

        /// <summary>
        /// Init this instance.
        /// </summary>
        private void Init()
        {
            // Init toolbar
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.add_order_title);
            ApplyFontForToolbarTitle();
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            //txt_order_date_val = FindViewById<TextView>(Resource.Id.txt_order_date_val);
            //txt_order_date_val.Click += Txt_order_date_val_Click;

            //Button btn_next = FindViewById<Button>(Resource.Id.btn_next);
            //btn_next.Click += Btn_next_Click;

            //spin_customer = FindViewById<Spinner>(Resource.Id.spin_customer);

            //spin_currency = FindViewById<Spinner>(Resource.Id.spin_currency);


            //// Set Customer in spinner;
            //InitCustomerSpinnerValues();
            //SetCustomerSpinnerAdapter();

            //// Set Currency in spinner
            //InitCurrencySpinnerValues();
            //SetCurrencySpinnerAdapter();

            //// Initialize listener for spinner
            //InitializeListeners();
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


        ///// <summary>
        ///// Init values for Customerspinner
        ///// </summary>
        //private void InitCustomerSpinnerValues()
        //{
        //    string[] items = Resources.GetStringArray(Resource.Array.customer_entries);

        //    _customerSpinnerItemModelList = new List<SpinnerItemModel>();

        //    for (int i = 0; i < items.Length; i++)
        //    {
        //        SpinnerItemModel item = new SpinnerItemModel
        //        {
        //            Id = (i + 1) + "",
        //            TEXT = items[i] + "",
        //            STATE = false
        //        };

        //        _customerSpinnerItemModelList.Add(item);
        //    }
        //}




        ///// <summary>
        ///// Set Customer spinner adapter
        ///// </summary>
        //private void SetCustomerSpinnerAdapter()
        //{
        //    _customerSpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
        //           _customerSpinnerItemModelList);
        //    spin_customer.Adapter = _customerSpinnerAdapter;
        //}



        ///// <summary>
        ///// Init values for Currency spinner
        ///// </summary>
        //private void InitCurrencySpinnerValues()
        //{
        //    string[] items = Resources.GetStringArray(Resource.Array.currency_entries);

        //    _currencySpinnerItemModelList = new List<SpinnerItemModel>();

        //    for (int i = 0; i < items.Length; i++)
        //    {
        //        SpinnerItemModel item = new SpinnerItemModel
        //        {
        //            Id = (i + 1) + "",
        //            TEXT = items[i] + "",
        //            STATE = false
        //        };
        //        _currencySpinnerItemModelList.Add(item);
        //    }
        //}

        ///// <summary>
        ///// Set Currency spinner adapter
        ///// </summary>
        //private void SetCurrencySpinnerAdapter()
        //{
        //    _currencySpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
        //           _currencySpinnerItemModelList);
        //    spin_currency.Adapter = _currencySpinnerAdapter;
        //}



        //private void InitializeListeners()
        //{
        //    // Customer Spinner
        //    spin_customer.ItemSelected += (sender, args) =>
        //    {
        //        _selectedCustomerItem = _customerSpinnerItemModelList[args.Position];

        //        _customerSpinnerItemModelList[args.Position].STATE = true;
        //        // update spinner item list state
        //        for (int i = 0; i < _customerSpinnerItemModelList.Count; i++)
        //        {
        //            if (i == args.Position)
        //            {
        //                _customerSpinnerItemModelList[i].STATE = true;
        //            }
        //            else
        //            {
        //                _customerSpinnerItemModelList[i].STATE = false;
        //            }
        //        }
        //        _customerSpinnerAdapter.NotifyDataSetChanged();
        //    };


        //    // User Spinner
        //    spin_currency.ItemSelected += (sender, args) =>
        //    {
        //        _selectedCurrencyItem = _currencySpinnerItemModelList[args.Position];
        //        _currencySpinnerItemModelList[args.Position].STATE = true;
        //        // update spinner item list state
        //        for (int i = 0; i < _currencySpinnerItemModelList.Count; i++)
        //        {
        //            if (i == args.Position)
        //            {
        //                _currencySpinnerItemModelList[i].STATE = true;
        //            }
        //            else
        //            {
        //                _currencySpinnerItemModelList[i].STATE = false;
        //            }
        //        }
        //        _currencySpinnerAdapter.NotifyDataSetChanged();
        //    };
        //}




        //private void Btn_next_Click(object sender, EventArgs e)
        //{
        //    StartActivity(new Intent(this, typeof(AddOrderSecondActivity)));
        //    OverridePendingTransition(Resource.Animation.animation_enter,
        //                Resource.Animation.animation_leave);
        //}

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Android.Resource.Id.Home:
        //            Finish();
        //            break;

        //    }
        //    return true;
        //}


        ///// <summary>
        ///// Shows Date picker for start Date time
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Txt_order_date_val_Click(object sender, EventArgs e)
        //{
        //    DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime date)
        //    {
        //        try
        //        {
        //            if (date.Date < DateTime.Now.Date)
        //            {
        //                UtilityDroid.GetInstance().ShowAlertDialog(mActivity,
        //                    Resources.GetString(Resource.String.error_alert_title),
        //                    Resources.GetString(Resource.String.alert_message_not_less_than_current_date),
        //                    Resources.GetString(Resource.String.alert_cancel_btn),
        //                    Resources.GetString(Resource.String.alert_ok_btn));
        //            }
        //            else
        //            {
        //                orderDateTime = date;
        //                txt_order_date_val.Text = date.ToShortDateString();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }, orderDateTime);
        //    frag.Show(FragmentManager, DatePickerFragment.TAG);
        //}




    }

}

