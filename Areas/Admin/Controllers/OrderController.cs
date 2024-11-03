using HungManhProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HungManhProject.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        dbBNGDataContext data = new dbBNGDataContext();
        // GET: Admin/Order
        public ActionResult ListOrder()
        {
            if (Session["userAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            var list = from r in data.Orders select r;
            return View(list);
        }
    }
}