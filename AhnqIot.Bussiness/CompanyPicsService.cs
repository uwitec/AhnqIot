#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： CompanyPicsService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-15 15:29
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;

#endregion

namespace AhnqIot.Bussiness
{
    public class CompanyPicsService :ServiceBase<CompanyPics,CompanyPicsDto> ,ICompanyPicsService
    {
        //private readonly IAhnqIotRepository<CompanyPics> _companyPicsRep;

        public CompanyPicsService(IAhnqIotRepository<CompanyPics> companyPicsRep)
        {
            //_companyPicsRep = companyPicsRep;
        }

        /// <summary>
        ///     根据编码获取企业图片
        /// </summary>
        /// <param name="id">图片编码</param>
        /// <returns></returns>
        public async Task<CompanyPicsDto> GetPicsByIdAsny(string id)
        {
            return
                GetDtoModel(
                    await Repository.GetAsync(c => c.Serialnum.Equals(id)));
        }

        /// <summary>
        ///     根据企业编码获取企业图片
        /// </summary>
        /// <param name="companyId">企业编码</param>
        /// <returns></returns>
        public async Task<CompanyPicsDto> GetPicsByCompanyAsny(string companyId)
        {
            return
                GetDtoModel(
                    await Repository.GetAsync(c => c.CompanySerialnum.Equals(companyId)));
        }

        /// <summary>
        ///     根据编码删除图片
        /// </summary>
        /// <param name="id">图片编码</param>
        /// <returns></returns>
        public async Task<bool> DeletePicsById(string id)
        {
            var pics = await Repository.GetAsync(c => c.Serialnum.Equals(id));
            Repository.Delete(pics);
            return await Repository.CommitAsync() > 0;
        }
    }
}