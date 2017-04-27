using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AhnqIot.Web.Startup))]
namespace AhnqIot.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
