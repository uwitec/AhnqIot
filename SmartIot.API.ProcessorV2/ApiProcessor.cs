using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Infrastructure;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using NewLife.Net;
using NewLife.Threading;
using Smart.Redis;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Formatter;
using SmartIot.Api.Protocal.Meta;
using SmartIot.API.ProcessorV2.Common;
using SmartIot.API.ProcessorV2.Core;
using DataPacket = SmartIot.API.ProcessorV2.Core.DataPacket;

namespace SmartIot.API.ProcessorV2
{
    public class ApiProcessor
    {
        #region field
        private  RedisClient _redis;
        //private static IDeviceService _deviceService;
        //private static IFacilityService _facilityService; 
        private  TimerX _processTimerX;
        #endregion

        public ApiProcessor()
        {
            _redis = new RedisClient();
            //_facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>();
            //_deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
        }


        public async  void Start()
        {
            _processTimerX = new TimerX(async obj => { await ProcessPackageAsync(); }, null, 1000, 100);
        }


        #region 数据包分析
        /// <summary>
        /// 分析数据包，并将数据放到Redis中
        /// </summary>
        /// <returns></returns>
        private async  Task ProcessPackageAsync()
        {
            var redisClient = new RedisClient();
            var packetList = redisClient.ListRange<DataPacket>(RedisKeyString.PackageList, 0, 10, DataType.Protobuf); //每次取10条数据
            if (packetList.Any())
            {
                Parallel.ForEach(packetList, async package =>
                {
                    var responseMessage = await Process(package.Data);
                    var str = responseMessage == null ? "" : responseMessage.ToString();

                    ISocketSession session = null;
                    RemoteSessionHelper.RemoteSessionCache.TryGetValue(package.Id, out session);
                    session.Send(str);
                });
            }
        }

        #endregion


        /// <summary>
        /// 农业物联网信息服务平台数据交换协议 处理
        /// </summary>
        /// <param name="str"></param>
        public  async Task<XResponseMessage> Process(string str)
        {
            // if (str.IsNullOrWhiteSpace()) throw new ArgumentNullException("str");
            Check.NotNull(str, "str");

            AwEntity obj = AwEntityHelper.GetAwEntity(str);
            if (obj == null)
            {
                LogHelper.Error("[数据格式][错误] " + str);
                return ResultHelper.CreateMessage("数据格式错误", ErrorType.CanNotProcessRequestData);
                // return ResultHelper.CreateExceptionMessage(ex, "数据格式错误", ErrorType.NotSupportedProtocalType);
            }

            #region 协议解析
            try
            {
                var awEntity = obj;
                //ServiceLogger.Current.WriteDebugLog("{0}", awEntity.Description);
                var result = await ProcessEntity(awEntity);
                //ServiceLogger.Current.WriteLine(result.ToString());
                return result ?? new XResponseMessage()
                {
                    Success = ErrorType.NoError
                };
                //return null;
            }
            catch (Exception ex)
            {
                //ServiceLogger.Current.WriteException(ex);
                LogHelper.Fatal(ex.ToString());
                return ResultHelper.CreateMessage("协议解析错误", ErrorType.CanNotProcessRequestData, null, ex);
            }
            #endregion
        }

        /// <summary>
        /// 解析对象
        /// </summary>
        /// <param name="awEntity"></param>
        /// <returns></returns>
        private  async Task<XResponseMessage> ProcessEntity(AwEntity awEntity)
        {
#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
#endif
            //var result = await AwEntityProcessor.Process(awEntity);
#if DEBUG
            sw.Stop();
            LogHelper.Debug("ProcessEntity:{0} \t{1} ms", awEntity.Description, sw.ElapsedMilliseconds);
#endif
            //return result;
            return null;
        }
    }
}
