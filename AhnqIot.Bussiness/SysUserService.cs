#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： SysUserService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-13 15:21
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Linq.Expressions;
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

    public class SysUserService : ServiceBase<SysUser, SysUserDto>, ISysUserService
    {

        /// <summary>
        ///     登录检测
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> LoginAsync(string loginName, string password)
        {
            var user = await Repository.GetAsync(u => u.LoginName.Equals(loginName));
            if (user == null) return false;
            return user.Password == EncryptionPassword(password);
        }

        /// <summary>
        ///     加密密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        // todo  未实现加密算法
        private string EncryptionPassword(string pwd)
        {
            return pwd;
        }
    }
}