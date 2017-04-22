using Android.Views;
using Android.Widget;
using Android.App;
using Object = Java.Lang.Object;
using LucidX.Droid.Source.Models;
using System.Collections.Generic;

namespace LucidX.Droid.Source.Adapters
{
    public class NotesListAdapter : BaseAdapter<NotesListModel>
    {
        private LayoutInflater mLayoutInflater;
        private List<NotesListModel> notesList;
        private Activity mActivity;


        private class ViewHolder : Object
        {
            public TextView txt_notes_date { get; set; }
            public TextView txt_notes { get; set; }
     

        }

        public NotesListAdapter(List<NotesListModel> notesList, Activity mActivity)
        {
            mLayoutInflater = (LayoutInflater)mActivity
                 .GetSystemService(Activity.LayoutInflaterService);
            this.notesList = notesList;
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

                convertView = mLayoutInflater.Inflate(Resource.Layout.individual_item_notes,
                    parent, false);
                holder.txt_notes_date = convertView.FindViewById<TextView>
                    (Resource.Id.txt_notes_date);
                holder.txt_notes = convertView.FindViewById<TextView>
                    (Resource.Id.txt_notes);
              

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
                return notesList.Count;
            }
        }

        public override NotesListModel this[int position]
        {
            get
            {
                return notesList[position];
            }
        }

    }
}

