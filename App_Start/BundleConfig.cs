using System.Web;
using System.Web.Optimization;

namespace RetailApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", 
                        "~/Scripts/jquery-ui.js", 
                        "~/Scripts/jqueryCombobox.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryContact").Include(
                        "~/Scripts/Contact.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendojs").Include(
                "~/Scripts/kendo.all.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/kendocss").Include(
                "~/Content/kendo/2016.1.412/kendo.common.min.css",
                "~/Content/kendo/2016.1.412/kendo.bootstrap.min.css"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui.css"
                ));
            bundles.Add(new StyleBundle("~/Content/Hexagon").Include(
                      "~/Content/hexagon.css"));
            bundles.Add(new StyleBundle("~/Content/ContactFish").Include(
                      "~/Content/ContactFish.css"));

            bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
                        "~/Scripts/cldr.js",
                        "~/Scripts/cldr/event.js",
                        "~/Scripts/cldr/supplemental.js",
                        "~/Scripts/globalize.js",
                        "~/Scripts/globalize/number.js"
            ));

        }
    }
}
