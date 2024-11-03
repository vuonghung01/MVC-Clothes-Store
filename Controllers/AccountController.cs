using HungManhProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HungManhProject.Controllers
{
    public class AccountController : Controller
    {
        dbBNGDataContext data = new dbBNGDataContext();
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection, user kh)
        {
            var hoten = collection["name"];
            var tendangnhap = collection["username"];
            var matkhau = collection["password"];
            var MatKhauXacNhan = collection["passwordconfirm"];
            var email = collection["email"];
            var diachi = collection["address"];
            var dienthoai = collection["phone"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["birthdate"]);
            var isUsernameAlreadyExists = data.users.Any(x => x.username == tendangnhap);
            var isEmailAlreadyExists = data.users.Any(x => x.email == email);
            if (isEmailAlreadyExists || isUsernameAlreadyExists)
            {
                ModelState.AddModelError("RegisterError", "Tên đăng nhập hoặc email đã được sử dụng!");
                return View();
            }
            else
            {
                if (String.IsNullOrEmpty(MatKhauXacNhan))
                {
                    ViewData["Nhappasswordconfirm"] = "Phải nhập mật khẩu xác nhận!";
                }
                else
                {
                    if (!matkhau.Equals(MatKhauXacNhan))
                    {
                        ViewData["passwordconfirm"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau";
                    }
                    else
                    {
                        kh.name = hoten;

                        kh.username = tendangnhap;
                        kh.password = matkhau;
                        kh.email = email;
                        kh.address = diachi;
                        kh.phone = dienthoai;
                        kh.birthdate = DateTime.Parse(ngaysinh);
                        data.users.InsertOnSubmit(kh);

                        data.SubmitChanges();

                        return RedirectToAction("Login");
                    }
                }
            }
            return this.Register();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendangnhap = collection["username"];
            var matkhau = collection["password"];
            user kh = data.users.SingleOrDefault(n => n.username == tendangnhap && n.password == matkhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                Session["name"] = kh.name;
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session.Abandon();
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

    }
}