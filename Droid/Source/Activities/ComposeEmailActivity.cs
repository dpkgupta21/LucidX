
using Android.OS;
using Android.Views;
using LucidX.Droid.Source.SharedPreference;
using LucidX.Droid.Source.Utilities;
using System;
using Android.Support.V7.App;
using LucidX.Droid.Source.Picker;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using LucidX.Droid.Source.CustomSpinner.Model;
using LucidX.Droid.Source.CustomSpinner.Adapter;
using Android.Graphics;
using Android.Webkit;
using Android.Content.Res;
using Java.IO;

namespace LucidX.Droid.Source.Activities
{
    [Activity(Label = "LucidX",  Icon = "@mipmap/icon", Theme = "@style/AppTheme",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ComposeEmailActivity : AppCompatActivity
    {

        /// <summary>
        /// The toolbar
        /// </summary>
        private Android.Support.V7.Widget.Toolbar toolbar;
        private Activity mActivity;
        private SharedPreferencesManager mSharedPreferencesManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_compose_email);

            mActivity = this;

            /// Shared Preference manager
            mSharedPreferencesManager = UtilityDroid.GetInstance().
                       GetSharedPreferenceManagerWithEncriptionEnabled(mActivity.ApplicationContext);



            try
            {
                Init();
            }
            catch (Exception e)
            {

            }
        }




        /// <summary>
        /// Init this instance.
        /// </summary>
        private void Init()
        {
        
           
            WebView mwebview = FindViewById<WebView>(Resource.Id.LocalWebView);
            mwebview.Settings.JavaScriptEnabled = true;
           
           
            mwebview.LoadUrl("file:///android_asset/jQuery-TE_v.1.4.0"+File.Separator+ "demo" + File.Separator + "demo.html"); //new.html is html file 

        }

     


       


    }

}

