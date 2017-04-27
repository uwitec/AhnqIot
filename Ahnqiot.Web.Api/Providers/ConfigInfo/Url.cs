#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Web
// FILENAME   ： Url.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-18 21:08
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

namespace Ahnqiot.Web.Api.Providers.ConfigInfo
{
    public class Url
    {

        public string Logo { get; set; }

        public string Favicon { get; set; }

        public string Login { get; set; }

        public string Logout { get; set; }

        public string Wechat { get; set; }

        public string Qq { get; set; }
        public Url()
        {
            Logo = "/Content/images/logo.png";
            //Favicon = "/Content/images/favicon.ico";
            Favicon = "http://www.pintuer.com/favicon.ico";
            Login = "/Account/Login";
            Logout = "/Account/Logout";
            Wechat = "";
            Qq = "";
        }
    }
}