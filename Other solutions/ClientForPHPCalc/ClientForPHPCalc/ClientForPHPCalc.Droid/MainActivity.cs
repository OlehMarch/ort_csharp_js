using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ClientForPHPCalc.Droid
{
	[Activity (Label = "ClientForPHPCalc.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        EditText etValue1;
        EditText etValue2;
        EditText etOperation;
        Button bCalc;
        Http_Connection httpConnection;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
            
            etValue1 = FindViewById<EditText>(Resource.Id.et_value1);
            etValue2 = FindViewById<EditText>(Resource.Id.et_value2);
            etOperation = FindViewById<EditText>(Resource.Id.et_operation);
            bCalc = FindViewById<Button>(Resource.Id.button_calculate);

            httpConnection = new Http_Connection(FindViewById(Android.Resource.Id.Content), "192.168.10.228");

            bCalc.Click += BCalc_Click;

		}

        private void BCalc_Click(object sender, EventArgs e)
        {
            httpConnection.Send(
                Convert.ToInt32(etValue1.Text),
                Convert.ToInt32(etValue2.Text),
                etOperation.Text
            );
        }
    }
}


