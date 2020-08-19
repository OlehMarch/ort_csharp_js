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
using NativePortable.Droid.Api.Adapter;

namespace NativePortable.Droid.Api
{
    public class FragmentDAOView : Fragment
    {
        private List<Person> personList;

        public FragmentDAOView(List<Person> personList)
        {
            this.personList = personList;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_dao_view, container, false);

            Button bBack = view.FindViewById<Button>(Resource.Id.dao_view_bBack);
            ListView lvPersons = view.FindViewById<ListView>(Resource.Id.dao_view_lvPersons);

            AdapterPerson adapter = new AdapterPerson(Activity, personList);
            lvPersons.Adapter = adapter;

            bBack.Click += BBack_Click;

            return view;
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            FragmentRealm fragment = new FragmentRealm();
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.main_activity_frame, fragment);
            transaction.Commit();
        }
    }
}