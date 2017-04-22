
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
using LucidX.Droid.Source.CustomSpinner.Model;
using LucidX.Droid.Source.CustomSpinner.Adapter;

namespace LucidX.Droid.Source.Fragments
{
    /// <summary>
    /// Class NotesListFragment.
    /// </summary>
    public class NotesListFragment : Fragment
    {

        /// <summary>
        /// The tag
        /// </summary>
        private const string TAG = "NotesListFragment";
        /// <summary>
        /// The expandable view
        /// </summary>
        private ListView listView;
        /// <summary>
        /// The run list adapter
        /// </summary>
        private NotesListAdapter mAdapter;
        /// <summary>
        /// The m activity
        /// </summary>
        private Activity mActivity;

        private View view;
        private TextView txt_from_date;
        private TextView txt_to_date;

        private Spinner spin_account_code;
        private SpinnerItemModel _selectedAccountCodeItem;
        private SpinnerAdapter _accountCodeSpinnerAdapter;
        private List<SpinnerItemModel> _accountCodeSpinnerItemModelList;

        private Spinner spin_current_entity;
        private SpinnerItemModel _selectedCurrentEntitysItem;
        private SpinnerAdapter _entitySpinnerAdapter;
        private List<SpinnerItemModel> _entitySpinnerItemModelList;


        private DateTime fromDateTime = DateTime.Now;
        private DateTime toDateTime = DateTime.Now;

        #region "Functions"
        public static Fragment GetInstance()
        {
            NotesListFragment fragment = new NotesListFragment();
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.fragment_notes_list, container, false);
            HasOptionsMenu = true;

            mActivity = Activity;

            spin_current_entity = view.FindViewById<Spinner>(
              Resource.Id.spin_current_entity);
            spin_account_code = view.FindViewById<Spinner>(
             Resource.Id.spin_account_code);

            txt_from_date = view.FindViewById<TextView>(
                Resource.Id.txt_from_date);
            txt_from_date.Click += Edt_from_date_Click;

            txt_to_date = view.FindViewById<TextView>(
                Resource.Id.txt_to_date);
            txt_to_date.Click += Edt_to_date_Click;

            ((HomeActivity)mActivity).SetTitle(GetString(Resource.String.notes_title));

            // Set Current Entity in Spinner
            InitEntitySpinnerValues();
            SetEntitySpinnerAdapter();

            // Set Account Code in Spinner
            InitAccountCodeSpinnerValues();
            SetAccountCodeSpinnerAdapter();

            // Initialize listener for spinner
            InitializeListeners();

            return view;
        }

        /// <summary>
        /// Init values for Current Entity spinner
        /// </summary>
        private void InitEntitySpinnerValues()
        {
            List<string> entityItems = new List<string> { "Select Current Entity", "Entity1",
                "Entity2", "Entity3"};

            _entitySpinnerItemModelList = new List<SpinnerItemModel>();

            for (int i = 0; i < entityItems.Count; i++)
            {
                SpinnerItemModel item = new SpinnerItemModel
                {
                    Id = (i + 1) + "",
                    TEXT = entityItems[i] + "",
                    STATE = false
                };

                _entitySpinnerItemModelList.Add(item);
            }
        }




        /// <summary>
        /// Set Current Entity spinner adapter
        /// </summary>
        private void SetEntitySpinnerAdapter()
        {
            _entitySpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
                   _entitySpinnerItemModelList);
            spin_current_entity.Adapter = _entitySpinnerAdapter;
        }



        /// <summary>
        /// Init values for Account Code spinner
        /// </summary>
        private void InitAccountCodeSpinnerValues()
        {
            List<string> accountCodeItems = new List<string> { "Select Account Code", "Account Code1",
                "Account Code2", "Account Code2" };

            _accountCodeSpinnerItemModelList = new List<SpinnerItemModel>();

            for (int i = 0; i < accountCodeItems.Count; i++)
            {
                SpinnerItemModel item = new SpinnerItemModel
                {
                    Id = (i + 1) + "",
                    TEXT = accountCodeItems[i] + "",
                    STATE = false
                };
                _accountCodeSpinnerItemModelList.Add(item);
            }
        }

        /// <summary>
        /// Set Account Code spinner adapter
        /// </summary>
        private void SetAccountCodeSpinnerAdapter()
        {
            _accountCodeSpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
                   _accountCodeSpinnerItemModelList);
            spin_account_code.Adapter = _accountCodeSpinnerAdapter;
        }



        private void InitializeListeners()
        {
            // Current Entity Spinner
            spin_current_entity.ItemSelected += (sender, args) =>
            {
                _selectedCurrentEntitysItem = _entitySpinnerItemModelList[args.Position];

                _entitySpinnerItemModelList[args.Position].STATE = true;
                // update spinner item list state
                for (int i = 0; i < _entitySpinnerItemModelList.Count; i++)
                {
                    if (i == args.Position)
                    {
                        _entitySpinnerItemModelList[i].STATE = true;
                    }
                    else
                    {
                        _entitySpinnerItemModelList[i].STATE = false;
                    }
                }
                _entitySpinnerAdapter.NotifyDataSetChanged();
            };


            // Account Code Spinner
            spin_account_code.ItemSelected += (sender, args) =>
            {
                _selectedAccountCodeItem = _accountCodeSpinnerItemModelList[args.Position];
                _accountCodeSpinnerItemModelList[args.Position].STATE = true;
                // update spinner item list state
                for (int i = 0; i < _accountCodeSpinnerItemModelList.Count; i++)
                {
                    if (i == args.Position)
                    {
                        _accountCodeSpinnerItemModelList[i].STATE = true;
                    }
                    else
                    {
                        _accountCodeSpinnerItemModelList[i].STATE = false;
                    }
                }
                _accountCodeSpinnerAdapter.NotifyDataSetChanged();
            };
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
                    // Show Add Notes screen
                    Intent intent = new Intent(mActivity, typeof(AddNotesActivity));
                    intent.PutExtra("isAddNote", true);
                    mActivity.StartActivity(intent);
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
            InitailizeOrderListAdapter(GetNotesListModel());
            listView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int pos = e.Position;

            Intent intent = new Intent(mActivity, typeof(AddNotesActivity));
            intent.PutExtra("isAddNote", false);
            mActivity.StartActivity(intent);
            mActivity.OverridePendingTransition(Resource.Animation.animation_enter,
                        Resource.Animation.animation_leave);
        }

        private List<NotesListModel> GetNotesListModel()
        {
            List<NotesListModel> notesList = new List<NotesListModel>();
            for (int i = 0; i < 5; i++)
            {
                NotesListModel noteObj = new NotesListModel
                {
                    Notes = "Pankaj" + i,
                    NotesDate = "2" + i + " March 2017",
                    Cost = i + "000 $"
                };
                notesList.Add(noteObj);
            }
            return notesList;
        }

        /// <summary>
        /// Sets Calendar event list in listview using adapter,
        /// In case of no events "No Events" will be displayed
        /// </summary>
        /// <param name="CalendarListObj">List of run</param>
        private void InitailizeOrderListAdapter(List<NotesListModel> notesList)
        {
            try
            {
                if (notesList != null && notesList.Count > 0)
                {

                    mAdapter = new NotesListAdapter(notesList, mActivity);
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


