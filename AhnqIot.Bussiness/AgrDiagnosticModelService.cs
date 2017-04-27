using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;
namespace AhnqIot.Bussiness
{
   public class AgrDiagnosticModelService : ServiceBase<AgrDiagnosticModel, AgrDiagnosticModelDto>,IAgrDiagnosticModelService
    {
        //private readonly IAhnqIotRepository<AgrDiagnosticModel> _agrDiagnosticModelRep;

        public AgrDiagnosticModelService(IAhnqIotRepository<AgrDiagnosticModel> agrDiagnosticModelRep)
        {
            //_agrDiagnosticModelRep = agrDiagnosticModelRep;
        }
        /// <summary>
        /// 根据农作物生长信息编码获取诊断模型
        /// </summary>
        /// <param name="agrProductObjectGrowthInfoId">农作物生长信息编码</param>
        /// <returns></returns>
       public async Task<IEnumerable<AgrDiagnosticModelDto>> GetAgrDiagnosticModelByAgrProductObjectGrowthInfoIdAsny(string agrProductObjectGrowthInfoId)
        {
            return GetDtoModels(await Repository.GetManyAsync(adm => adm.AgrProductObjectGrowthInfoSerialnum.Equals(agrProductObjectGrowthInfoId)));
        }
        /// <summary>
        /// 根据设备类型编码查找诊断模型
        /// </summary>
        /// <param name="deviceTypeId">设备类型编码</param>
        /// <returns></returns>
        public async Task<AgrDiagnosticModelDto> GetAgrDiagnosticModelByDevieTypeIdAsny(string deviceTypeId)
        {
            return GetDtoModel(await Repository.GetAsync(adm => adm.AgrProductObjectGrowthInfoSerialnum.Equals(deviceTypeId)));
        }
    }
}
