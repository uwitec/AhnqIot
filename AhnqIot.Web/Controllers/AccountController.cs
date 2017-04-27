#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： AhnqIot.Web
// FILENAME   ： AccountController.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-15 15:52
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

/******************************************************************************************************************
 * 
 * 
 * 说　明： 账号(版本：Version1.0.0)
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
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Web.Core.AhnqIotIdentity;
using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AhnqIot.DbModel;


using AhnqIot.Dto;
using AhnqIot.Bussiness;
using AhnqIot.Web.Areas.apiV1.Models;

#endregion

namespace AhnqIot.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ISysUserService _sysUserService;
        private readonly ISysDepartmentService _sysDepartmentService;
        private readonly ISysRoleService _sysRoleService;

        /// <summary>
        /// </summary>
        public AccountController()
        {
            _sysUserService = AhnqIotContainer.Container.Resolve<ISysUserService>();
            _sysDepartmentService = AhnqIotContainer.Container.Resolve<ISysDepartmentService>();
            _sysRoleService = AhnqIotContainer.Container.Resolve<ISysRoleService>();
            ViewBag.SysRole = _sysRoleService.GetAll();
            ViewBag.SysDepart = _sysDepartmentService.GetAll();
            //no code
           
        }

        /// <summary>
        ///     IAuthenticationManager
        /// </summary>
        public IAuthenticationManager AutherticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

       

        ///// <summary>
        /////     注册
        ///// </summary>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //public async Task<ActionResult> Register()
        //{
        //    ////user
        //    //var user = new IotUser { Id = Guid.NewGuid().ToString(), UserName = "aaa", Password = "XXXXXX" };

        //    ////Context
        //    //var OwinContext = HttpContext.GetOwinContext();

        //    ////用户储存
        //    //var userStore = new IotUserStore(Ioc.CurrentIoc.Resolve<ISysUserService>());

        //    ////UserManager
        //    //var UserManager = new IotUserManager(userStore);

        //    //var result = await UserManager.CreateAsync(user, user.Password);
        //    //if (result.Succeeded)
        //    //{
        //    //    Response.Write("注册成功！");
        //    //}
        //    return View();
        //}

       public async Task<ActionResult> GetRegisterData(SysUserDto user)
       {

            //users.CreateTime = DateTime.Now;
            //users.Status=    
            //users.LastIP
            //var user = _sysUserService.GetAsync(u => u.)
           
            return Content("");

            await _sysUserService.AddAsync(user);   //添加用户到数据库中
        }

        /// <summary>
        ///     登陆
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            //验证是否登录
            if (AutherticationManager.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        /// <summary>
        ///     登陆
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login1(IotUser @user)
        {
            if (string.IsNullOrEmpty(@user.UserName))
            {
                return View();
            }
            if (string.IsNullOrEmpty(@user.Password))
            {
                return View();
            }

            //Context
            var owinContext = HttpContext.GetOwinContext();

            //实例化UserStore对象
            var userStore = new IotUserStore(_sysUserService);

            //UserManager
            var userManager = new UserManager<IotUser, string>(userStore);

            //signInManager
            var signInManager = new SignInManager<IotUser, string>(userManager, AutherticationManager);


            //登录
            var signInStatus = await signInManager.PasswordSignInAsync(@user.UserName,
                @user.Password,
                true,
                shouldLockout: false);

            //状态
            switch (signInStatus)
            {
                //成功
                case SignInStatus.Success:

                    //标示
                    //System.Security.Claims.ClaimsIdentity identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //授权登陆
                    //AutherticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties { IsPersistent = true }, identity);
                    return RedirectToAction("index", "home");
                //锁定
                case SignInStatus.LockedOut:
                    Response.Write("LockedOut!");
                    break;
                //要求验证
                case SignInStatus.RequiresVerification:
                    Response.Write("RequiresVerification!");
                    break;
                //登录失败
                case SignInStatus.Failure:
                    Response.Write("Failure!");
                    break;
            }

            return View(@user);
        }


        /// <summary>
        ///     测试创建登录标示
        /// </summary>
        /// <returns></returns>
        [Obsolete("Debug模式下，测试创建登录标示")]
        private async Task<ClaimsIdentity> CreateIdentity()
        {
            ClaimsIdentity identity = null;

            //用户
            var user = new IotUser();
            user.Id = Guid.NewGuid().ToString();
            user.UserName = "ahnqiot";
            user.NickName = "安徽农业气象物联网";

            //Context
            var owinContext = HttpContext.GetOwinContext();
            var userManager = OwinContextExtensions.GetUserManager<UserManager<IotUser, string>>(owinContext);
            identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            return identity;
        }

        /// <summary>
        ///     登陆
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(IotUser @user)
        {
            if (string.IsNullOrEmpty(@user.UserName))
            {
                return View();
            }
            if (string.IsNullOrEmpty(@user.Password))
            {
                return View();
            }

            //Context
            var OwinContext = HttpContext.GetOwinContext();

            //实例化UserStore对象
            var userStore = new IotUserStore(_sysUserService);

            //UserManager
            var userManager = new IotUserManager(userStore);

            //signInManager
            var signInManager = new IotSignInManager(userManager, AutherticationManager);

            //登录
            var signInStatus = await signInManager.PasswordSignInAsync(@user.UserName, @user.Password, true, shouldLockout: false);

            //状态
            switch (signInStatus)
            {
                //成功
                case SignInStatus.Success:

                    //标示
                    //System.Security.Claims.ClaimsIdentity identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //授权登陆
                    //AutherticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties { IsPersistent = true }, identity);
                    return RedirectToAction("index", "home");
                //锁定
                case SignInStatus.LockedOut:
                    Response.Write("LockedOut!");
                    break;
                //要求验证
                case SignInStatus.RequiresVerification:
                    Response.Write("RequiresVerification!");
                    break;
                //登录失败
                case SignInStatus.Failure:
                    Response.Write("Failure!");
                    break;
            }

            return View(@user);
        }
    }
}