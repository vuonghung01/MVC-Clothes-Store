using HungManhProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HungManhProject.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        dbBNGDataContext data = new dbBNGDataContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCategory()
        {
            if (Session["userAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            var list = from r in data.Categories select r;
            return View(list);
        }

        public ActionResult AddCategory()
        {
            if (Session["userAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(FormCollection collection, Category c)
        {
            var E_category_name = collection["category_name"];
            if (string.IsNullOrEmpty(E_category_name))
            {
                ViewData["Error"] = "Không được để trống!";
            }
            else
            {
                c.category_name = E_category_name.ToString();
                data.Categories.InsertOnSubmit(c);
                data.SubmitChanges();
                return RedirectToAction("ListCategory");
            }
            return RedirectToAction("ListCategory");
        }

        public ActionResult ListProduct()
        {
            if (Session["userAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            var list = from r in data.Products select r;
            return View(list);
        }

        public ActionResult AddProduct()
        {
            if (Session["userAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(FormCollection collection, Product p)
        {
            var E_ten = collection["title"];
            var E_mota = collection["description"];
            var E_chatlieu = collection["chatlieu"];
            var E_kithuat = collection["kithuat"];
            var E_size = collection["size"];
            var E_unitprice = Convert.ToDecimal(collection["unit_price"]);
            var E_img = collection["img"];
            var E_img2 = collection["img2"];
            var E_img_loop = collection["img_loop"];
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Không được để trống!";
            }
            else
            {
                p.title = E_ten.ToString();
                p.description = E_mota.ToString();
                p.chatlieu = E_chatlieu.ToString();
                p.kithuat = E_kithuat.ToString();
                p.size = E_size.ToString();
                p.unit_price = E_unitprice;
                p.img = E_img.ToString();
                p.img2 = E_img2.ToString();
                p.img_loop = E_img_loop.ToString();
                p.ngaycapnhat = E_ngaycapnhat;
                data.Products.InsertOnSubmit(p);
                data.SubmitChanges();
                return RedirectToAction("ListProduct");
            }
            return RedirectToAction("ListProduct");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            var del = data.Products.Where(m => m.product_id == id).First();
            data.Products.DeleteOnSubmit(del);
            data.SubmitChanges();
            return RedirectToAction("ListProduct");
        }

        [HttpPost]
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Areas/Admin/Content/images/" + file.FileName));
            return "/Areas/Admin/Content/images/" + file.FileName;
        }
    }
}