using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener server = new HttpListener();

            server.Start();

            Console.WriteLine("Listening...");

            HttpListenerContext context = server.GetContext();
            HttpListenerResponse response = context.Response;

            string page = @"D:\server" + context.Request.Url.LocalPath;

            if (page == string.Empty)
                page = "index.html";

            try
            {
                StreamReader tr = new StreamReader(page);
                string msg = tr.ReadToEnd();

                byte[] buffer = Encoding.UTF8.GetBytes(msg);

                response.ContentLength64 = buffer.Length;
                Stream st = response.OutputStream;
                st.Write(buffer, 0, buffer.Length);
            }
            catch { }
            context.Response.Close();
        }

    }
}
