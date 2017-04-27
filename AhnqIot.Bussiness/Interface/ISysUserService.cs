#region Code File Comment
// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： ISysUserService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 17:20
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
    public interface ISysUserService : IService<SysUserDto>
    {

        /// <summary>
        ///     登录检测
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> LoginAsync(string loginName, string password);
    }
}