using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Smart.Redis;
using SmartIot.API.ProcessorV2.Common;

namespace SmartIot.API.ProcessorV2.TaskManager.Collect
{
    public class CameraRunLogJob : ITaskJob
    {
        private readonly IFacilityCameraRunLogService _facilityCameraRunLogService;
        private readonly RedisClient _redisClient;

        public CameraRunLogJob()
        {
            JobName = "视频运行记录";
            Period = 5 * 60;

            _redisClient = RedisClient.DefaultDB;
            _facilityCameraRunLogService = AhnqIotContainer.Container.Resolve<IFacilityCameraRunLogService>();
        }
        public string JobName { get; set; }

        public int Period { get; set; }

        public async Task<int> GetWaitForSecondsAsync()
        {
            return await Task.FromResult<int>(60);
        }

        public async Task ProcessAsync()
        {
            var logDto = _redisClient.ListPop<FacilityCameraRunLogDto>(RedisKeyString.CameraRunLog, RedisSerializeType.DataType);
            if (logDto == null) return;

            await _facilityCameraRunLogService.ProcessRunLogAsync(logDto);
        }
    }
}
