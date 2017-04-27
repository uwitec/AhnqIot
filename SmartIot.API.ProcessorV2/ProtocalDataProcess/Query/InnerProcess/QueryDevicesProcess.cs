#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： QueryDevicesProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-03 16:13
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System.Collections.Generic;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;

#endregion

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Query.InnerProcess
{
    public class QueryDevicesProcess
    {
        private readonly IDeviceService _deviceService;

        public QueryDevicesProcess()
        {
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
        }

        public async Task<IEnumerable<DeviceDto>> ProcessAsync(string facilityCode)
        {
            return await _deviceService.GetDevicesByFacilityIdAsync(facilityCode);
        }
    }
}