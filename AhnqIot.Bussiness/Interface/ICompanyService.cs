using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
    public interface ICompanyService : IService<CompanyDto>
    {

        /// <summary>
        /// 根据编码获取企业
        /// </summary>
        /// <param name="id">企业编码</param>
        /// <returns></returns>
        Task<CompanyDto> GetCompanyByIdAsny(string id);
        /// <summary>
        /// 获取所有企业
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CompanyDto>> GetCompanysAsny();
        /// <summary>
        /// 根据机构编码获取企业
        /// </summary>
        /// <param name="departmentId">机构编码</param>
        /// <returns></returns>
        Task<CompanyDto> GetCompanyByDepartmentIdAsny(string departmentId);
        ///// <summary>
        ///// 添加企业
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <returns></returns>
        //Task<bool> Add(CompanyDto dto);
        ///// <summary>
        ///// 删除企业
        ///// </summary>
        ///// <param name="serialnum"></param>
        ///// <returns></returns>
        //Task<bool> Delete(string serialnum);
    }
}
