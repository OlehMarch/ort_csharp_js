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
using Java.Lang;

namespace NativePortable.Droid.Api.Adapter
{
    public class AdapterPerson : BaseAdapter
    {
        private List<Person> personList;
        private LayoutInflater layoutInflater;
        private Context context;

        public AdapterPerson(Context context, List<Person> personList)
        {
            this.context = context;
            this.layoutInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            this.personList = personList;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView ?? layoutInflater.Inflate(Resource.Layout.adapter_item, parent, false);

            TextView tvId = view.FindViewById<TextView>(Resource.Id.adapter_item_tvId);
            TextView tvName = view.FindViewById<TextView>(Resource.Id.adapter_item_tvName);
            TextView tvLastName = view.FindViewById<TextView>(Resource.Id.adapter_item_tvLastName);
            TextView tvAge = view.FindViewById<TextView>(Resource.Id.adapter_item_tvAge);
            TextView tvPhone = view.FindViewById<TextView>(Resource.Id.adapter_item_tvPhone);
            TextView tvMail = view.FindViewById<TextView>(Resource.Id.adapter_item_tvMail);

            Person p = personList[position];
            tvId.Text = p.Id.ToString();
            tvName.Text = p.Name;
            tvLastName.Text = p.LastName;
            tvAge.Text = p.Age.ToString();
            tvPhone.Text = p.Phone;
            tvMail.Text = p.Mail;

            return view;
        }

        public override int Count
        {
            get
            {
                return personList.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

    }
}