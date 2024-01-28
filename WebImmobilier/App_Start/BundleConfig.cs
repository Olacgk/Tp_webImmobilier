using System.Web;
using System.Web.Optimization;

namespace GestionImmobilier
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jsassets").Include(
                        "~/assets/vendor/global/global.min.js",
                        "~/assets/js/quixnav-init.js",
                        "~/assets/js/custom.min.js",
                        "~/assets/vendor/raphael/raphael.min.js",
                        "~/assets/vendor/morris/morris.min.js",
                        "~/assets/vendor/circle-progress/circle-progress.min.js",
                        "~/assets/vendor/chart.js/Chart.bundle.min.js",
                        "~/assets/vendor/gaugeJS/dist/gauge.min.js",
                        "~/assets/vendor/flot/jquery.flot.js",
                        "~/assets/vendor/flot/jquery.flot.resize.js",
                        "~/assets/vendor/flot/jquery.flot.js",
                        "~/assets/vendor/owl-carousel/js/owl.carousel.min.js",
                        "~/assets/vendor/jqvmap/js/jquery.vmap.min.js",
                        "~/assets/vendor/jqvmap/js/jquery.vmap.usa.js",
                        "~/assets/vendor/jquery.counterup/jquery.counterup.min.js",
                        "~/assets/js/dashboard/dashboard-1.js"
                        ));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                     "~/Content/PagedList.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/assets").Include(
                     "~/assets/vendor/owl-carousel/css/owl.carousel.min.css",
                     "~/assets/vendor/owl-carousel/css/owl.theme.default.min.css",
                     "~/assets/vendor/jqvmap/css/jqvmap.min.css",
                     "~/Content/PagedList.css",
                     "~/assets/css/style.css"
                     ));
        }
    }
}
