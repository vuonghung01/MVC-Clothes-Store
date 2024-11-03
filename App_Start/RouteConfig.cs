using System.Web.Mvc;
using System.Web.Routing;

namespace HungManhProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AboutUs",
                url: "pages/about-us",
                defaults: new { controller = "Pages", action = "AboutUs", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ReturnPolicy",
                url: "pages/chinh-sach-doi-tra",
                defaults: new { controller = "Pages", action = "ReturnPolicy", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Search",
                url: "search",
                defaults: new { controller = "Search", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Sneaker",
                url: "collections/sneaker",
                defaults: new { controller = "Collections", action = "Sneaker", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Slipper",
                url: "collections/slipper",
                defaults: new { controller = "Collections", action = "Slipper", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Accessories",
                url: "collections/accessories",
                defaults: new { controller = "Collections", action = "Accessories", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Glasses",
                url: "collections/glasses",
                defaults: new { controller = "Collections", action = "Glasses", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Clothing",
                url: "collections/clothing",
                defaults: new { controller = "Collections", action = "Clothing", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Crep",
                url: "collections/crep",
                defaults: new { controller = "Collections", action = "Crep", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Jacket",
                url: "collections/jacket",
                defaults: new { controller = "Collections", action = "Jacket", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TShirt",
                url: "collections/t-shirt",
                defaults: new { controller = "Collections", action = "TShirt", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HoodieSweater",
                url: "collections/hoodie-sweater",
                defaults: new { controller = "Collections", action = "HoodieSweater", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "index",
                url: "index",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "detail",
                url: "products/{id}/{slug}",
                defaults: new { controller = "Products", action = "productDetail", id = UrlParameter.Optional , slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "cart",
                url: "cart",
                defaults: new { controller = "Cart", action = "Cart"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
