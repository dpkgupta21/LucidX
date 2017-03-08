
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Support.V4.Widget;
using LucidX.Droid.Source.SharedPreference;
using Plugin.Connectivity;
using System;
using LucidX.Droid.Source.Adapters;
using LucidX.ResponseModels;
using System.Collections.Generic;
using LucidX.Droid.Source.CustomViews;
using LucidX.Webservices;
using LucidX.Droid.Source.Utilities;
using LucidX.Droid.Source.Global;

namespace LucidX.Droid.Source.Fragments
{
    public class InboxFragment : Fragment
    {
        #region "Constructor"
        public InboxFragment()
        {
        }
        #endregion

        private View view;
        private RecyclerView rvInbox;
        private SwipeRefreshLayout refresher;
        private TextView tvPullRefresh;
        private LinearLayoutManager layoutManager;
        private InboxAdapter mAdapter;
        private Android.App.Activity mActivity;
        private SharedPreferencesManager mSharedPreferencesManager;



        #region "Functions"
        public static Fragment GetInstance()
        {
            InboxFragment fragment = new InboxFragment();
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /// <summary>
        /// Returns fragment alert screen view
        /// </summary>
        /// <param name="inflater"></param>
        /// <param name="container"></param>
        /// <param name="savedInstanceState"></param>
        /// <returns></returns>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.Fragment_Inbox, container, false);

            mActivity = Activity;

            /// Shared Preference manager
            mSharedPreferencesManager = UtilityDroid.GetInstance().
                       GetSharedPreferenceManagerWithEncriptionEnabled(mActivity.ApplicationContext);

            Init();
            return view;
        }

        /// <summary>
        /// Method use to initialize resources.
        /// </summary>
        private void Init()
        {
            rvInbox = (RecyclerView)view.FindViewById(Resource.Id.rvCompaign);

            // improve performance by indicating the list if fixed size.
            rvInbox.HasFixedSize = true;

            layoutManager = new LinearLayoutManager(Activity);
            rvInbox.SetLayoutManager(layoutManager);


            refresher = view.FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);

            tvPullRefresh = (TextView)view.FindViewById(Resource.Id.tvRefresh);

            refresher.Refresh += Refresher_Refresh;

            InfiniteScrollListener infiniteScrollListener = new InfiniteScrollListener(layoutManager, LoadMore);
            rvInbox.AddOnScrollListener(infiniteScrollListener);

        }
        /// <summary>
        /// Initalize alert send screen view
        /// </summary>
        /// <param name="savedInstanceState"></param>
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            GetInboxList();
        }

        private async void GetInboxList()
        {
            try
            {
                List<EmailResponse> responseList = null;
                if (CrossConnectivity.Current.IsConnected)
                {
                    CustomProgressDialog.ShowProgDialog(mActivity, mActivity.Resources.GetString(Resource.String.loading));

                    responseList = await WebServiceMethods.InboxEmails(mSharedPreferencesManager.
                        GetString(ConstantsDroid.USER_ID_PREFERENCE, "12013"));

                    SetInboxList(responseList);

                    CustomProgressDialog.HideProgressDialog();
                }
                else
                {
                    UtilityDroid.GetInstance().ShowAlertDialog(mActivity, Resources.GetString(Resource.String.error_alert_title),
                        Resources.GetString(Resource.String.alert_message_no_network_connection),
                        Resources.GetString(Resource.String.alert_cancel_btn), Resources.GetString(Resource.String.alert_ok_btn));
                }
            }
            catch (Exception ex)
            {
                CustomProgressDialog.HideProgressDialog();
                UtilityDroid.GetInstance().ShowAlertDialog(mActivity, Resources.GetString(Resource.String.error_alert_title),
                   Resources.GetString(Resource.String.alert_message_error),
                   Resources.GetString(Resource.String.alert_cancel_btn), Resources.GetString(Resource.String.alert_ok_btn));
            }

           
        }

        /// <summary>
        /// Method use for load more when user scroll to end of list.
        /// </summary>
        private void LoadMore()
        {
            //GetCampaignList(RecordType.Prev);
        }

        async private void Refresher_Refresh(object sender, System.EventArgs e)
        {
            // LOADING YOUR DATA.
            // GetCampaignList(RecordType.Next);

        }

        /// Method use to set campaign list data into recycler view.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="recordType"></param>
        public void SetInboxList(List<EmailResponse> data)
        {
            if (mAdapter == null)
            {
                mAdapter = new InboxAdapter(Activity);
                mAdapter.ItemClick += MAdapter_ItemClick;
                mAdapter.SetData(data);
                rvInbox.SetAdapter(mAdapter);
            }
            else
            {

                mAdapter.NotifyDataSetChanged();
            }

            if (mAdapter.GetData() != null && mAdapter.GetData().Count > 0)
            {
                rvInbox.Visibility = ViewStates.Visible;
                tvPullRefresh.Visibility = ViewStates.Gone;
            }
            else
            {
                rvInbox.Visibility = ViewStates.Gone;
                tvPullRefresh.Visibility = ViewStates.Visible;
            }
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            throw new NotImplementedException();
        }





        #endregion
    }
}