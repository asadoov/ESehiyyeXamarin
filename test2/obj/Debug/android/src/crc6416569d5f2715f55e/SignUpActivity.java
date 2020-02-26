package crc6416569d5f2715f55e;


public class SignUpActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_backClicked:(Landroid/view/View;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("ESehiyye.SignUpActivity, test2", SignUpActivity.class, __md_methods);
	}


	public SignUpActivity ()
	{
		super ();
		if (getClass () == SignUpActivity.class)
			mono.android.TypeManager.Activate ("ESehiyye.SignUpActivity, test2", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void backClicked (android.view.View p0)
	{
		n_backClicked (p0);
	}

	private native void n_backClicked (android.view.View p0);

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
