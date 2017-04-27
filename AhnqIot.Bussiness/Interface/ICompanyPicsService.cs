#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： ICompanyPicsService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-15 15:29
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

#endregion

namespace AhnqIot.Bussiness.Interface
{
    public interface ICompanyPicsService : IService<CompanyPicsDto>
    {
        /// <summary>
        ///     根据编码获取企业图片
        /// </summary>
        /// <param name="id">图片编码</param>
        /// <returns></returns>
        Task<CompanyPicsDto> GetPicsByIdAsny(string id);

        /// <summary>
        ///     获取企业下所有图片
        /// </summary>
        /// <param name="companyId">企业编码</param>
        /// <returns></returns>
        Task<CompanyPicsDto> GetPicsByCompanyAsny(string companyId);

        /// <summary>
        ///     根据编码删除图片
        /// </summary>
        /// <param name="id">图片编码</param>
        /// <returns></returns>
        Task<bool> DeletePicsById(string id);
    }
}