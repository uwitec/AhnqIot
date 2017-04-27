using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.Repository.AhnqIot;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AutoMapper;

namespace AhnqIot.Bussiness
{
    public class CompanyService :ServiceBase<Company,CompanyDto>, ICompanyService
    {

        public CompanyService() { }
        /// <summary>
        /// 根据编码获取企业
        /// </summary>
        /// <param name="id">企业编码</param>
        /// <returns></returns>
        public async Task<CompanyDto> GetCompanyByIdAsny(string id)
        {
            return GetDtoModel(await Repository.GetAsync(c => c.Serialnum.Equals(id)));
        }
        /// <summary>
        /// 获取所有企业
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CompanyDto>> GetCompanysAsny()
        {
            return GetDtoModels(await Repository.GetAllAsync());
        }
        /// <summary>
        /// 根据机构编码获取企业
        /// </summary>
        /// <param name="departmentId">机构编码</param>
        /// <returns></returns>
        public async Task<CompanyDto> GetCompanyByDepartmentIdAsny(string departmentId)
        {
            return GetDtoModel(await Repository.GetAsync(c => c.SysDepartmentSerialnum.Equals(departmentId)));
        }

        //public async Task<bool> Add(CompanyDto dto)
        //{
        //    var entity = GetDbModel(dto);
        //    Repository.Add(entity);
        //    return await Repository.CommitAsync() > 0;
        //}

        //public async Task<bool> Delete(string serialnum)
        //{
        //    Repository.Delete(serialnum);
        //    return await Repository.CommitAsync() > 0;
        //}
    }
}
