using Microsoft.Owin;
using Owin;
using RetailApp.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RetailApp.Models;

[assembly: OwinStartupAttribute(typeof(RetailApp.Startup))]
namespace RetailApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
