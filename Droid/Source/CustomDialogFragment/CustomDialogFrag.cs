
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using LucidX.Droid.Source.CustomDialogFragment.Adapter;
using LucidX.Droid.Source.Fragments;
using LucidX.Droid.Source.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Activity = Android.App.Activity;
namespace LucidX.Droid.Source.CustomDialogFragment
{

    public class CustomDialogFrag : DialogFragment
    {
        private View mView;
        private Activity mActivity;
        private CheckboxDialogAdapter mAdapter;

        public static CustomDialogFrag NewInstance()
        {
            var fragment = new CustomDialogFrag();
            return fragment;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mView = inflater.Inflate(Resource.Layout.dialog_list_fragment, container, false);

            mActivity = Activity;
            
            Dialog.SetTitle( Resource.String.select_calendar_type);
            Dialog.SetCancelable(false); //dismiss window on touch outside

            return mView;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            Button btn_save = mView.FindViewById<Button>(Resource.Id.btn_save);
            btn_save.Click += Btn_save_Click;

            // Set Adapter
            SetAdapter();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try {

                List<UserListModel> selectedUserList = mAdapter.userList.
                    Where(x => x.IsSelected == true).ToList();
                string selectedUserListObj = JsonConvert.SerializeObject(selectedUserList);

                // result back to calling class
                Intent intent = new Intent();
                intent.PutExtra("selectedUserListObj", selectedUserListObj);
                     
                Dismiss();
            }catch(Exception ex)
            {

            }
        }

        private void SetAdapter()
        {
            ListView listView = mView.FindViewById<ListView>(Resource.Id.listview);

            mAdapter = new CheckboxDialogAdapter
                (GetUserListModel(), mActivity);
            listView.Adapter = mAdapter;
        }
        private List<UserListModel> GetUserListModel()
        {
            string[] calendarTypes = Resources.GetStringArray(Resource.Array.calendar_entries);
            List<UserListModel> userList = new List<UserListModel>();
            for(int i = 0; i < calendarTypes.Count(); i++)
            {
                UserListModel userObj = new UserListModel
                {
                    UserName = calendarTypes[i]
                };

                userList.Add(userObj);
            }

            return userList;

        }
    }
}