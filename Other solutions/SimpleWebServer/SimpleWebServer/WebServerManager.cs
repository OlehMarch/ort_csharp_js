using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleWebServer
{
    public class WebServerManager
    {
        private HttpListener server;
        private Thread threadListen;

        public WebServerManager()
        {
            Initialize();
            server.Prefixes.Add("http://127.0.0.1:1300/");
        }

        public WebServerManager(string serverPrefix)
        {
            Initialize();
            server.Prefixes.Add(serverPrefix);
        }

        public void StartServer()
        {
            server.Start();
        }

        public void StopServer()
        {
            server.Stop();
        }

        public void StartSniffing()
        {
            threadListen.Start();
        }

        public void StopSniffing()
        {
            threadListen.Abort();
        }

        private void Initialize()
        {
            server = new HttpListener();
            threadListen = new Thread(new ThreadStart(Sniffing));
        }

        private void Sniffing()
        {
            while (true)
            {
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
}
