using System.Configuration;
using System.Web;
using System.Web.Optimization;

namespace RightsLine
{
    public class BundleConfig
    {
        public const string STYLE_BOOTSTRAP = "~/Content/bootstrap";
        public const string STYLE_BASE = "~/Content/css";

        public const string SCRIPT_MODERNIZR = "~/bundles/modernizr";
        public const string SCRIPT_ANGULAR = "~/Scripts/angular";
        public const string SCRIPT_JQUERY = "~/bundles/jquery";
        public const string SCRIPT_ALL = "~/Scripts";

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle(SCRIPT_JQUERY, ConfigurationManager.AppSettings["CDN.Jquery"]).Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle(SCRIPT_ANGULAR, ConfigurationManager.AppSettings["CDN.Angular"])
                            .Include("~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle(SCRIPT_ALL)
                            .Include("~/Scripts/angularstrap/angular-strap.js",
                                     "~/Scripts/AngularUI/ui-router.js",
                                     "~/app/rightsline.js",
                                     "~/app/common/common.js",
                                     "~/app/services/user.service.js",
                                     "~/app/controllers.user.controller.js"
                            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(SCRIPT_MODERNIZR).Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle(STYLE_BASE).Include("~/Content/Site.css"));

            bundles.Add(new StyleBundle(STYLE_BOOTSTRAP, ConfigurationManager.AppSettings["CDN.Bootstrap"]).Include("~/Content/bootstrap.css"));
        }
    }
}