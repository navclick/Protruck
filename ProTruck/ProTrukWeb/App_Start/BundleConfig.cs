using System.Web;
using System.Web.Optimization;

namespace ProTrukWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/val").Include(
                       "~/Content/js/jquery.min.js",
                       "~/Content/js/jquery.form-validator.min.js"


                       ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
              
                "~/Content/vendors/vendors.min.css",
                      "~/Content/vendors/animate-css/animate.css",
                      "~/Content/vendors/chartist-js/chartist.min.css",
                      "~/Content/vendors/vendors/chartist-js/chartist-plugin-tooltip.css",

                      "~/Content/css/themes/vertical-modern-menu-template/materialize.css",
                      "~/Content/css/themes/vertical-modern-menu-template/style.css",
                      "~/Content/css/pages/dashboard-modern.css",
                      "~/Content/css/pages/intro.css",
                      "~/Content/css/custom/custom.css"
                            




                      ));

            bundles.Add(new StyleBundle("~/Content/datatable").Include(
                  "~/Content/vendors/flag-icon/css/flag-icon.min.css",
                             "~/Content/vendors/data-tables/css/jquery.dataTables.min.css",
                              "~/Content/vendors/data-tables/extensions/responsive/css/responsive.dataTables.min.css",
                               "~/Content/vendors/data-tables/css/select.dataTables.min.css",
                                "~/Content/css/pages/data-tables.css"




                   ));

            bundles.Add(new ScriptBundle("~/bundles/themejs").Include(
                       "~/Content/js/vendors.min.js",
                        "~/Content/vendors/chartist-js/chartist.min.js",
                        "~/Content/vendors/chartist-js/chartist-plugin-tooltip.js",
                        "~/Content/vendors/chartist-js/chartist-plugin-fill-donut.min.js",
                        "~/Content/js/plugins.js",
                         "~/Content/js/custom/custom-script.js",
                         "~/Content/js/scripts/dashboard-modern.js"       
                        ));


            bundles.Add(new ScriptBundle("~/bundles/datatablejs").Include(
                        "~/Content/vendors/data-tables/js/jquery.dataTables.min.js",
                        "~/Content/vendors/data-tables/extensions/responsive/js/dataTables.responsive.min.js",
                        "~/Content/vendors/data-tables/js/dataTables.select.min.js",
                        "~/Content/js/scripts/data-tables.js"
                        
                        ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/jquery-3.4.1.min.js",
                       "~/Scripts/angular.min.js"
                       ));


        }
    }
}
