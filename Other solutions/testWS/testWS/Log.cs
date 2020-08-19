using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWS
{
    public static class LogManager
    {
        private static string pathToLog = "path.log";

        public static void AddToLog(string name, string data)
        {
            var message = DateTime.Now.ToString() + " - " + name + ": " + data;
            StreamWriter sw = File.AppendText(pathToLog);
            sw.Write(message);
            sw.Dispose();
        }
    }
}
