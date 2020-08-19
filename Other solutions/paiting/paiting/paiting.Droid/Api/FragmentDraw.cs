using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace paiting.Droid.Api
{
    public class FragmentDraw : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            FrameLayout linearLayout = (FrameLayout)inflater.Inflate(Resource.Layout.Draw_layout, container, false);
            linearLayout.AddView(new DrawView(this.Activity));

            return linearLayout;
        }
    }
}