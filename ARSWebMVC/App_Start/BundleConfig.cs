using System.Web;
using System.Web.Optimization;

namespace ARSWebMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/MyJQuery.js",
                        "~/Scripts/jquery-{version}.js"));


            

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     
                      "~/Content/myCss/Features-Blue.css",
                      "~/Content/myCss/Footer-Dark.css",
                      "~/Content/myCss/Header-Blue.css",
                      "~/Content/myCss/Lightbox-Gallery.css",
                      "~/Content/myCss/Team-Boxed.css",
                      "~/Content/myCss/Testimonials.css",
                      "~/Content/myCss/Site.css"));
        }
    }
}
