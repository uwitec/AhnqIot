#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Web
// FILENAME   ： AhnqiotKuUser.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-15 15:50
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

/******************************************************************************************************************
 * 
 * 
 * 说　明： AhnqiotKuUser(版本：Version1.0.0)
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
using System.ComponentModel;
using Microsoft.AspNet.Identity;

#endregion

namespace AhnqIot.Web.Core.AhnqIotIdentity
{
    public class IotUser : IUser
    {
        /// <summary>
        ///     密码
        /// </summary>
        [DisplayName("密码")]
        public string Password { get; set; }

        /// <summary>
        ///     昵称
        /// </summary>
        [DisplayName("昵称")]
        public string NickName { get; set; }

        /// <summary>
        ///     用户编号
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("登录名")]
        public string UserName { get; set; }
    }
}