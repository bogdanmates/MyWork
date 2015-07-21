using System.Web;
using System.Web.Optimization;

namespace NikeMVCVM
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                        "~/Scripts/index.js", 
                        "~/Scripts/main.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js"
                       ));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include( 
                        "~/Content/register.css",
                        "~/Content/slider.css", 
                        "~/Content/style.css", 
                        "~/Content/categorystyle.css", 
                        "~/Content/mainradu.css",
                        "~/Content/shoppingCartStyle.css", 
                        "~/Content/underConstructionStyle.css",
                        "~/Content/working.css", 
                        "~/Content/main.css"));
            
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/bootstrap.min.css", 
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-theme.css",
                        "~/Content/bootstrap-theme.min.css",
                        "~/Content/bootstrap-theme.css.map", 
                        "~/Content/bootstrap.css.map"));

            bundles.Add(new StyleBundle("~/Content/bx-slider").Include(
                        "~/Content/jquery.bxslider.css"));

            bundles.Add(new ScriptBundle("~/bundles/bx-slider").Include(
                       "~/Scripts/jquery.bxslider.js"));

            bundles.Add(new ScriptBundle("~/bundles/slider").Include(
                         "~/Scripts/slider.js"));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
        
    }
}