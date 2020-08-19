using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace myNewCalc
{
    public class HttpApi
    {
        public async Task<string> Send(int value1, int value2, string operation)
        {
            string query = String.Format("?a={0}&op={1}&b={2}", value1, operation, value2);
            HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create("http://37.57.92.40/calc/index.php" + query);
            wr.Method = "GET";

            using (WebResponse response = await wr.GetResponseAsync())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    return stream.ReadLine();
                }
            }
        }
    }
}
