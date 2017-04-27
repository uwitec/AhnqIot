using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using Smart.Redis;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage.InnerProcess
{
    public class MediaAddProcess
    {
        private readonly IFacilityCameraService _facilityCameraService;
        private readonly IFacilityService _facilityService;
        private readonly RedisClient _redisClient;

        public MediaAddProcess()
        {
            _redisClient = RedisClient.DefaultDB;
            _facilityCameraService = AhnqIotContainer.Container.Resolve<IFacilityCameraService>();
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>();
        }

        /// <summary>
        /// 处理视频设备添加数据
        /// </summary>
        /// <param name="media">视频设备添加数据</param>
        /// <returns></returns>
        public async Task<XResponseMessage> ProcessAsync(MediaData media)
        {
            if (!_facilityCameraService.CheckCode(media.DeviceCode))
                return ResultHelper.CreateMessage("设备编码规则错误", ErrorType.InternalError);
            if (!await _facilityService.ExistsWithRedisAsync(media.FacilityCode))
                return ResultHelper.CreateMessage("设施不存在", ErrorType.FacilityNotExists);
            var item = await _facilityCameraService.GetFacilityCameraByIdAsny(media.DeviceCode);
            //数据库中不存在该设备(有必要吗？)
            if (item != null) return null;
            item = new FacilityCameraDto
            {
                Serialnum = media.DeviceCode,
                Name = media.DeviceName,
                FacilitySerialnum = media.FacilityCode,
                Channel = media.Channel,
                UserID = media.User,
                UserPwd = media.Pwd,
                IP = media.Url,
                DataPort = media.ContrPort,
                HttpPort = media.MediaPort,
                Sort = 0,
                Status = true,
                RtspPort = 54,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            try
            {
                var result = await _facilityCameraService.AddFacilityCamera(item);
                LogHelper.Info("[视频]视频{0}{1}添加{2}", item.Name, item.Serialnum, result);
                return ResultHelper.CreateMessage($"添加视频设备{(result ? "成功" : "失败")}",
                    result ? ErrorType.NoError : ErrorType.InternalError);
            }
            catch (AggregateException ex)
            {
                return ResultHelper.CreateExceptionMessage(ex, "添加视频设备失败");
            }
        }
    }
}