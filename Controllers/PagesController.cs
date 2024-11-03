using System.Web.Mvc;

namespace HungManhProject.Controllers
{
    public class PagesController : Controller
    {
        // GET: pages
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ReturnPolicy()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}