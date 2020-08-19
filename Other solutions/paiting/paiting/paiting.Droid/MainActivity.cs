using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using paiting.Droid.Api;

namespace paiting.Droid 
{

    [Activity (Label = "paiting.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
    {
        private DrawView draw;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //draw = new DrawView(this);
            //draw.SetBackgroundColor(Color.White);
           // SetContentView(draw);

            SetContentView(Resource.Layout.Main);

            FragmentTransaction ft = FragmentManager.BeginTransaction();
            FragmentDraw canvasFragment = new FragmentDraw();

            ft.Add(Resource.Layout.Main, canvasFragment, "calcFr");
            ft.Commit();
        }
    }
}


