using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EShop.Startup))]
namespace EShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
