using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultichatVisual.API
{
    public static class ResponseFactory
    {
        public static ServerResponse GetResponse(string response)
        {
            var servResp = ServerResponse.Broadcast;
            response = response.Remove(response.IndexOf(":"));

            switch (response)
            {
                case "broadcast":
                    servResp = ServerResponse.Broadcast;
                    break;
                case "connect":
                    servResp = ServerResponse.Connect;
                    break;
                case "create":
                    servResp = ServerResponse.Create;
                    break;
                case "message":
                    servResp = ServerResponse.Message;
                    break;
                case "refresh":
                    servResp = ServerResponse.Refresh;
                    break;
                case "admin":
                    servResp = ServerResponse.Admin;
                    break;
                case "private":
                    servResp = ServerResponse.Private;
                    break;

                default:
                    break;
            }

            return servResp;
        }

    }
}
