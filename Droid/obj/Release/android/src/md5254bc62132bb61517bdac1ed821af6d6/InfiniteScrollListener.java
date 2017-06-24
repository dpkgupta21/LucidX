package md5254bc62132bb61517bdac1ed821af6d6;


public class InfiniteScrollListener
	extends android.support.v7.widget.RecyclerView.OnScrollListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrolled:(Landroid/support/v7/widget/RecyclerView;II)V:GetOnScrolled_Landroid_support_v7_widget_RecyclerView_IIHandler\n" +
			"";
		mono.android.Runtime.register ("LucidX.Droid.Source.Adapters.InfiniteScrollListener, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", InfiniteScrollListener.class, __md_methods);
	}


	public InfiniteScrollListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == InfiniteScrollListener.class)
			mono.android.TypeManager.Activate ("LucidX.Droid.Source.Adapters.InfiniteScrollListener, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onScrolled (android.support.v7.widget.RecyclerView p0, int p1, int p2)
	{
		n_onScrolled (p0, p1, p2);
	}

	private native void n_onScrolled (android.support.v7.widget.RecyclerView p0, int p1, int p2);

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
