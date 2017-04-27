#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： QueryFacilitysProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-03 15:57
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;

#endregion

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Query.InnerProcess
{
    public class QueryDeviceProcess
    {
        private readonly IDeviceService _deviceService;

        public QueryDeviceProcess()
        {
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
        }

        public async Task<DeviceDto> ProcessAsync(string deviceCode)
        {
            return await _deviceService.GetDeviceByIdAsny(deviceCode);
        }
    }
}