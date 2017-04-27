using SmartIot.Tool.API.Transport;
using NewLife.Configuration;
using System;

namespace SmartIot.Tool.DefaultService.Core
{
    public class ApiTransportHelper
    {
        public static IApiTransport GetTransport()
        {
            var apiUri = Config.GetConfig("ApiUri", "");
            IApiTransport transport;
            if (apiUri.StartsWith("http"))
            {
                transport = new HttpTransport();
            }
            else // if (apiUri.StartsWith("Tcp"))
            {
                transport = new SocketTransport();
            }

            var arr = apiUri.Split(new char[] {':', '/'}, StringSplitOptions.RemoveEmptyEntries);
            transport.Init(arr[1], Convert.ToInt32(arr[2]));

            return transport;
        }
    }
}