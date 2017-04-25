using Microsoft.Owin;
using Owin;
using RetailApp.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RetailApp.Models;

using System.Xml;

using System.Data.Entity.Infrastructure;


[assembly: OwinStartupAttribute(typeof(RetailApp.Startup))]
namespace RetailApp
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            /*Use this to export database diagram*/
            /*var writer = new XmlTextWriter(@"c:\Model.edmx", System.Text.Encoding.Default);
            var ctx = new RetailAppContext();
            EdmxWriter.WriteEdmx(ctx, writer);*/
        }
    }
}
