package md58865ece7961d87d6fdb04c7d0933046e;


public class HomeActivity_MenuHandler
	extends android.os.Handler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleMessage:(Landroid/os/Message;)V:GetHandleMessage_Landroid_os_Message_Handler\n" +
			"";
		mono.android.Runtime.register ("LucidX.Droid.Source.Activities.HomeActivity+MenuHandler, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", HomeActivity_MenuHandler.class, __md_methods);
	}


	public HomeActivity_MenuHandler () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HomeActivity_MenuHandler.class)
			mono.android.TypeManager.Activate ("LucidX.Droid.Source.Activities.HomeActivity+MenuHandler, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public HomeActivity_MenuHandler (android.os.Looper p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == HomeActivity_MenuHandler.class)
			mono.android.TypeManager.Activate ("LucidX.Droid.Source.Activities.HomeActivity+MenuHandler, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Looper, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	public HomeActivity_MenuHandler (md58865ece7961d87d6fdb04c7d0933046e.HomeActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == HomeActivity_MenuHandler.class)
			mono.android.TypeManager.Activate ("LucidX.Droid.Source.Activities.HomeActivity+MenuHandler, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "LucidX.Droid.Source.Activities.HomeActivity, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void handleMessage (android.os.Message p0)
	{
		n_handleMessage (p0);
	}

	private native void n_handleMessage (android.os.Message p0);

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
