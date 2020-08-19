using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multichat_Server.Lobby
{
    public static class MessageLogger
    {
        public static string CheckExistanse(string name1, string name2)
        {
            string res = String.Empty;

            if (File.Exists(name1 + name2))
            {
                res = name1 + name2;
            }
            else if (File.Exists(name2 + name1))
            {
                res = name2 + name1;
            }
            else
            {
                res = null;
            }

            return res;
        }

        public static void LogToFile(string roomName, string message)
        {
            try
            {
                roomName = roomName.Remove(roomName.IndexOf("("));
                roomName = roomName.TrimEnd();
            }
            catch { }

            var sw = File.AppendText(roomName);
            sw.WriteLine(message);
            sw.Dispose();
        }

        public static string ReadFromFile(string roomName)
        {
            try
            {
                roomName = roomName.Remove(roomName.IndexOf("("));
                roomName = roomName.TrimEnd();
            }
            catch { }

            if (File.Exists(roomName))
            {
                string res = String.Empty;
                res = File.ReadAllText(roomName);
                return res.Replace("\r\n", ",");
            }
            else
            {
                return String.Empty;
            }
        }

    }
}
