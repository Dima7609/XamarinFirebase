package crc642c17f07779a3ef57;


public class MyDataAdapterViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("XamarinFirebase.Adapter.MyDataAdapterViewHolder, XamarinFirebase", MyDataAdapterViewHolder.class, __md_methods);
	}


	public MyDataAdapterViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == MyDataAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("XamarinFirebase.Adapter.MyDataAdapterViewHolder, XamarinFirebase", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
