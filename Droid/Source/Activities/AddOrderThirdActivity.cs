
using Android.OS;
using Android.Views;
using System;
using Android.Support.V7.App;
using Android.Widget;
using Android.App;
using Android.Graphics;
using Android.Content;

namespace LucidX.Droid.Source.Activities
{
    [Activity(Label = "LucidX", Icon = "@mipmap/icon", Theme = "@style/AppTheme",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AddOrderThirdActivity : AppCompatActivity
    {
         
        /// <summary>
        /// The toolbar
        /// </summary>
        private Android.Support.V7.Widget.Toolbar toolbar;
        private Activity mActivity;
        private TextView txt_order_date_val;
        private DateTime orderDateTime = DateTime.Now;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_add_third_order);

            mActivity = this;

          
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
            // Init toolbar
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.add_order_title);
            ApplyFontForToolbarTitle();
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            Button btn_ok = FindViewById<Button>(Resource.Id.btn_ok);
            btn_ok.Click += Btn_ok_Click;

            Button btn_cancel = FindViewById<Button>(Resource.Id.btn_cancel);
            btn_cancel.Click += Btn_cancel_Click;

        }


        public void ApplyFontForToolbarTitle()
        {
            for (int i = 0; i < toolbar.ChildCount; i++)
            {
                View view = toolbar.GetChildAt(i);
                if (view is TextView)
                {
                    TextView tv = (TextView)view;
                    Typeface titleFont = Typeface.
                       CreateFromAsset(mActivity.Assets, "Fonts/century-gothic.ttf");
                    if (tv.Text.Equals(toolbar.Title))
                    {
                        tv.Typeface = titleFont;
                        break;
                    }
                }
            }
        }


        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            Finish();
            Intent intent = new Intent(this, typeof(HomeActivity));
            intent.PutExtra("addOrder", true);
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.animation_enter,
                        Resource.Animation.animation_leave);
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            Finish();
            Intent intent = new Intent(this, typeof(HomeActivity));
            intent.PutExtra("addOrder", true);
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.animation_enter,
                        Resource.Animation.animation_leave);
        }

   

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;

            }
            return true;
        }

    }

}

