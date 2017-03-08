
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using LucidX.ResponseModels;
using System;
using System.Collections.Generic;

namespace LucidX.Droid.Source.Adapters
{
    public class InboxAdapter : RecyclerView.Adapter
    {
        private List<EmailResponse> data;
        public event EventHandler<int> ItemClick;
        private Context context;
        public class InboxViewHolder : RecyclerView.ViewHolder
        {
            public View viewMain;
            public TextView txt_email_address;
            public TextView txt_email_detail;
            public TextView txt_email_time;
            public TextView txt_img_lbl;
            public ImageView img_attachment_icon;
            public ImageView img_delete_icon;
            public InboxViewHolder(View view, Action<int> itemClickListener) : base(view)
            {
                viewMain = view;
                txt_email_address = (TextView)view.FindViewById(Resource.Id.txt_email_address);
                txt_email_detail = (TextView)view.FindViewById(Resource.Id.txt_email_detail);
                txt_email_time = (TextView)view.FindViewById(Resource.Id.txt_email_time);
                txt_img_lbl = (TextView)view.FindViewById(Resource.Id.txt_img_lbl);
                img_attachment_icon = (ImageView)view.FindViewById(Resource.Id.img_attachment_icon);
                img_delete_icon = (ImageView)view.FindViewById(Resource.Id.img_delete_icon);

            }
        }

        public InboxAdapter(Context context)
        {
            this.context = context;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var vi = LayoutInflater.From(parent.Context);
            var view = vi.Inflate(Resource.Layout.Individual_Item_Email, parent, false);

            return new InboxViewHolder(view, OnItemClickListener);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holderRaw, int position)
        {

            var holder = (InboxViewHolder)holderRaw;
            holder.viewMain.Tag = position;

            EmailResponse dto = data[position];
            holder.txt_email_address.Text = dto.SenderEmail;
            holder.txt_email_detail.Text = dto.Subject;
        }

        public void SetData(List<EmailResponse> data)
        {
            this.data = data;
        }

      

        public override int ItemCount
        {
            get
            {
                return data.Count;
            }
        }

        public List<EmailResponse> GetData()
        {
            return data;
        }

        void OnItemClickListener(int position)
        {
            if (ItemClick != null)
            {
                ItemClick(this, position);
            }
        }

       
    }
}