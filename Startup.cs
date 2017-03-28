using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrvaAplikacija.Startup))]
namespace PrvaAplikacija
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
