using System.Web;
using System.Web.Optimization;

namespace DMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/plugins/jquery/jquery.min.js"));

            //Bootstrap 4
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/plugins/bootstrap/js/bootstrap.bundle.min.js"));

            //AdminLTE App
            bundles.Add(new ScriptBundle("~/bundles/global-JS").Include(
                      "~/plugins/sweetalert2/sweetalert2.min.js",
                      "~/dist/js/adminlte.min.js",
                      "~/dist/js/demo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/plugins/fontawesome-free/css/all.min.css",
                      "~/plugins/sweetalert2/sweetalert2.min.css",
                      "~/dist/css/adminlte.min.css"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
