using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Content.Res;
using Android.Util;

namespace LucidX.Droid.Source.CustomViews
{
    /// <summary>
    ///  Custom Text View, provides customization of Android Widget Text View
    /// </summary>
    public class CustomTextView : TextView
    {
        public CustomTextView(Context context, IAttributeSet attrs, int defStyle): base(context, attrs, defStyle)
        {           
            if (!IsInEditMode)
            {
                init(attrs);
            }
        }

        public CustomTextView(Context context, IAttributeSet attrs): base(context, attrs)
        {
            
            if (!IsInEditMode)
            {
                init(attrs);
            }

        }

        public CustomTextView(Context context): base(context)
        {
           
            if (!IsInEditMode)
            {
                init(null);
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="attrs">attributes given in layout file</param>
        private void init(IAttributeSet attrs)
        {
            if (attrs != null)
            {
                TypedArray a = Context.ObtainStyledAttributes(attrs, Resource.Styleable.CustomTextView);
                String fontName = a.GetString(Resource.Styleable.CustomTextView_textViewFontName);
                if (fontName != null)
                {
                    Typeface myTypeface = Typeface.CreateFromAsset(Context.Assets, "Fonts/" + fontName);
                    SetTypeface(myTypeface, TypefaceStyle.Normal);
                }
                a.Recycle();
            }
        }

    }
}