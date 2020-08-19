using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using NativePortable.Droid.Api;

namespace NativePortable.Droid
{
	[Activity (Label = "NativePortable.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

            FragmentRealm fragment = new FragmentRealm();
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.main_activity_frame, fragment);
            transaction.Commit();
		}
	}
}


