using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
    public interface IFarmService : IService<FarmDto>
    {
        /// <summary>
        /// 获取企业下所有基地
        /// </summary>
        /// <param name="companyId">企业编码</param>
        /// <returns></returns>
        Task<IEnumerable<FarmDto>> GetFarmsByCompanyAsny(string companyId);
    }
}
