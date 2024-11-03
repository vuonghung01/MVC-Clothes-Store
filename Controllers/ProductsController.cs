using HungManhProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HungManhProject.Controllers
{
    public class ProductsController : Controller
    {
        dbBNGDataContext data = new dbBNGDataContext();
        // GET: products
        public ActionResult productDetail(int id)
        {
            var variantList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Chọn size"}
            };

            variantList.AddRange(data.Product_variants
                                    .Where( m => m.product_id == id)
                                    .Select(m => new SelectListItem
                                    {                                      
                                        Text = "Size: " + m.size
                                    }).Distinct());
            ViewBag.variantList = variantList;

            var detail = data.Products.Where(m => m.product_id == id).First();
            if (detail == null)
            {
                return RedirectToAction("ActionName", "ControllerName");
            }
            return View(detail);
        }
    }
}