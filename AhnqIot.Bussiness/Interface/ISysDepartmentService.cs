#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： Interface1.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-14 0:21
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
using AhnqIot.Hxj.DbModel;
using System.Collections.Generic;

namespace AhnqIot.Bussiness.Interface
{
    public interface ISysDepartmentService : IService<SysDepartmentDto>
    {
        /// <summary>
        /// 根据名称查找机构
        /// </summary>
        /// <param name="name">机构名称</param>
        /// <returns></returns>
        Task<SysDepartmentDto> GetSysDepartByNameAsny(string name);
        ///// <summary>
        ///// 查找机构并添加
        ///// </summary>
        ///// <param name="name">机构名称</param>
        ///// <param name="parentName">上级机构名称</param>
        ///// <param name="areaSerialnum">区域编码</param>
        ///// <returns></returns>
        // SysDepartment FindByAdd(string name, string parentName = null, string areaSerialnum = null);



        /// <summary>
        /// 根据上级编码查找机构
        /// </summary>
        /// <param name="id">上级编码</param>
        /// <returns></returns>
        Task<SysDepartmentDto> GetParentByParentIdAsny(string id);

        /// <summary>
        /// 根据上级编码查找机构
        /// </summary>
        /// <param name="id">上级编码</param>
        /// <returns></returns>
        SysDepartmentDto GetParentByParentId(string id);

    }
}