using System.Web;
using System.Web.Mvc;
using Ahnqiot.Web.Api.Providers;
using Ahnqiot.Web.Api.Providers.Exception;

namespace Ahnqiot.Web.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
