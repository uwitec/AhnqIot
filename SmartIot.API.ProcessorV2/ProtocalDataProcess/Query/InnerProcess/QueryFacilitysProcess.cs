#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： QueryFacilitysProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-03 15:57
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

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
    public class QueryFacilitysProcess
    {
        private readonly IFacilityService _facilityService;

        public QueryFacilitysProcess()
        {
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>();
        }

        public async Task<IEnumerable<FacilityDto>> ProcessAsync(string farmCode)
        {
            return await _facilityService.GetFacilitiesByFarmIdAsny(farmCode);
        }
    }
}