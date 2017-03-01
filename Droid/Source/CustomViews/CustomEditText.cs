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
using Android.Content.Res;
using Android.Util;
using Android.Graphics;

namespace LucidX.Droid.Source.CustomViews
{
    /// <summary>
    /// Custom Edit Text, provides customization of Andoird Widget Edit Text
    /// </summary>
    public class CustomEditText :EditText
    {

        public CustomEditText(Context context, IAttributeSet attrs, int defStyle): base(context, attrs, defStyle)
        {
           
            if (!IsInEditMode)
            {
                init(attrs);
            }
        }

        public CustomEditText(Context context, IAttributeSet attrs): base(context, attrs)
        {
           
            if (!IsInEditMode)
            {
                init(attrs);
            }
        }

        public CustomEditText(Context context) :  base(context)
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
                TypedArray a = Context.ObtainStyledAttributes(attrs, Resource.Styleable.CustomEditText);
                String fontName = a.GetString(Resource.Styleable.CustomEditText_editTextFontName);
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