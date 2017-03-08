using System;
using Android.Views;
using Android.Widget;
using Android.App;
using Object = Java.Lang.Object;
using LucidX.ResponseModels;
using Android.Content.Res;

namespace LucidX.Droid.Source.Adapters
{
    public class MenuAdapter : BaseAdapter
    {
        private LayoutInflater mLayoutInflater;
        private string[] mNames;
        private string[] mIcons;
        private OnItemClickListener mListener;
        private Activity mActivity;

        public EmailCountResponse emailCount { get; set; }
        //Associated Objects
        public interface OnItemClickListener
        {
            void OnClick(View view, int position);
        }

        private class ViewHolder : Object
        {
            public ImageView img_icon { get; set; }
            public TextView txt_menu_name { get; set; }
            public TextView txt_menu_counter { get; set; }


        }

        public MenuAdapter(string[] mNames, string[] mIcons, OnItemClickListener listener, Activity mActivity)
        {
            mLayoutInflater = (LayoutInflater)mActivity
                 .GetSystemService(Activity.LayoutInflaterService);
            this.mNames = mNames;
            this.mIcons = mIcons;
            mListener = listener;
            mActivity = listener as Activity;
        }

       

        public override Java.Lang.Object GetItem(int position)
        {
            return mNames[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            ViewHolder holder = null;
            if (convertView == null)
            {
                convertView = mLayoutInflater.Inflate(Resource.Layout.ItemMenu, parent, false);
                holder = new ViewHolder();

                holder.img_icon = convertView.FindViewById<ImageView>(Resource.Id.img_icon);
                holder.txt_menu_name = convertView.FindViewById<TextView>(Resource.Id.txt_menu_name);
                holder.txt_menu_counter = convertView.FindViewById<TextView>(Resource.Id.txt_menu_counter);

                convertView.Tag = holder;

            }
            else
            {
                holder = (ViewHolder)convertView.Tag;
            }

            //var drawableImage = mActivity.Resources.GetDrawable(mActivity.Resources.GetIdentifier(mIcons[position], "drawable", mActivity.PackageName));

            holder.img_icon.SetImageResource(Resource.Drawable.user_icon);
            holder.txt_menu_name.Text = mNames[position];
            if (emailCount != null)
            {
                if (position == 0)
                {
                    holder.txt_menu_counter.Text = emailCount.inboxCount != 0 ? emailCount.inboxCount + "" : "";
                }
                else if (position == 1)
                {
                    holder.txt_menu_counter.Text = emailCount.draftCount != 0 ? emailCount.draftCount + "" : "";
                }
                else if (position == 2)
                {
                    holder.txt_menu_counter.Text = emailCount.sentItemCount != 0 ? emailCount.sentItemCount + "" : "";
                }
                else if (position == 3)
                {
                    holder.txt_menu_counter.Text = emailCount.trashCount != 0 ? emailCount.trashCount + "" : "";
                }
            }

            return convertView;
        }



        public override int Count
        {
            get
            {
                return mNames.Length;
            }
        }
    }
}

