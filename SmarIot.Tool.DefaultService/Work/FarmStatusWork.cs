#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： SmartIot.Tool.DefaultService
// FILENAME   ： FarmStatusWork.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-22 23:50
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent.RuntimeDataRequest;
using SmartIot.Tool.API.Core;
using SmartIot.Tool.DefaultService.API;
using SmartIot.Tool.DefaultService.Core;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Service.Core;
using System;
using System.Diagnostics;
using System.Threading;
using SmartIot.Tool.Core.Common;

#endregion using namespace

namespace SmartIot.Tool.DefaultService.Work
{
    /// <summary>
    ///     基地状态数据
    /// </summary>
    public class FarmStatusWork : Job
    {
        private readonly FarmApi _farmApi;
        private Timer _timer;
        //private IApiTransport _transport;

        public FarmStatusWork()
        {
            DisplayName = "基地状态上传组件";
            Sort = 4;
            _farmApi = new FarmApi();

            if (Setting.Current.FarmStatusUploadEnable)
            {
                JobInterval = Setting.Current.FarmStatusUploadInterval * 60;
            }
            else
            {
                JobInterval = -1; //禁用此组件
            }
        }

        public override bool Start()
        {
            // _transport = ApiTransportHelper.GetTransport();
            return base.Start();
        }

        public override bool Work()
        {
            UploadStatus();
            //Timer _timer = new Timer(obj => UploadStatus(), null, 10, 30);//之前的不开异步是有问题的
            return base.Work();
        }

        public override bool Stop()
        {
            //if (_transport != null && !_transport.Disposed)
            //    _transport.Dispose();
            return base.Stop();
        }
        /// <summary>
        /// 上传基地状态
        /// </summary>
        private void UploadStatus()
        {
            var proc = Process.GetCurrentProcess();
            var _oPerformanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var cpu = Convert.ToInt32(UsingProcess(proc.ProcessName) / 1);
            _oPerformanceCounter.NextValue();
            var memory = Convert.ToInt32(proc.PrivateMemorySize64);

            var dataTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute / 15 * 15, 0);
            Farm.FindAll().ForEach(farm =>
            {
                var fs = new FarmStatus();
                fs.FarmSerialnum = farm.Code1;
                fs.MemoryUsage = memory / (1024 * 1024); //MB
                fs.CpuUsage = cpu; //第一次取值为0，然后进行第二次取值
                //fs.InfoType = "正常";
                fs.InfoType = FarmLogTypeEnum.Normal;
                fs.Time = dataTime;

                var entity2 = AwEntityHelper.GetEntity(farm.Code1);
#if DEBUG
                var sw = new Stopwatch();
                bool accessResult = false;
                sw.Start();
#endif
                try
                {
                    var trans = ApiTransportHelper.GetTransport();
                    var result = _farmApi.UploadFarmStatus(entity2, trans, fs);
                    accessResult = result;
                    trans.Dispose();
                    ServiceLogger.Current.WriteDebugLog("上传基地状态:{0}", result ? "成功" : "失败");
                }
                catch (Exception ex)
                {
                    ServiceLogger.Current.WriteException(ex);
                }
#if DEBUG
                sw.Stop();
                ApiAccessLog apiAccesslog = new ApiAccessLog
                {
                    ApiName = "上传基地状态",
                    Result = accessResult,
                    CreateTime = DateTime.Now,
                    CostTime = Convert.ToInt32(sw.ElapsedMilliseconds)
                };
                apiAccesslog.Save();
                ServiceLogger.Current.WriteDebugLog("基地上传耗时：" + sw.ElapsedMilliseconds + "ms");
#endif
            });
        }

        /// <summary>
        ///     计算当前进程CPU使用率
        /// </summary>
        /// <param name="pname"></param>
        public double UsingProcess(string pname)
        {
            double value = 0;
            //创建性能计数器
            using (var p1 = new PerformanceCounter("Process", "% Processor Time", pname))
            {
                for (var i = 0; i < 2; i++)
                {
                    //注意除以CPU数量
                    value = (p1.NextValue() / Environment.ProcessorCount);
                }
            }
            return value;
        }
    }
}