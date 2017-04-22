using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using LucidX.ResponseModels;
using LucidX.Droid.Source.Utilities;
using LucidX.Droid.Source.SharedPreference;
using LucidX.Droid.Source.Global;
using System;
using Plugin.Connectivity;
using LucidX.Droid.Source.CustomViews;
using Android.Content;
using LucidX.Webservices;
using LucidX.Droid.Source.CustomSpinner.Model;
using System.Collections.Generic;
using LucidX.Droid.Source.CustomSpinner.Adapter;

namespace LucidX.Droid.Source.Activities
{
    [Activity(Label = "LucidX", Theme = "@style/AppTheme", Icon = "@mipmap/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class LoginActivity : Activity
    {
        private string username;
        private string password;
        private Activity mActivity;
        private SharedPreferencesManager mSharedPreferencesManager;
        private EditText edt_username;
        private EditText edt_password;
        private CheckBox chk_remember_me;
        private RadioGroup radio_group;

        private Spinner spin_language;
        private SpinnerItemModel _selectedLanguageItem;
        private SpinnerAdapter _languageSpinnerAdapter;
        private List<SpinnerItemModel> _languageSpinnerItemModelList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);

            mActivity = this;


            /// Shared Preference manager
            mSharedPreferencesManager = UtilityDroid.GetInstance().
                       GetSharedPreferenceManagerWithEncriptionEnabled(mActivity.ApplicationContext);

         
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btn_login);
            button.Click += Button_Click;

            edt_username = FindViewById<EditText>(Resource.Id.edt_username);
            edt_password = FindViewById<EditText>(Resource.Id.edt_password);
            chk_remember_me = FindViewById<CheckBox>(Resource.Id.chk_remember_me);
            radio_group= FindViewById<RadioGroup>(Resource.Id.radio_group);

            RadioButton radio_btn_db_demo = FindViewById<RadioButton>(Resource.Id.radio_btn_db_demo);
            RadioButton radio_btn_db_saas = FindViewById<RadioButton>(Resource.Id.radio_btn_db_saas);
            RadioButton radio_btn_db_hq = FindViewById<RadioButton>(Resource.Id.radio_btn_db_hq);
            RadioButton radio_btn_db_lucid = FindViewById<RadioButton>(Resource.Id.radio_btn_db_lucid);
            radio_btn_db_demo.Checked = true;

            username = mSharedPreferencesManager.GetString(ConstantsDroid.USERNAME_PREFERENCE, "");
            password = mSharedPreferencesManager.GetString(ConstantsDroid.PASSWORD_PREFERENCE, "");
            string databaseName= mSharedPreferencesManager.GetString(ConstantsDroid.DATABASE_PREFERENCE, "");
            
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                chk_remember_me.Checked = true;
                edt_username.Text = username;
                edt_password.Text = password;
                if (databaseName.Equals(GetString(Resource.String.db_saas)))
                {
                    radio_btn_db_saas.Checked = true;
                }
                else if (databaseName.Equals(GetString(Resource.String.db_demo)))
                {
                    radio_btn_db_demo.Checked = true;
                }
                else if (databaseName.Equals(GetString(Resource.String.db_hq)))
                {
                    radio_btn_db_hq.Checked = true;
                }
                else
                {
                    radio_btn_db_lucid.Checked = true;
                }
            }

            spin_language = FindViewById<Spinner>(Resource.Id.spin_language);


            // Set Language in spinner
            InitLanguageSpinnerValues();
            SetLanguageSpinnerAdapter();

            // Initialize listener for spinner
            InitializeListeners();


            string preferenceLang = mSharedPreferencesManager.GetString(ConstantsDroid.APP_LANG_PREFERENCE, ConstantsDroid.LANG_ENGLISH_CODE);
            spin_language.SetSelection((preferenceLang.Equals(ConstantsDroid.LANG_ENGLISH_CODE)) ? 0 : 1);
            HelpMe.SetLocale(preferenceLang, mActivity);

        }

        /// <summary>
        /// Init values for User spinner
        /// </summary>
        private void InitLanguageSpinnerValues()
        {
            string[] items = Resources.GetStringArray(Resource.Array.language_entries);

            _languageSpinnerItemModelList = new List<SpinnerItemModel>();

            for (int i = 0; i < items.Length; i++)
            {
                SpinnerItemModel item = new SpinnerItemModel
                {
                    Id = (i + 1) + "",
                    TEXT = items[i] + "",
                    STATE = false
                };
                _languageSpinnerItemModelList.Add(item);
            }
        }

        /// <summary>
        /// Set Language spinner adapter
        /// </summary>
        private void SetLanguageSpinnerAdapter()
        {
            _languageSpinnerAdapter = new SpinnerAdapter(mActivity, Resource.Layout.spinner_row_item_lay,
                   _languageSpinnerItemModelList);
            spin_language.Adapter = _languageSpinnerAdapter;
        }



        private void InitializeListeners()
        {
           


            // User Spinner
            spin_language.ItemSelected += (sender, args) =>
            {
                _selectedLanguageItem = _languageSpinnerItemModelList[args.Position];

             
                _languageSpinnerItemModelList[args.Position].STATE = true;
                // update spinner item list state
                for (int i = 0; i < _languageSpinnerItemModelList.Count; i++)
                {
                    if (i == args.Position)
                    {
                        _languageSpinnerItemModelList[i].STATE = true;
                    }
                    else
                    {
                        _languageSpinnerItemModelList[i].STATE = false;
                    }
                }
                _languageSpinnerAdapter.NotifyDataSetChanged();

                
                string selectedItem = _selectedLanguageItem.TEXT.ToString();
                if (!selectedItem.Equals(mSharedPreferencesManager.GetString(ConstantsDroid.APP_LANG_PREFERENCE, "")))
                {
                    mSharedPreferencesManager.PutString(ConstantsDroid.APP_LANG_PREFERENCE, selectedItem);

                    HelpMe.SetLocale(selectedItem, mActivity);

                    StartActivity(typeof(LoginActivity));
                    OverridePendingTransition(Resource.Animation.animation_enter,
                               Resource.Animation.animation_leave);
                    Finish();
                }

            };
        }






        private void Spin_language_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string selectedItem = spinner.GetItemAtPosition(e.Position).ToString();
            if (!selectedItem.Equals(mSharedPreferencesManager.GetString(ConstantsDroid.APP_LANG_PREFERENCE, "")))
            {
                mSharedPreferencesManager.PutString(ConstantsDroid.APP_LANG_PREFERENCE, selectedItem);

                HelpMe.SetLocale(selectedItem, mActivity);

                StartActivity(typeof(LoginActivity));
                OverridePendingTransition(Resource.Animation.animation_enter,
                           Resource.Animation.animation_leave);
                Finish();
            }
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {

                    CustomProgressDialog.ShowProgDialog(mActivity, Resources.GetString(Resource.String.loading));

                    username = edt_username.Text;
                    password = edt_password.Text;
                    int selectedRadioBtnId =  radio_group.CheckedRadioButtonId;
                    RadioButton radioBtn = FindViewById<RadioButton>(selectedRadioBtnId);
                    if (ValidateForm())
                    {                        
                        if (chk_remember_me.Checked)
                        {
                            mSharedPreferencesManager.PutString(ConstantsDroid.USERNAME_PREFERENCE, username);
                            mSharedPreferencesManager.PutString(ConstantsDroid.PASSWORD_PREFERENCE, password);
                            mSharedPreferencesManager.PutString(ConstantsDroid.DATABASE_PREFERENCE, radioBtn.Text);
                        }
                        else
                        {
                            mSharedPreferencesManager.PutString(ConstantsDroid.USERNAME_PREFERENCE, "");
                            mSharedPreferencesManager.PutString(ConstantsDroid.PASSWORD_PREFERENCE, "");
                        }

                        //UtilityDroid.GetInstance().ShowToast(mActivity, "Before Print", ToastLength.Long);

                        LoginResponse loginResponse = await WebServiceMethods.Login(username, password);
                        //UtilityDroid.GetInstance().ShowToast(mActivity, "After Print"+ finalResponse.StatusCode, ToastLength.Long);

                        if (loginResponse != null)
                        {


                            if (loginResponse.IsAuthenticate)
                            {
                                mSharedPreferencesManager.PutLoginResponse(loginResponse);
                                mSharedPreferencesManager.PutString(ConstantsDroid.USER_ID_PREFERENCE, loginResponse.UserId);

                                CustomProgressDialog.HideProgressDialog();
                                StartActivity(new Intent(this, typeof(HomeActivity)));
                                OverridePendingTransition(Resource.Animation.animation_enter,
                                            Resource.Animation.animation_leave);
                                Finish();
                            }
                            else
                            {
                                CustomProgressDialog.HideProgressDialog();
                                UtilityDroid.GetInstance().ShowAlertDialog(mActivity, Resources.GetString(Resource.String.error_alert_title),
                                    Resources.GetString(Resource.String.alert_message_invalid_credentials),
                                    Resources.GetString(Resource.String.alert_cancel_btn), Resources.GetString(Resource.String.alert_ok_btn));

                            }
                        }
                        else
                        {
                            CustomProgressDialog.HideProgressDialog();
                            UtilityDroid.GetInstance().ShowAlertDialog(mActivity, Resources.GetString(Resource.String.error_alert_title),
                  Resources.GetString(Resource.String.alert_message_invalid_credentials),
                  Resources.GetString(Resource.String.alert_cancel_btn), Resources.GetString(Resource.String.alert_ok_btn));
                        }

                    }
                    else
                    {
                        CustomProgressDialog.HideProgressDialog();
                        UtilityDroid.GetInstance().ShowAlertDialog(mActivity, Resources.GetString(Resource.String.error_alert_title),
                               Resources.GetString(Resource.String.alert_message_enter_username_and_password),
                               Resources.GetString(Resource.String.alert_cancel_btn), Resources.GetString(Resource.String.alert_ok_btn));
                    }
                }
                else
                {
                    UtilityDroid.GetInstance().ShowAlertDialog(mActivity, Resources.GetString(Resource.String.error_alert_title),
                        Resources.GetString(Resource.String.alert_message_no_network_connection),
                        Resources.GetString(Resource.String.alert_cancel_btn), Resources.GetString(Resource.String.alert_ok_btn));
                }
            }
            catch (Exception)
            {
                CustomProgressDialog.HideProgressDialog();
                UtilityDroid.GetInstance().ShowAlertDialog(mActivity, Resources.GetString(Resource.String.error_alert_title),
                   Resources.GetString(Resource.String.alert_message_invalid_credentials),
                   Resources.GetString(Resource.String.alert_cancel_btn), Resources.GetString(Resource.String.alert_ok_btn));
            }
        }


        private bool ValidateForm()
        {

            if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return true;
        }

    }
}

