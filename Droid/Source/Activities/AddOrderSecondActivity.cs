
using Android.OS;
using Android.Views;
using LucidX.Droid.Source.SharedPreference;
using LucidX.Droid.Source.Utilities;
using System;
using Android.Support.V7.App;
using Android.Widget;
using LucidX.Droid.Source.CustomDialogFragment;
using Android.App;
using LucidX.Droid.Source.Models;
using System.Collections.Generic;
using Android.Content;
using LucidX.Droid.Source.Adapters;
using Android.Graphics;

namespace LucidX.Droid.Source.Activities
{
    [Activity(Label = "LucidX", Icon = "@mipmap/icon", Theme = "@style/AppTheme",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AddOrderSecondActivity : AppCompatActivity
    {
         
        /// <summary>
        /// The toolbar
        /// </summary>
        private Android.Support.V7.Widget.Toolbar toolbar;
        private Activity mActivity;
        private SharedPreferencesManager mSharedPreferencesManager;
        private DateTime orderDateTime = DateTime.Now;
        private List<OrderAddModel> addOrderList = new List<OrderAddModel>();
        private AddOrderAdapter mAdapter;
        private ListView lstView;
        private TextView txt_no_list;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_add_second_order);

            mActivity = this;

            /// Shared Preference manager
            mSharedPreferencesManager = UtilityDroid.GetInstance().
                       GetSharedPreferenceManagerWithEncriptionEnabled(mActivity.ApplicationContext);
            try
            {
                Init();
                InitializeAdapter();

            }
            catch (Exception e)
            {

            }
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

            lstView = FindViewById<ListView>(Resource.Id.listview);

            txt_no_list = FindViewById<TextView>(Resource.Id.txt_no_list);
            Button btn_add_order = FindViewById<Button>(Resource.Id.btn_add_order);
            btn_add_order.Click += Btn_add_order_Click; ;

            Button btn_next = FindViewById<Button>(Resource.Id.btn_next);
            btn_next.Click += Btn_next_Click;
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

        private void Btn_add_order_Click(object sender, EventArgs e)
        {
            Android.Support.V4.App.FragmentTransaction fragmentTransaction = SupportFragmentManager.BeginTransaction();

            //remove fragment from backstack if any exists
            Android.Support.V4.App.Fragment fragmentPrev = SupportFragmentManager.FindFragmentByTag("dialog");
            if (fragmentPrev != null)
                fragmentTransaction.Remove(fragmentPrev);

            fragmentTransaction.AddToBackStack(null);
            //create and show the dialog
            OrderAddDialogFrag dialogFragment = OrderAddDialogFrag.NewInstance();
            dialogFragment.Show(fragmentTransaction, "dialog");
        }

        private void Btn_next_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(AddOrderThirdActivity)));
            OverridePendingTransition(Resource.Animation.animation_enter,
                        Resource.Animation.animation_leave);
        }

        public void Add(OrderAddModel orderAddModel)
        {
            addOrderList.Add(orderAddModel);
            InitializeAdapter();
        }


        private void InitializeAdapter() {
            if(addOrderList!=null && addOrderList.Count != 0)
            {
                txt_no_list.Visibility = ViewStates.Gone;
                if (mAdapter == null)
                {
                    mAdapter = new AddOrderAdapter(addOrderList, mActivity);
                    lstView.Adapter = mAdapter;
                }
                else
                {
                    mAdapter.orderList = addOrderList;
                    mAdapter.NotifyDataSetChanged();
                }
            }
            else
            {
                txt_no_list.Visibility = ViewStates.Visible;

            }
           
        }
    }
  
}

