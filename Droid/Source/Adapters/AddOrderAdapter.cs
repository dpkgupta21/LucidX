using Android.Views;
using Android.Widget;
using Android.App;
using Object = Java.Lang.Object;
using LucidX.Droid.Source.Models;
using System.Collections.Generic;

namespace LucidX.Droid.Source.Adapters
{
    public class AddOrderAdapter : BaseAdapter<OrderAddModel>
    {
        private LayoutInflater mLayoutInflater;
        public List<OrderAddModel> orderList { get; set; }
        private Activity mActivity;


        private class ViewHolder : Object
        {
            public TextView txt_item_description { get; set; }
            public TextView txt_revenue_account { get; set; }
            public TextView txt_amount { get; set; }

        }

        public AddOrderAdapter(List<OrderAddModel> orderList, Activity mActivity)
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

                convertView = mLayoutInflater.Inflate(Resource.Layout.individual_add_order,
                    parent, false);
                holder.txt_item_description = convertView.FindViewById<TextView>
                    (Resource.Id.txt_item_description);
                holder.txt_revenue_account = convertView.FindViewById<TextView>
                    (Resource.Id.txt_revenue_account);
                holder.txt_amount = convertView.FindViewById<TextView>
                   (Resource.Id.txt_amount);

                convertView.Tag = holder;
            }
            else
            {
                holder = (ViewHolder)convertView.Tag;
            }

            return convertView;
        }

        public override int Count
        {
            get
            {
                return orderList.Count;
            }
        }

        public override OrderAddModel this[int position]
        {
            get
            {
                return orderList[position];
            }
        }

    }
}

