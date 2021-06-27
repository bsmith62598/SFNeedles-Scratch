using System.Web.Optimization;

namespace NeedlesAndScratch.UI.Secured
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/lightbox2/js/lightbox.min.js",
                        "~/Scripts/nouislider/nouislider.min.js",
                        "~/Scripts/owl.carousel2/owl.carousel.min.js",
                        "~/Scripts/owl.carousel2.thumbs/owl.carousel2.thumbs.min.js",
                        "~/Scripts/front.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-select/js/bootstrap-select.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/template").Include(
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/main.js",
                      "~/Scripts/DataTables/jquery.dataTables.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/custom.css",
                      "~/Content/style.default.css",
                      "~/Content/owl.carousel2/assets/owl.theme.default.css",
                      "~/Content/owl.carousel2/assets/owl.carousel.min.css",
                      "~/Content/lightbox2/css/lightbox.min.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css"));
        }
    }
}
