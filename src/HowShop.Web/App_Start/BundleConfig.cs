using System.Web.Optimization;

namespace HowShop.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/turbolinks.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/select2.min.js",
                "~/Scripts/Framework/solidr.js",
                "~/Scripts/Framework/solidr.form.js",
                "~/Scripts/app.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/select2.min.css",
                      "~/Content/app.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
