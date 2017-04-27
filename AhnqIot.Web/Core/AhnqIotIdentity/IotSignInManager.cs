#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Web
// FILENAME   ： IotSignInManager.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-18 15:58
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

/******************************************************************************************************************
 * 
 * 
 * 说　明：IotSignInManager  (版本：Version1.0.0)
 * 作　者：李朝强
 * 日　期：2015/05/19
 * 修　改：
 * 参　考：http://my.oschina.net/lichaoqiang/
 * 备　注：暂无...
 * 
 * 
 * ***************************************************************************************************************/

#region using namespace

using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

#endregion

namespace AhnqIot.Web.Core.AhnqIotIdentity
{
    public class IotSignInManager : SignInManager<IotUser, String>
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="UserManager"></param>
        /// <param name="AuthenticationManager"></param>
        public IotSignInManager(UserManager<IotUser, String> UserManager, IAuthenticationManager AuthenticationManager)
            : base(UserManager, AuthenticationManager)
        {
        }

        /// <summary>
        ///     根据用户名密码，验证用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isPersistent"></param>
        /// <param name="shouldLockout"></param>
        /// <returns></returns>
        public override Task<SignInStatus> PasswordSignInAsync(string userName,
            string password,
            bool isPersistent,
            bool shouldLockout)
        {
            return base.PasswordSignInAsync(userName,
                password,
                isPersistent,
                shouldLockout);
        }
    }
}