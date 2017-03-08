
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using LucidX.Droid.Source.Fragments;
using LucidX.Droid.Source.Adapters;
using System;
using LucidX.Webservices;
using LucidX.Droid.Source.SharedPreference;
using LucidX.Droid.Source.Global;
using Plugin.Connectivity;
using LucidX.ResponseModels;
using LucidX.Droid.Source.Utilities;
using LucidX.Droid.Source.CustomViews;

namespace LucidX.Droid.Source.Activities
{

    [Activity(Label = "HomeActivity", MainLauncher = true, Theme = "@style/AppTheme", Icon = "@mipmap/icon",
        ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize)]
    public class HomeActivity : AppCompatActivity, MenuAdapter.OnItemClickListener
    {
        private DrawerLayout _drawerLayout;


        /// <summary>
        /// The drawer toggle
        /// </summary>
        private MyActionBarDrawerToggle drawerToggle;
        /// <summary>
        /// The toolbar
        /// </summary>
        private Android.Support.V7.Widget.Toolbar toolbar;

        private string[] mMenuNames, mMenuIcons;

        private MenuAdapter mAdapter;

        private Activity mActivity;

        private SharedPreferencesManager mSharedPreferencesManager;

        private EmailCountResponse emailCountDTO;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            mActivity = this;

            /// Shared Preference manager
            mSharedPreferencesManager = UtilityDroid.GetInstance().
                       GetSharedPreferenceManagerWithEncriptionEnabled(mActivity.ApplicationContext);


            // Init toolbar
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.menu_title);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            SetupSideMenu();

            Android.Support.V4.App.Fragment fragment = InboxFragment.GetInstance();
            addFrament(fragment, false);
        }


        private async void GetEmailCounts()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    
                    EmailCountResponse emailCount = await WebServiceMethods.
                        EmailCount(mSharedPreferencesManager.GetString(ConstantsDroid.USER_ID_PREFERENCE, ""));

                    if (emailCount != null)
                    {
                        mAdapter.emailCount = emailCount;
                        mAdapter.NotifyDataSetChanged();
                    }

                }
            }
            catch (Exception e)
            {
                CustomProgressDialog.HideProgressDialog();
                UtilityDroid.GetInstance().ShowAlertDialog(mActivity, Resources.GetString(Resource.String.error_alert_title),
                   Resources.GetString(Resource.String.alert_message_error),
                   Resources.GetString(Resource.String.alert_cancel_btn), Resources.GetString(Resource.String.alert_ok_btn));


            }
        }
        /// <summary>
        /// Setups the side menu.
        /// </summary>
        /// <returns>The side menu.</returns>
        private void SetupSideMenu()
        {
            ListView menuListView = FindViewById<ListView>(Resource.Id.listview);
            mMenuNames = Resources.GetStringArray(Resource.Array.menu_array);
            mMenuIcons = Resources.GetStringArray(Resource.Array.menu_icon_array);

            mAdapter = new MenuAdapter(mMenuNames, mMenuIcons, this, this);

            // set up the drawer's list view with items and click listener
            menuListView.Adapter = mAdapter;

            drawerToggle = new MyActionBarDrawerToggle(this,
                _drawerLayout, toolbar,
                Resource.String.open_drawer,
                Resource.String.close_drawer);
            _drawerLayout.AddDrawerListener(drawerToggle);

            SupportActionBar.SetDisplayShowHomeEnabled(true);

            drawerToggle.SyncState();
            drawerToggle.DrawerIndicatorEnabled = true;

            // Call Email Count webservice
            GetEmailCounts();
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            Android.Support.V4.App.Fragment currentFragment = GetCurrentFragment();
            if (currentFragment.GetType() == typeof(InboxFragment))
            {
                //((AlertSendFragment)currentFragment).ResetAlertScreen("", false);
            }
        }

        /// <summary>
        /// Get current visible fragment
        /// </summary>
        /// <returns>Current Fragment</returns>
        public Android.Support.V4.App.Fragment GetCurrentFragment()
        {
            return SupportFragmentManager.FindFragmentById(Resource.Id.frame_container);
        }

        /// <summary>
        /// Class MyActionBarDrawerToggle.
        /// </summary>
        internal class MyActionBarDrawerToggle : ActionBarDrawerToggle
        {
            /// <summary>
            /// The owner
            /// </summary>
            HomeActivity owner;

            /// <summary>
            /// Initializes a new instance of the <see cref="MyActionBarDrawerToggle"/> class.
            /// </summary>
            /// <param name="activity">The activity.</param>
            /// <param name="layout">The layout.</param>
            /// <param name="toolbar">The toolbar.</param>
            /// <param name="openRes">The open resource.</param>
            /// <param name="closeRes">The close resource.</param>
            public MyActionBarDrawerToggle(HomeActivity activity,
                DrawerLayout layout,
                Android.Support.V7.Widget.Toolbar toolbar,
                int openRes,
                int closeRes)
                    : base(activity, layout, toolbar, openRes, closeRes)
            {
                owner = activity;
            }

            /// <summary>
            /// Called when [drawer closed].
            /// </summary>
            /// <param name="drawerView">The drawer view.</param>
            public override void OnDrawerClosed(View drawerView)
            {
                //owner.ActionBar.Title = owner.Title;
                //owner.InvalidateOptionsMenu();
            }

            /// <summary>
            /// Called when [drawer opened].
            /// </summary>
            /// <param name="drawerView">The drawer view.</param>
            public override void OnDrawerOpened(View drawerView)
            {
                //owner.ActionBar.Title = owner.mDrawerTitle;
                //owner.InvalidateOptionsMenu();
            }
        }


        public class MenuHandler : Handler
        {

            private const string TAG = "MenuHandler";
            public static WeakReference<HomeActivity> homeActivity;

            public MenuHandler(HomeActivity activity)
            {
                homeActivity = new WeakReference<HomeActivity>(activity);
            }


            public override void HandleMessage(Message msg)
            {
                HomeActivity activity = null;
                homeActivity.TryGetTarget(out activity);
                
            }

        }


        /// <summary>
        /// Adds the frament.
        /// </summary>
        /// <param name="fragment">The fragment.</param>
        /// <param name="addBackstack">if set to <c>true</c> [add backstack].</param>
        public void addFrament(Android.Support.V4.App.Fragment fragment, bool addBackstack)
        {
            var ft = SupportFragmentManager.BeginTransaction();
            if (addBackstack)
            {
                ft.Add(Resource.Id.frame_container, fragment, fragment.Class.Name);
                ft.AddToBackStack(fragment.Class.Name);
            }
            else
            {
                ft.Replace(Resource.Id.frame_container, fragment, fragment.Class.Name);
            }

            ft.Commit();
        }

        public void OnClick(View view, int position)
        {
            throw new NotImplementedException();
        }
    }
}