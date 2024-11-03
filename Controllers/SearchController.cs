using HungManhProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HungManhProject.Controllers
{
    public class SearchController : Controller
    {
        dbBNGDataContext data = new dbBNGDataContext();
        // GET: Search
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchProduct(string name, string strURL)
        {
            List<Product> lstCart = new List<Product>();
            Product sanpham = lstCart.Find(n => n.title.Contains(name));
            if (sanpham == null)
            {
                lstCart.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                return Redirect(strURL);
            }
        }
    }
}