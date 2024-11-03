using HungManhProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HungManhProject.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        dbBNGDataContext data = new dbBNGDataContext();
        // GET: Admin/Account
        public ActionResult ListAcc()
        {
            if (Session["userAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            var list = from r in data.users select r;
            return View(list);
        }
    }
}