using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stks.Admin.Startup))]
namespace Stks.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
