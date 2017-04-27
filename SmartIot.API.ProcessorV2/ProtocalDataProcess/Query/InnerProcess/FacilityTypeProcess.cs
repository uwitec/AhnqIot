#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： Class1.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-03 15:36
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Query.InnerProcess
{
    public class FacilityTypeProcess
    {
        private readonly IFacilityTypeService _facilityTypeService;

        public FacilityTypeProcess()
        {
            _facilityTypeService = AhnqIotContainer.Container.Resolve<IFacilityTypeService>();
        }

        public async Task<IEnumerable<FacilityTypeDto>> ProcessAsync()
        {
            return await _facilityTypeService.GetAllAsync();
        }
    }
}