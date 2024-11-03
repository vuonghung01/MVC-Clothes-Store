using HungManhProject.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HungManhProject.Controllers
{
    public class CollectionsController : Controller
    {
        dbBNGDataContext data = new dbBNGDataContext();
        // GET: collections - var all_shop = from r in data.Products select r;
        public ActionResult Sneaker(string sortOrder)
        {
            ViewBag.NikeSortParm = String.IsNullOrEmpty(sortOrder) ? "Nike" : "";
            ViewBag.JordanSortParm = String.IsNullOrEmpty(sortOrder) ? "Jordan" : "";
            ViewBag.MLBSortParm = String.IsNullOrEmpty(sortOrder) ? "MLB" : "";
            ViewBag.YeezySortParm = String.IsNullOrEmpty(sortOrder) ? "Yeezy" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            var sneaker = from s in data.Products.Where(x => x.category_id == 5) select s;
            switch (sortOrder)
            {
                case "Nike":
                    var Nike = from s in data.Products.Where(x => x.category_id == 5 && x.title.Contains("Nike")) select s;
                    return View(Nike.ToList());
                    break;
                case "Jordan":
                    var Jordan = from s in data.Products.Where(x => x.category_id == 5 && x.title.Contains("Jordan")) select s;
                    return View(Jordan.ToList());
                    break;
                case "MLB":
                    var MLB = from s in data.Products.Where(x => x.category_id == 5 && x.title.Contains("MLB")) select s;
                    return View(MLB.ToList());
                    break;
                case "Yeezy":
                    var Yeezy = from s in data.Products.Where(x => x.category_id == 5 && x.title.Contains("Yeezy")) select s;
                    return View(Yeezy.ToList());
                    break;
                case "Price":
                    sneaker = sneaker.OrderBy(s => s.unit_price);
                    return View(sneaker.ToList());
                    break;
                case "price_desc":
                    sneaker = sneaker.OrderByDescending(s => s.unit_price);
                    return View(sneaker.ToList());
                    break;
                default:
                    return View(sneaker);
                    break;
            }
        }

        public ActionResult Slipper(string sortOrder)
        {
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            var slipper = from r in data.Products.Where(x => x.category_id == 6) select r;
            switch (sortOrder)
            {
                case "Price":
                    slipper = slipper.OrderBy(s => s.unit_price);
                    return View(slipper.ToList());
                    break;
                case "price_desc":
                    slipper = slipper.OrderByDescending(s => s.unit_price);
                    return View(slipper.ToList());
                    break;
                default:
                    return View(slipper);
                    break;
            }
        }
        
        public ActionResult Accessories()
        {
            var accessories = from r in data.Products.Where(x => x.category_id == 7) select r;
            return View(accessories);
        }

        public ActionResult Glasses()
        {
            var glasses = from r in data.Products.Where(x => x.category_id == 8) select r;
            return View(glasses);
        }

        public ActionResult Clothing()
        {
            var clothing = from r in data.Products.Where(x => x.category_id == 1 || x.category_id == 2 || x.category_id == 3 || x.category_id == 4) select r;
            return View(clothing);
        }

        public ActionResult Crep()
        {
            var crep = from r in data.Products.Where(x => x.category_id == 9) select r;
            return View(crep);
        }

        public ActionResult Jacket()
        {
            var all_jacket = from r in data.Products.Where(x => x.category_id == 2) select r;
            return View(all_jacket);
        }

        public ActionResult TShirt()
        {
            var all_tshirt = from r in data.Products.Where(x => x.category_id == 1) select r;
            return View(all_tshirt);
        }

        public ActionResult HoodieSweater()
        {
            var all_hoodiesweater = from r in data.Products.Where(x => x.category_id == 3) select r;
            return View(all_hoodiesweater);
        }
    }
}