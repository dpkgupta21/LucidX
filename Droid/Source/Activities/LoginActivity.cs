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
using System.Xml;
using System.Linq;
using LucidX.Webservices;

namespace LucidX.Droid.Source.Activities
{
    [Activity(Label = "LucidX", Icon = "@mipmap/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class LoginActivity : Activity
    {
        private string username;
        private string password;
        private Activity mActivity;
        private SharedPreferencesManager mSharedPreferencesManager;
        private EditText edt_username;
        private EditText edt_password;

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

            Spinner spin_language = FindViewById<Spinner>(Resource.Id.spin_language);
            string preferenceLang = mSharedPreferencesManager.GetString(ConstantsDroid.APP_LANG_PREFERENCE, ConstantsDroid.LANG_ENGLISH_CODE);
            spin_language.SetSelection((preferenceLang.Equals(ConstantsDroid.LANG_ENGLISH_CODE)) ? 0 : 1);
            HelpMe.SetLocale(preferenceLang, mActivity);
            spin_language.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spin_language_ItemSelected);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btn_login);
            button.Click += Button_Click;

            edt_username = FindViewById<EditText>(Resource.Id.edt_username);
            edt_password = FindViewById<EditText>(Resource.Id.edt_password);

            username = mSharedPreferencesManager.GetString(ConstantsDroid.USERNAME_PREFERENCE, "");
            password = mSharedPreferencesManager.GetString(ConstantsDroid.PASSWORD_PREFERENCE, "");

            edt_username.Text = username;
            edt_password.Text = password;

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

                    if (ValidateForm())
                    {

                        CheckBox chk_remember_me = FindViewById<CheckBox>(Resource.Id.chk_remember_me);
                        if (chk_remember_me.Checked)
                        {
                            mSharedPreferencesManager.PutString(ConstantsDroid.USERNAME_PREFERENCE, username);
                            mSharedPreferencesManager.PutString(ConstantsDroid.PASSWORD_PREFERENCE, password);
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
            catch (Exception ex)
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

