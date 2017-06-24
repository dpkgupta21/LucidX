using Android.Views;
using Android.Widget;
using Android.App;
using Object = Java.Lang.Object;
using LucidX.Droid.Source.Models;
using System.Collections.Generic;
using LucidX.ResponseModels;

namespace LucidX.Droid.Source.Adapters
{
    public class OrderAdapter : BaseAdapter<OrdersResponse>
    {
        private LayoutInflater mLayoutInflater;
        private List<OrdersResponse> orderList;
        private Activity mActivity;


        private class ViewHolder : Object
        {
            public TextView txt_order_date { get; set; }
            public TextView txt_customer { get; set; }
            public TextView txt_cost { get; set; }

        }

        public OrderAdapter(List<OrdersResponse> orderList, Activity mActivity)
        {
            mLayoutInflater = (LayoutInflater)mActivity
                 .GetSystemService(Activity.LayoutInflaterService);
            this.orderList = orderList;
            this.mActivity = mActivity;
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            ViewHolder holder = null;
            int type = GetItemViewType(position);
            if (convertView == null)
            {
                holder = new ViewHolder();

                convertView = mLayoutInflater.Inflate(Resource.Layout.individual_item_order,
                    parent, false);
                holder.txt_order_date = convertView.FindViewById<TextView>
                    (Resource.Id.txt_order_date);
                holder.txt_customer = convertView.FindViewById<TextView>
                    (Resource.Id.txt_customer);
                holder.txt_cost = convertView.FindViewById<TextView>
                   (Resource.Id.txt_cost);

                convertView.Tag = holder;
            }
            else
            {
                holder = (ViewHolder)convertView.Tag;
            }

            holder.txt_customer.Text = orderList[position].AccountName;
            holder.txt_cost.Text = "Amount: "+orderList[position].BaseAmount + "";
            holder.txt_order_date.Text=  Utils.Utilities.ShowDateInFormat(orderList[position].TransDate);

            return convertView;
        }

        public override int Count
        {
            get
            {
                return orderList.Count;
            }
        }

        public override OrdersResponse this[int position]
        {
            get
            {
                return orderList[position];
            }
        }

    }
}

