using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Iasset.Web.Startup))]
namespace Iasset.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
