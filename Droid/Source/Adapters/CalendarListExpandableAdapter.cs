
using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using LucidX.ResponseModels;
using Android.Content;
using LucidX.Droid.Source.Activities;

namespace LucidX.Droid.Source.Adapters
{
    public class CalendarListExpandableAdapter : BaseExpandableListAdapter

    {
        /// <summary>
        /// The tag
        /// </summary>
        public string TAG = "CalendarListExpandableAdapter";
        /// <summary>
        /// Activity object
        /// </summary>
        readonly Activity mActivity;
      

        /// <summary>
        /// ViewHolder for child view
        /// </summary>
        private ViewHolderChild holder;

        
        /// <summary>
        /// Calendar Event list object
        /// </summary>
        public List<CalendarEventResponse> CalendarListObj { get;  set; }


        /// <summary>
        /// Constructor of CalendarListExpandableAdapter having two params
        /// </summary>
        /// <param name="MActivity">Context of the class</param>
        /// <param name="CalendarListObj">List of Calendar events</param>
        public CalendarListExpandableAdapter(Activity mActivity, 
            List<CalendarEventResponse> CalendarListObj) : base()
        {
            this.mActivity = mActivity;
            this.CalendarListObj = CalendarListObj;

        }


        /// <summary>
        /// Sets Calendar list occurs than this method displays the changes on the screen
        /// </summary>
        /// <param name="CalendarListObj">Having list of Calendar event</param>
        public void SetCalendarList(List<CalendarEventResponse> CalendarListObj)
        {
            this.CalendarListObj = CalendarListObj;
            NotifyDataSetChanged();

        }

        /// <summary>
        /// Sets layout of the group at the specified groupPosition
        /// </summary>
        /// <param name="groupPosition">Gives position of the group</param>
        /// <param name="isExpanded"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns>view of the group</returns>
        public override View GetGroupView(int groupPosition, bool isExpanded,
            View convertView, ViewGroup parent)
        {
            View mView = convertView;
            ViewHolderGroup holder = null;
            if (mView == null)
            {
                holder = new ViewHolderGroup();
                mView = mActivity.LayoutInflater.Inflate(Resource.Layout.calendar_group_item, null);

                holder.TxtCalendarDate = mView.FindViewById<TextView>(Resource.Id.txt_calendar_date_val);
                mView.Tag = holder;
            }
            else
            {
                holder = (ViewHolderGroup)mView.Tag;
            }

            try
            {
                ((ExpandableListView)parent).ExpandGroup(groupPosition);

                holder.TxtCalendarDate.Text = CalendarListObj[groupPosition].DisplayDate;
            }

            catch (Exception e)
            {

            }

            return mView;

        }

        /// <summary>
        /// Sets the child of every group according to their values
        /// sets the value in the childView like JobName,JobNo, DateTime, Address
        /// </summary>
        /// <param name="groupPosition">It gives the group position</param>
        /// <param name="childPosition">It gives the child position</param>
        /// <param name="isLastChild">It tells whether child is the last child or not</param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns>view of the child</returns>
        public override View GetChildView(int groupPosition, int childPosition, 
            bool isLastChild, View convertView, ViewGroup parent)
        {

            View mView = convertView;
            holder = null;

            if (mView == null)
            {
                holder = new ViewHolderChild();
                mView = mActivity.LayoutInflater.Inflate(Resource.Layout.calendar_child_item, null);

                holder.TxtEventName = mView.FindViewById<TextView>(Resource.Id.txt_event_name);
                holder.TxtEventDateTime = mView.FindViewById<TextView>(Resource.Id.txt_event_date_time);
                holder.TxtEventDetail = mView.FindViewById<TextView>(Resource.Id.txt_event_detail);
                holder.childHorizontalSeperator = mView.FindViewById<View>
                    (Resource.Id.child_horizontal_seperator);

                mView.Tag = holder;
            }
            else
            {
                holder = (ViewHolderChild)mView.Tag;
            }

            try
            {
                List<EventResponse> eventList = CalendarListObj[groupPosition].EventListResponse;
                EventResponse eventObj = eventList[childPosition];
                holder.TxtEventName.Tag = groupPosition + ":" + childPosition;
                holder.TxtEventDateTime.Text = eventObj.EventDateTime;
                holder.TxtEventName.Text = eventObj.EventName;
                holder.TxtEventDetail.Text = eventObj.EventDetail;

                if (!mView.HasOnClickListeners)
                {
                    mView.Click += OnChildViewClick;
                }


                if (childPosition < (eventList.Count - 1))
                {
                    holder.childHorizontalSeperator.Visibility = ViewStates.Visible;
                }
                else
                {
                    holder.childHorizontalSeperator.Visibility = ViewStates.Gone;
                }

            }

            catch (Exception e)
            {
            }

            return mView;

        }


        /// <summary>
        /// Clicks the child view tabbed activity get open which is having 4 tabs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnChildViewClick(object sender, EventArgs args)
        {
            try
            {
                View view = (View)sender;
                ViewHolderChild viewholder = (ViewHolderChild)view.Tag;
                string tag = viewholder.TxtEventName.Tag.ToString();
                string[] pos = tag.Split(':');
                int groupPosition = Int32.Parse(pos[0]);
                int childPosition = Int32.Parse(pos[1]);

                // Show Add event screen
                Intent intent = new Intent(mActivity, typeof(AddCalendarEventActivity));
                intent.PutExtra("isAddEvent", false);
                mActivity.StartActivity(intent);
                mActivity.OverridePendingTransition(Resource.Animation.animation_enter,
                            Resource.Animation.animation_leave);

            }
            catch (Exception e1)
            {
            }
        }


     

        /// <summary>
        /// Returns the count of child in the group  
        /// according to the group postion
        /// </summary>
        /// <param name="groupPosition">Gives the groupPosition</param>
        /// <returns>count of the child</returns>
        public override int GetChildrenCount(int groupPosition)
        {
            List<EventResponse> results = CalendarListObj[groupPosition].EventListResponse;
            return results.Count;
        }

        /// <summary>
        /// Returns count of group
        /// </summary>
        public override int GroupCount
        {
            get
            {
                return CalendarListObj.Count;
            }
        }


    

        #region implemented abstract members of BaseExpandableListAdapter
        /// <summary>
        /// Return Child 
        /// </summary>
        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Return child position
        /// </summary>
        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }
        /// <summary>
        /// Returns group position
        /// </summary>
        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return null;

        }
        /// <summary>
        /// Sets child selectable
        /// </summary>
        public override long GetGroupId(int groupPosition)
        {

            return groupPosition;
        }


        /// <summary>
        /// Sets child selectable
        /// </summary>
        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            Console.WriteLine("groupPosition :" + groupPosition + "\nchildPosition :" + childPosition);
            return true;
            //throw new NotImplementedException ();
        }



        public override bool HasStableIds
        {
            get
            {
                return true;
            }
        }



        public class ViewHolderGroup : Java.Lang.Object
        {
            public TextView TxtCalendarDate { get; set; }

        }

        public class ViewHolderChild : Java.Lang.Object
        {
            public TextView TxtEventName { get; set; }
            public TextView TxtEventDateTime { get; set; }
            public TextView TxtEventDetail { get; set; }
            public LinearLayout parentContainer { get; set; }
            public View childHorizontalSeperator { get; set; }
        }

        #endregion
    }


}

