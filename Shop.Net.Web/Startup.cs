using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shop.Net.Web.Startup))]
namespace Shop.Net.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
