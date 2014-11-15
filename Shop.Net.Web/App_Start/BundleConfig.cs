namespace Shop.Net.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(
                new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/responsive-images").Include("~/Scripts/masonry.pkgd.min.js")
                .Include("~/Scripts/jquery.magnific-popup.js")
                    .Include("~/Scripts/responsive-images.js")
                    .Include("~/Scripts/thumbnail-gallery-script.js").Include("~/Scripts/jquery.raty.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/kendo").Include("~/Scripts/Kendo/kendo.all.min.js")
                    .Include("~/Scripts/Kendo/kendo.aspnetmvc.min.js"));


            bundles.Add(
                new StyleBundle("~/Content/css").Include(
                    "~/Content/paper.css",
                    "~/Content/site.css",
                    "~/Content/magnific-popup/magnific-popup.css",
                    "~/Content/Kendo/kendo.common-bootstrap.min.css",
                    "~/Content/Kendo/kendo.bootstrap.min.css",
                    "~/Content/font-awesome.min.css",
                    "~/Content/jquery.raty.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
            bundles.IgnoreList.Clear();
        }
    }
}