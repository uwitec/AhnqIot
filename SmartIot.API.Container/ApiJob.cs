using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartIot.Service.Core;
using NewLife.Configuration;

namespace SmartIot.API.Container
{
    public class ApiJob : Job
    {
        private int _listenPort = 65510;
        private ApiNetServer _server;

        public override bool Start()
        {
            DisplayName = "数据接口Socket工作组件";

            var port = Config.GetConfig<int>("Port", _listenPort);
            _server = new ApiNetServer();
            _server.Start(port);
            return base.Start();
        }


        public override bool Stop()
        {
            _server.Stop();
            return base.Stop();
        }
    }
}
