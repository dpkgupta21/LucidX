using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using LucidX.Droid.Source.SharedPreference;
using LucidX.Droid.Source.Utilities;
using LucidX.Constants;
using System;
using LucidX.Droid.Source.Global;

namespace LucidX.Droid.Source.Activities
{
    [Activity(Label = "LucidX",  Icon = "@mipmap/icon", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SplashScreenActivity : Activity
    {
        private Activity mActivity;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_splash);

            mActivity = this;
        }

        protected override void OnResume()
        {
            base.OnResume();

            /// Shared Preference manager
            SharedPreferencesManager mSharedPreferencesManager = UtilityDroid.GetInstance().
                       GetSharedPreferenceManagerWithEncriptionEnabled(mActivity.ApplicationContext);
            string encryptToken = Utils.Utilities.GetEncryptedToken(WebserviceConstants.TOKEN);
            mSharedPreferencesManager.PutString(ConstantsDroid.ENCRYPT_TOKEN_PREFERENCE, "");

            var handler = new Handler();
            Action myAction = () =>
            {
                StartActivity(new Intent(this, typeof(LoginActivity)));
                OverridePendingTransition(Resource.Animation.animation_enter,
                            Resource.Animation.animation_leave);
                Finish();
            };
            handler.PostDelayed(myAction, 2000);
        }



    }

}

