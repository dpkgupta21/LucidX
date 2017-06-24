package md5254bc62132bb61517bdac1ed821af6d6;


public class InboxAdapter_InboxViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("LucidX.Droid.Source.Adapters.InboxAdapter+InboxViewHolder, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", InboxAdapter_InboxViewHolder.class, __md_methods);
	}


	public InboxAdapter_InboxViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == InboxAdapter_InboxViewHolder.class)
			mono.android.TypeManager.Activate ("LucidX.Droid.Source.Adapters.InboxAdapter+InboxViewHolder, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
