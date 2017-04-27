#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Web
// FILENAME   ： IotUserStore.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-15 15:49
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

/******************************************************************************************************************
 * 
 * 
 * 说　明：IotUserStore (版本：Version1.0.0)
 * 作　者：李朝强
 * 日　期：2015/05/19
 * 修　改：
 * 参　考：http://my.oschina.net/lichaoqiang/
 * 备　注：暂无...
 * 
    IUserLockoutStore<User, TKey>: 在尝试一定的失败次数后允许锁定一个账号
    IUserEmailStore<User, TKey>: 使用邮件地址做确认 (例如通过邮件进行确认)
    IUserPhoneNumberStore<User, TKey>: 使用手机号码做确认(例如通过短信进行确认)
    IUserTwoFactorStore<User, TKey>: 启用2中途径进行安全验证 (例如通过用户名/密码和通过邮件或者短信的令牌)，当用户密码可能存在不安全隐患的时候，系统会以短信或邮件的方式向用户发送安全码
 
 * 
 * ***************************************************************************************************************/

#region using namespace

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using Microsoft.AspNet.Identity;

#endregion

namespace AhnqIot.Web.Core.AhnqIotIdentity
{
    public class IotUserStore : IUserStore<IotUser, string>,
        IUserPasswordStore<IotUser, String>,
        IUserClaimStore<IotUser, String>,
        IUserLockoutStore<IotUser, String>,
        IUserEmailStore<IotUser, String>,
        IUserPhoneNumberStore<IotUser, String>,
        IUserTwoFactorStore<IotUser, String>
    {
        private readonly ISysUserService _sysUserService;

        /// <summary>
        ///     声明
        /// </summary>
        public IList<Claim> Claims = null;

        /// <summary>
        ///     用户
        /// </summary>
        public IotUser UserIdentity = null;

        /// <summary>
        ///     实例化
        /// </summary>
        public IotUserStore(ISysUserService service)
        {
            //声明
            Claims = new List<Claim>();
            _sysUserService = service;
        }


        /// <summary>
        ///     添加一个声明
        /// </summary>
        /// <param name="user"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        public Task AddClaimAsync(IotUser user, Claim claim)
        {
            return Task.Run(() => { Claims.Add(claim); });
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<IList<Claim>> GetClaimsAsync(IotUser user)
        {
            return Task.Run<IList<Claim>>(() =>
            {
                IList<Claim> list = new List<Claim>();

                //声明
                //System.Security.Claims.Claim claimUserName = new System.Security.Claims.Claim("nick", user.UserName);//UserName
                //System.Security.Claims.Claim claimUserId = new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString());//UserId
                //list.Add(claimUserName);
                //list.Add(claimUserId);

                return list;
            });
        }

        /// <summary>
        ///     移除声明
        /// </summary>
        /// <param name="user"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        public Task RemoveClaimAsync(IotUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     获取访问失败次数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> GetAccessFailedCountAsync(IotUser user)
        {
            return Task.FromResult<Int32>(1);
        }

        /// <summary>
        ///     获取锁定状态
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> GetLockoutEnabledAsync(IotUser user)
        {
            return Task.Run<bool>(() => { return false; });
        }

        /// <summary>
        ///     获取锁定结束时间
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<DateTimeOffset> GetLockoutEndDateAsync(IotUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> IncrementAccessFailedCountAsync(IotUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     重置访问时间计数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task ResetAccessFailedCountAsync(IotUser user)
        {
            return Task.FromResult(false);
        }

        /// <summary>
        ///     获取密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> GetPasswordHashAsync(IotUser user)
        {
            return Task.Run(() => { return user.Password; });
        }

        /// <summary>
        ///     是否有密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> HasPasswordAsync(IotUser user)
        {
            return Task.FromResult<bool>(!string.IsNullOrEmpty(user.Password));
        }

        /// <summary>
        ///     密码进行加密
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public Task SetPasswordHashAsync(IotUser user, string passwordHash)
        {
            return Task.Run(() =>
            {
                user.Password = passwordHash; //加密后
            });
        }


        /// <summary>
        ///     创建用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateAsync(IotUser user)
        {
            //return Task.Run(() =>
            //{
            //var strInsertCmd = @"INSERT INTO[tb_User](ID,UserName,UserPwd) VALUES(@UserID,@UserName,@UserPwd);";
            //SqlParameter[] parameters =
            //{
            //    new SqlParameter("@UserName", SqlDbType.NVarChar, 30),
            //    new SqlParameter("@UserPwd", SqlDbType.NVarChar, 100),
            //    new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
            //};
            //parameters[0].Value = user.UserName;
            //parameters[1].Value = user.Password;
            //parameters[2].Value = user.Id;

            //int iResult = DbHelper.ExecuteNonQuery(strInsertCmd, parameters);
            //});

            //todo 执行添加用户到数据库

            //ISysUserService service = Infrastructure.DI.Ioc.CurrentIoc.Resolve<ISysUserService>();
            await _sysUserService.AddAsync(new SysUserDto()
            {
                LoginName = user.UserName,
                Password = user.Password
            });
        }

        /// <summary>
        ///     删除用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task DeleteAsync(IotUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<IotUser> FindByIdAsync(string userId)
        {
            var userDto = await _sysUserService.GetAsync(dto => dto.Serialnum.Equals(userId));
            return new IotUser()
            {
                Id = userDto.Serialnum,
                NickName = userDto.UserName,
                Password = userDto.Password,
                UserName = userDto.LoginName
            };
        }

        /// <summary>
        ///     1>通过用户名获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<IotUser> FindByNameAsync(string userName)
        {
            //return Task.Run<IotUser>(() =>
            //{
            //if (UserIdentity != null)
            //{
            //    return UserIdentity;
            //}

            //var strCmd = "SELECT * FROM [tb_User] WHERE UserName=@UserName;";
            //SqlParameter[] parameters = {new SqlParameter("@UserName", SqlDbType.NVarChar, 30)};
            //parameters[0].Value = userName;
            //var list = new List<AhnqiotKuUser>();
            //using (IDataReader data = DbHelper.ExecuteReader(strCmd, parameters))
            //{
            //    while (data.Read())
            //    {
            //        //model
            //        var user = new AhnqiotKuUser();
            //        user.Id = Guid.Parse(data["ID"].ToString());
            //        user.UserName = data["UserName"].ToString();
            //        user.Password = data["UserPwd"].ToString();
            //        list.Add(user);
            //    }
            //}
            ////模拟数据库
            //UserIdentity = list.FirstOrDefault();

            IotUser UserIdentity = null;
            var userDto = await _sysUserService.GetAsync(user => user.LoginName.Equals(userName));
            if (userDto != null)
            {
                UserIdentity = new IotUser()
                {
                    Id = userDto.Serialnum,
                    NickName = userDto.UserName,
                    Password = userDto.Password,
                    UserName = userDto.LoginName
                };
            }


            return UserIdentity;
            //});
        }

        /// <summary>
        ///     更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task UpdateAsync(IotUser user)
        {
            return Task.Run(() => { });
        }

        /// <summary>
        ///     释放
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> GetTwoFactorEnabledAsync(IotUser user)
        {
            return Task.Run<bool>(() => { return false; });
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public Task SetTwoFactorEnabledAsync(IotUser user, bool enabled)
        {
            return Task.Run(() => { });
        }

        /// <summary>
        ///     2>通过用户ID，获取用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<IotUser> FindByIdAsync(Guid userId)
        {
            return Task.Run<IotUser>(() =>
            {
                if (UserIdentity != null)
                {
                    return UserIdentity;
                }

                ////var strCmd = "SELECT * FROM [tb_User] WHERE ID=@UserID;";
                ////SqlParameter[] parameters = {new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)};
                ////parameters[0].Value = userId;
                ////var list = new List<AhnqiotKuUser>();
                ////using (IDataReader data = DbHelper.ExecuteReader(strCmd, parameters))
                ////{
                ////    while (data.Read())
                ////    {
                ////        //model
                ////        var user = new AhnqiotKuUser();
                ////        user.Id = Guid.Parse(data["ID"].ToString());
                ////        user.UserName = data["UserName"].ToString();
                ////        user.Password = data["UserPwd"].ToString();

                ////        list.Add(user);
                ////    }
                ////}
                ////UserIdentity = list.FirstOrDefault();

                //todo 查询对应ID的用户对象

                return UserIdentity;
            });
        }

        #region  LockOut

        /// <summary>
        ///     修改锁定状态
        /// </summary>
        /// <param name="user"></param>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public Task SetLockoutEnabledAsync(IotUser user, bool enabled)
        {
            return Task.Run(() => { });
        }

        /// <summary>
        ///     设置锁定时间
        /// </summary>
        /// <param name="user"></param>
        /// <param name="lockoutEnd"></param>
        /// <returns></returns>
        public Task SetLockoutEndDateAsync(IotUser user, DateTimeOffset lockoutEnd)
        {
            return Task.Run(() => { });
        }

        #endregion

        #region Email

        /// <summary>
        ///     通过邮箱获取用户信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<IotUser> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     获取用户邮箱
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> GetEmailAsync(IotUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     确认邮件
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> GetEmailConfirmedAsync(IotUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     修改邮箱
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task SetEmailAsync(IotUser user, string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="confirmed"></param>
        /// <returns></returns>
        public Task SetEmailConfirmedAsync(IotUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Phone

        /// <summary>
        ///     获取手机号
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> GetPhoneNumberAsync(IotUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> GetPhoneNumberConfirmedAsync(IotUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public Task SetPhoneNumberAsync(IotUser user, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="confirmed"></param>
        /// <returns></returns>
        public Task SetPhoneNumberConfirmedAsync(IotUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}