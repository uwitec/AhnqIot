#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： SensorDataProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 13:32
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Infrastructure.DI;
using Autofac;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Collect
{
    public class MediaDataProcess
    {
        private IDeviceService _deviceService;

        public MediaDataProcess()
        {
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
        }

        public async Task ProcessAsync(IEnumerable<MediaData> mdList)
        {
        }

        public async Task ProcessAsync(MediaData md)
        {
        }
    }
}