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

namespace NativePortable.Droid.Api
{
    public class FragmentRealm : Fragment
    {
        EditText etId;
        EditText etName;
        EditText etLastName;
        EditText etAge;
        EditText etPhone;
        EditText etMail;
        Spinner spinnerDB;
        IPersonDAO db;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_test, container, false);

            etId       = view.FindViewById<EditText>(Resource.Id.main_activity_etId);
            etName     = view.FindViewById<EditText>(Resource.Id.main_activity_etName);
            etLastName = view.FindViewById<EditText>(Resource.Id.main_activity_etLastName);
            etAge      = view.FindViewById<EditText>(Resource.Id.main_activity_etAge);
            etPhone    = view.FindViewById<EditText>(Resource.Id.main_activity_etPhone);
            etMail     = view.FindViewById<EditText>(Resource.Id.main_activity_etMail);
            spinnerDB = view.FindViewById<Spinner>(Resource.Id.main_activity_spinnerDB);

            string[] dbTypes = new string[] { "Realm", "SQLite" };
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerItem, dbTypes);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerDB.Adapter = adapter;
            spinnerDB.Prompt = "DB Type";
            spinnerDB.ItemSelected += SpinnerDB_ItemSelected;

            Button bCreate = view.FindViewById<Button>(Resource.Id.main_activity_bCreate);
            Button bRead = view.FindViewById<Button>(Resource.Id.main_activity_bRead);
            Button bUpdate = view.FindViewById<Button>(Resource.Id.main_activity_bUpdate);
            Button bDelete = view.FindViewById<Button>(Resource.Id.main_activity_bDelete);
            Button bReadAll = view.FindViewById<Button>(Resource.Id.main_activity_bReadAll);

            bCreate.Click += CRUD_Click;
            bRead.Click   += CRUD_Click;
            bUpdate.Click += CRUD_Click;
            bDelete.Click += CRUD_Click;
            bReadAll.Click += CRUD_Click;

            return view;
        }

        private void SpinnerDB_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    {
                        db = new RealmDB();
                        break;
                    }
                case 1:
                    {
                        db = new SQLiteDB();
                        break;
                    }
                default:
                    break;
            }
        }

        private Person GetPerson()
        {
            return new Person()
            {
                Id = Convert.ToInt32(etId.Text),
                Name = etName.Text,
                LastName = etLastName.Text,
                Age = Convert.ToInt32(etAge.Text == "" ? "0" : etAge.Text),
                Phone = etPhone.Text,
                Mail = etMail.Text
            };
        }
        private void SetPerson(Person p)
        {
            etId.Text = p.Id.ToString();
            etName.Text = p.Name;
            etLastName.Text = p.LastName;
            etAge.Text = p.Age.ToString();
            etPhone.Text = p.Phone;
            etMail.Text = p.Mail;
        }

        private void CRUD_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Text.ToUpper())
            {
                case "CREATE":
                    {
                        db.Create(GetPerson());
                        break;
                    }
                case "READ":
                    {
                        Person p = db.Read(Convert.ToInt32(etId.Text));
                        SetPerson(p);
                        break;
                    }
                case "READ ALL":
                    {
                        List<Person> p = db.ReadAll().ToList();
                        FragmentDAOView fragment = new FragmentDAOView(p);
                        FragmentTransaction transaction = FragmentManager.BeginTransaction();
                        transaction.Replace(Resource.Id.main_activity_frame, fragment);
                        transaction.Commit();
                        break;
                    }
                case "UPDATE":
                    {
                        db.Update(GetPerson());
                        break;
                    }
                case "DELETE":
                    {
                        db.Delete(GetPerson());
                        break;
                    }
                default:
                    break;
            }
        }

    }
}