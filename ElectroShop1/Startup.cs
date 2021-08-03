using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectroShop1.Startup))]
namespace ElectroShop1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
