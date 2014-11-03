using Microsoft.Owin;

using Shop.Net.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace Shop.Net.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}