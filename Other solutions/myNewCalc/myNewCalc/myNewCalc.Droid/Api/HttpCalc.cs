using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace myNewCalc.Droid
{
    public class HttpCalc
    {
        public static async Task<string> Execute(int value1, int value2, string operation)
        {
            HttpApi httpApi = new HttpApi();
            string res = await httpApi.Send(value1, value2, operation);
            return res;
        }
    }
}