using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
namespace AhnqIot.Bussiness.Interface
{
   public interface IAgrDiagnosticModelService:IService<AgrDiagnosticModelDto>
    {
        /// <summary>
        /// 根据农作物生长信息编码获取诊断模型
        /// </summary>
        /// <param name="agrProductObjectGrowthInfoId">农作物生长信息编码</param>
        /// <returns></returns>
        Task<IEnumerable<AgrDiagnosticModelDto>> GetAgrDiagnosticModelByAgrProductObjectGrowthInfoIdAsny(string agrProductObjectGrowthInfoId);
        /// <summary>
        /// 根据设备类型编码查找诊断模型
        /// </summary>
        /// <param name="deviceTypeId">设备类型编码</param>
        /// <returns></returns>
        Task<AgrDiagnosticModelDto> GetAgrDiagnosticModelByDevieTypeIdAsny(string deviceTypeId);
    }
}
