using Android.Views;
using Android.Widget;
using Android.App;
using Object = Java.Lang.Object;
using System.Collections.Generic;
using LucidX.ResponseModels;

namespace LucidX.Droid.Source.Adapters
{
    public class AddOrderAdapter : BaseAdapter<LedgerOrderItem>
    {
        private LayoutInflater mLayoutInflater;
        public List<LedgerOrderItem> orderList { get; set; }
        private Activity mActivity;


        private class ViewHolder : Object
        {
            public TextView txt_item_description { get; set; }
            public TextView txt_account_name { get; set; }
            public TextView txt_base_amount { get; set; }
            public TextView txt_tax_amount { get; set; }
        }

        public AddOrderAdapter(List<LedgerOrderItem> orderList, Activity mActivity)
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
                holder.txt_account_name = convertView.FindViewById<TextView>
                    (Resource.Id.txt_account_name);
                holder.txt_base_amount = convertView.FindViewById<TextView>
                  (Resource.Id.txt_base_amount);
                holder.txt_tax_amount = convertView.FindViewById<TextView>
                   (Resource.Id.txt_tax_amount);

                convertView.Tag = holder;
            }
            else
            {
                holder = (ViewHolder)convertView.Tag;
            }
            holder.txt_item_description.Text = orderList[position].LineDescription;
            holder.txt_account_name.Text = orderList[position].AccountName;
            holder.txt_base_amount.Text = string.Format("{0:F2}",
                orderList[position].BaseAmount) + "";
            holder.txt_tax_amount.Text = string.Format("{0:F2}",
                orderList[position].TaxAmount) + "";

            return convertView;
        }

        public override int Count
        {
            get
            {
                return orderList.Count;
            }
        }

        public override LedgerOrderItem this[int position]
        {
            get
            {
                return orderList[position];
            }
        }

    }
}

