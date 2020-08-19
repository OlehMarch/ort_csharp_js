using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Task3_01
{
    [Activity(Label = "Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText result;
        EditText firstOperand;
        EditText secondOperand;
        EditText operation;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            result = FindViewById<EditText>(Resource.Id.et_result);
            firstOperand = FindViewById<EditText>(Resource.Id.et_firstOperand);
            secondOperand = FindViewById<EditText>(Resource.Id.et_secondOperand);
            operation = FindViewById<EditText>(Resource.Id.et_operation);
            Button buttonCalc = FindViewById<Button>(Resource.Id.buttonCalculate);

            buttonCalc.Click += delegate 
            {
                result.Text = Calculation.Calculate(
                    Convert.ToInt32(firstOperand.Text),
                    Convert.ToInt32(secondOperand.Text),
                    operation.Text
                ).ToString();
            };
        }

    }
}

