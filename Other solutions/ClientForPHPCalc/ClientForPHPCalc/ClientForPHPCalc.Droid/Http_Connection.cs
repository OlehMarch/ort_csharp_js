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
using Java.Net;
using Java.IO;
using System.IO;


namespace ClientForPHPCalc.Droid
{
    public class Http_Connection
    {
        private static string urlString;
        private static string urlQuery;
        private static View view;

        public Http_Connection(View v, string hostIp)
        {
            view = v;
            urlString = "http://" + hostIp + "/calcApi/calculatorAPI.php";
        }

        public void Send(int value1, int value2, string operation)
        {
            urlQuery = "?value1=" + value1 + "&value2=" + value2 + "&operation=" + operation;
            HttpRequest req = new HttpRequest();
            req.Execute();
        }

        public class HttpRequest : AsyncTask
        {
            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                HttpURLConnection urlConnection = null;
                BufferedReader reader = null;
                string line = null;

                try
                {
                    URL url = new URL(urlString + urlQuery);
                    urlConnection = (HttpURLConnection)url.OpenConnection();
                    urlConnection.RequestMethod = "GET";
                    urlConnection.Connect();

                    Stream inputStream = urlConnection.InputStream;

                    if (inputStream != null)
                    {
                        reader = new BufferedReader(new InputStreamReader(inputStream));
                        line = reader.ReadLine();
                    }
                }
                catch (System.IO.IOException e)
                {
                    //Log.e("PlaceholderFragment", "Error ", e);
                }
                finally
                {
                    if (urlConnection != null)
                    {
                        urlConnection.Disconnect();
                    }
                    if (reader != null)
                    {
                        try
                        {
                            reader.Close();
                        }
                        catch (System.IO.IOException e)
                        {
                            //Log.e("PlaceholderFragment", "Error closing stream", e);
                        }
                    }
                }

                return line;
            }

            protected override void OnPostExecute(Java.Lang.Object result)
            {
                base.OnPostExecute(result);
                EditText res = (EditText)view.FindViewById(Resource.Id.et_result);
                res.Text = Convert.ToString(result);
            }
        }

    }
}