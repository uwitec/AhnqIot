#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.Container
// FILENAME   ： Service.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-25 15:35
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016
#endregion

using System.Linq;
using System.Threading.Tasks;
using NewLife.Configuration;
using NewLife.Net;
using Smart.Redis;
using SmartIot.Api.Protocal;
using SmartIot.API.Container.Core;
using SmartIot.API.Processor;
using SmartIot.Service.Core;
using XAgent;

namespace SmartIot.API.Container
{
    public class Service : AgentServiceBase<Service>
    {
        #region field
        /// <summary>
        /// 网络服务监听端口
        /// </summary>
        private int _listenPort = 65510;
        /// <summary>
        /// 网络服务
        /// </summary>
        private ApiServer _netServer;

        #endregion

        #region windows service 控制
        /// <summary>显示名字</summary>
        public override string DisplayName { get { return "农气物联网数据中心服务"; } }

        protected override void OnStart(string[] args)
        {

            var port = Config.GetConfig<int>("Port", _listenPort);
            if (_netServer == null)
                _netServer = new ApiServer();

            try
            {
                _netServer.Start(_listenPort);
                WriteLine("{0}启动", DisplayName);
                base.OnStart(args);
            }
            catch (System.Exception ex)
            {
                WriteLine("服务启动失败，{0}", ex.Message);
                WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
                WriteLine(ex.ToString());
                WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
            }
        }

        /// <summary>停止</summary>
        public override void StopWork()
        {
            if (_netServer == null) return;
            try
            {
                _netServer.Stop();
                WriteLine("{0}停止", DisplayName);
                base.StopWork();
            }
            catch (System.Exception ex)
            {
                WriteLine("服务停止失败，{0}", ex.Message);
                WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
                WriteLine(ex.ToString());
                WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
            }
        }

        #endregion

       
    }
}