#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： Class1.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-03 15:36
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Query.InnerProcess
{
    public class DeviceTypeProcess
    {
        private readonly IDeviceTypeService _deviceTypeService;

        public DeviceTypeProcess()
        {
            _deviceTypeService = AhnqIotContainer.Container.Resolve<IDeviceTypeService>();
        }

        public async Task<IEnumerable<DeviceTypeDto>> ProcessAsync()
        {
            return await _deviceTypeService.GetAllAsync();
        }
    }
}