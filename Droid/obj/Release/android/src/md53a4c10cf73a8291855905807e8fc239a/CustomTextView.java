package md53a4c10cf73a8291855905807e8fc239a;


public class CustomTextView
	extends android.widget.TextView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("LucidX.Droid.Source.CustomViews.CustomTextView, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CustomTextView.class, __md_methods);
	}


	public CustomTextView (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CustomTextView.class)
			mono.android.TypeManager.Activate ("LucidX.Droid.Source.CustomViews.CustomTextView, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public CustomTextView (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == CustomTextView.class)
			mono.android.TypeManager.Activate ("LucidX.Droid.Source.CustomViews.CustomTextView, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomTextView (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == CustomTextView.class)
			mono.android.TypeManager.Activate ("LucidX.Droid.Source.CustomViews.CustomTextView, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}