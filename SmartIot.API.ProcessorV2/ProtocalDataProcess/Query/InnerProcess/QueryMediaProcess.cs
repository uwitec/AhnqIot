using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Query.InnerProcess
{
    public class QueryMediaProcess
    {
        private readonly IFacilityCameraService _facilityCameraService;

        public QueryMediaProcess()
        {
            _facilityCameraService = AhnqIotContainer.Container.Resolve<IFacilityCameraService>();
        }

        public async Task<FacilityCameraDto> ProcessAsync(string MediaCode)
        {
            return await _facilityCameraService.GetFacilityCameraByIdAsny(MediaCode);
        }
    }
}