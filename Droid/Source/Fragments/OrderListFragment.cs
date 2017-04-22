
using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;
using LucidX.Droid.Source.Adapters;
using LucidX.Droid.Source.Activities;
using Android.Support.V4.App;
using Activity = Android.App.Activity;
using LucidX.Droid.Source.Picker;
using LucidX.Droid.Source.Utilities;
using LucidX.Droid.Source.Models;

namespace LucidX.Droid.Source.Fragments
{
    /// <summary>
    /// Class OrderListFragment.
    /// </summary>
    public class OrderListFragment : Fragment
    {

        /// <summary>
        /// The tag
        /// </summary>
        private const string TAG = "OrderListFragment";
        /// <summary>
        /// The expandable view
        /// </summary>
        private ListView listView;
        /// <summary>
        /// The run list adapter
        /// </summary>
        private OrderAdapter mAdapter;
        /// <summary>
        /// The m activity
        /// </summary>
        private Activity mActivity;

        private View view;
        private TextView txt_from_date;
        private TextView txt_to_date;

        private DateTime fromDateTime = DateTime.Now;
        private DateTime toDateTime = DateTime.Now;

        #region "Functions"
        public static Fragment GetInstance()
        {
            OrderListFragment fragment = new OrderListFragment();
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.fragment_order_list, container, false);
            HasOptionsMenu = true;

            mActivity = Activity;

            txt_from_date = view.FindViewById<TextView>(
                Resource.Id.txt_from_date);
            txt_from_date.Click += Edt_from_date_Click;

            txt_to_date = view.FindViewById<TextView>(
                Resource.Id.txt_to_date);
            txt_to_date.Click += Edt_to_date_Click;

            ((HomeActivity)mActivity).SetTitle(GetString(Resource.String.order_title));

            return view;
        }




        /// <summary>
        /// Initializes the contents of the Activity's standard options menu
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="inflater"></param>
        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.menu_calendar, menu);

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_add:
                    // Show Add event screen
                    mActivity.StartActivity(new Intent(mActivity, typeof(AddOrderFirstActivity)));
                    mActivity.OverridePendingTransition(Resource.Animation.animation_enter,
                                Resource.Animation.animation_leave);
                    break;
            }
            return true;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            listView = view.FindViewById<ListView>(Resource.Id.listview_order);
            InitailizeOrderListAdapter(GetOrderListModel());
            listView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int pos = e.Position;
            StartActivity(new Intent(mActivity, typeof(AddOrderFirstActivity)));
            mActivity.OverridePendingTransition(Resource.Animation.animation_enter,
                        Resource.Animation.animation_leave);
        }

        private List<OrderListModel> GetOrderListModel()
        {
            List<OrderListModel> orderList = new List<OrderListModel>();
            for (int i = 0; i < 5; i++)
            {
                OrderListModel orderObj = new OrderListModel
                {
                    Customer = "Pankaj" + i,
                    OrderDate = "2" + i + " March 2017",
                    Cost = i + "000 $"
                };
                orderList.Add(orderObj);
            }
            return orderList;
        }

        /// <summary>
        /// Sets Calendar event list in listview using adapter,
        /// In case of no events "No Events" will be displayed
        /// </summary>
        /// <param name="CalendarListObj">List of run</param>
        private void InitailizeOrderListAdapter(List<OrderListModel> orderList)
        {
            try
            {
                if (orderList != null && orderList.Count > 0)
                {

                    mAdapter = new OrderAdapter(orderList, mActivity);
                    listView.Adapter = mAdapter;

                }
            }
            catch (Exception e)
            {
            }
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


