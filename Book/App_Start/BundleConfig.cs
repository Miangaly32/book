using System.Web;
using System.Web.Optimization;

namespace Book
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/jquery-3.2.1.min.js",
                "~/Content/bootstrap-4.1.3/popper.js",
                "~/Content/bootstrap-4.1.3/bootstrap.min.js",
                "~/Scripts/greensock/TweenMax.min.js",
                "~/Scripts/greensock/TimelineMax.min.js",
                "~/Scripts/scrollmagic/scrollmagic.min.js",
                "~/Scripts/greensock/animation.gsap.min.js",
                "~/Scripts/greensock/ScrollToPlugin.min.jsv",
                "~/Scripts/OwlCarousel2-2.2.1/owl.carousel.js",
                "~/Scripts/parallax-js-master/parallax.min.js",
                "~/Scripts/Isotope/isotope.pkgd.min.js",
                "~/Scripts/Isotope/fitcolumns.js",
                "~/Scripts/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                 "~/Content/bootstrap-4.1.3/bootstrap.css",
                "~/Scripts/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Scripts/OwlCarousel2-2.2.1/owl.carousel.css",
                "~/Scripts/OwlCarousel2-2.2.1/owl.theme.default.css",
                "~/Scripts/OwlCarousel2-2.2.1/animate.css",
                "~/Content/main_styles.css",
                "~/Content/responsive.css"));

            //bundles.Add(new ScriptBundle("~/bundles/aStarJs").Include(
            //    "~/Scripts/jquery-3.2.1.min.js",
            //    "~/Content/bootstrap-4.1.3/popper.js",
            //    "~/Content/bootstrap-4.1.3/bootstrap.min.js",
            //    "~/Scripts/greensock/TweenMax.min.js",
            //    "~/Scripts/greensock/TimelineMax.min.js",
            //    "~/Scripts/scrollmagic/scrollmagic.min.js",
            //    "~/Scripts/greensock/animation.gsap.min.js",
            //    "~/Scripts/greensock/ScrollToPlugin.min.jsv",
            //    "~/Scripts/OwlCarousel2-2.2.1/owl.carousel.js",
            //    "~/Scripts/parallax-js-master/parallax.min.js",
            //    "~/Scripts/Isotope/isotope.pkgd.min.js",
            //    "~/Scripts/Isotope/fitcolumns.js",
            //    "~/Scripts/custom.js"));

            //bundles.Add(new StyleBundle("~/bundles/aStarCss").Include(
            //    "~/Content/bootstrap-4.1.3/bootstrap.css",
            //    "~/Scripts/font-awesome-4.7.0/css/font-awesome.min.css",
            //    "~/Scripts/OwlCarousel2-2.2.1/owl.carousel.css",
            //    "~/Scripts/OwlCarousel2-2.2.1/owl.theme.default.css",
            //    "~/Scripts/OwlCarousel2-2.2.1/animate.css",
            //    "~/Content/main_styles.css",
            //    "~/Content/responsive.css"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}
