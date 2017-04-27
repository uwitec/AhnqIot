#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： QueryFacilitysProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-03 15:57
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

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
    public class QueryFacilityProcess
    {
        private readonly IFacilityService _facilityService;

        public QueryFacilityProcess()
        {
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>();
        }

        public async Task<FacilityDto> ProcessAsync(string facilityCode)
        {
            return await _facilityService.GetFacilityByIdAsny(facilityCode);
        }
    }
}