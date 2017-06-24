package md58865ece7961d87d6fdb04c7d0933046e;


public class HomeActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer,
		android.widget.ExpandableListView.OnChildClickListener,
		android.widget.ExpandableListView.OnGroupClickListener,
		android.widget.ExpandableListView.OnGroupExpandListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onSaveInstanceState:(Landroid/os/Bundle;)V:GetOnSaveInstanceState_Landroid_os_Bundle_Handler\n" +
			"n_onActivityResult:(IILandroid/content/Intent;)V:GetOnActivityResult_IILandroid_content_Intent_Handler\n" +
			"n_onChildClick:(Landroid/widget/ExpandableListView;Landroid/view/View;IIJ)Z:GetOnChildClick_Landroid_widget_ExpandableListView_Landroid_view_View_IIJHandler:Android.Widget.ExpandableListView/IOnChildClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onGroupClick:(Landroid/widget/ExpandableListView;Landroid/view/View;IJ)Z:GetOnGroupClick_Landroid_widget_ExpandableListView_Landroid_view_View_IJHandler:Android.Widget.ExpandableListView/IOnGroupClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onGroupExpand:(I)V:GetOnGroupExpand_IHandler:Android.Widget.ExpandableListView/IOnGroupExpandListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("LucidX.Droid.Source.Activities.HomeActivity, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", HomeActivity.class, __md_methods);
	}


	public HomeActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HomeActivity.class)
			mono.android.TypeManager.Activate ("LucidX.Droid.Source.Activities.HomeActivity, LucidX.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onSaveInstanceState (android.os.Bundle p0)
	{
		n_onSaveInstanceState (p0);
	}

	private native void n_onSaveInstanceState (android.os.Bundle p0);


	public void onActivityResult (int p0, int p1, android.content.Intent p2)
	{
		n_onActivityResult (p0, p1, p2);
	}

	private native void n_onActivityResult (int p0, int p1, android.content.Intent p2);


	public boolean onChildClick (android.widget.ExpandableListView p0, android.view.View p1, int p2, int p3, long p4)
	{
		return n_onChildClick (p0, p1, p2, p3, p4);
	}

	private native boolean n_onChildClick (android.widget.ExpandableListView p0, android.view.View p1, int p2, int p3, long p4);


	public boolean onGroupClick (android.widget.ExpandableListView p0, android.view.View p1, int p2, long p3)
	{
		return n_onGroupClick (p0, p1, p2, p3);
	}

	private native boolean n_onGroupClick (android.widget.ExpandableListView p0, android.view.View p1, int p2, long p3);


	public void onGroupExpand (int p0)
	{
		n_onGroupExpand (p0);
	}

	private native void n_onGroupExpand (int p0);

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
