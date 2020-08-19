using System;

namespace Multichat_Client.API
{
    public class Message
    {
        public string MSG { get; set; }
        public bool Available { get; set; }

        public Message()
        {
            MSG = String.Empty;
            Available = false;
        }
    }
}