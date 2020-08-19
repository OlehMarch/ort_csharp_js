using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace myNewCalc.Droid
{
	[Activity (Label = "myNewCalc.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            FragmentTransaction ft = FragmentManager.BeginTransaction();
            Fragment calcFr = new Calc_Fragment();

            ft.Add(Resource.Id.calcLayout, calcFr, "calcFr");
            ft.Commit();
        }
	}
}


