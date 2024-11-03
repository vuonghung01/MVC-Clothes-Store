using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HungManhProject.Models;

namespace HungManhProject.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        dbBNGDataContext data = new dbBNGDataContext();
        public List<Cart> LayCart()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;
            }
            return lstCart;
        }
        public ActionResult ThemCart(int id, string strURL)
        {
            List<Cart> lstCart = LayCart();
            Cart sanpham = lstCart.Find(n => n.id == id);
            if (sanpham == null)
            {
                sanpham = new Cart(id);
                lstCart.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                tsl = lstCart.Sum(n => n.iSoluong);
            }
            return tsl;
        }
        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                tsl = lstCart.Count;
            }
            return tsl;
        }
        private double TongTien()
        {
            double tt = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                tt = lstCart.Sum(n => n.dThanhtien);
            }
            return tt;
        }
        public ActionResult Cart()
        {
            List<Cart> lstCart = LayCart();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstCart);
        }
        public ActionResult CartPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }
        public ActionResult XoaCart(int id)
        {
            List<Cart> lstCart = LayCart();
            Cart sanpham = lstCart.SingleOrDefault(n => n.id == id);
            if (sanpham != null)
            {
                lstCart.RemoveAll(n => n.id == id);
                return RedirectToAction("Cart");
            }
            return RedirectToAction("Cart");
        }
        public ActionResult CapnhatCart(int id, FormCollection collection)
        {
            List<Cart> lstCart = LayCart();
            Cart sanpham = lstCart.SingleOrDefault(n => n.id == id);
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(collection["txtSolg"].ToString());
            }
            return RedirectToAction("Cart");
        }
        public ActionResult XoaTatCaCart()
        {
            List<Cart> lstCart = LayCart();
            lstCart.Clear();
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public ActionResult PlaceOrder()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Account");
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart> lstGiohang = LayCart();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGiohang);
        }
        public ActionResult PlaceOrder(FormCollection collection)
        {
            Order dh = new Order();
            user kh = (user)Session["TaiKhoan"];
            Product product = new Product();
            Product_variant variant = new Product_variant();
            List<Cart> gh = LayCart();
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);
            dh.user_id = kh.user_id;
            dh.email = kh.email;
            dh.phone = kh.phone;
            dh.address = kh.address;
            dh.ngaydat = DateTime.Now;
            dh.ngaygiao = DateTime.Parse(ngaygiao);
            dh.giaohang = false;
            dh.thanhtoan = false;
            data.Orders.InsertOnSubmit(dh);
            data.SubmitChanges();
            foreach (var item in gh)
            {
                Order_detail ctdh = new Order_detail();
                ctdh.order_id = dh.order_id;
                ctdh.product_id = item.id;
                ctdh.quantity = item.iSoluong;
                ctdh.price = (decimal)item.gia;
                variant = data.Product_variants.Single(n => n.product_id == item.id);
                variant.quantity -= ctdh.quantity;
                data.SubmitChanges();
                data.Order_details.InsertOnSubmit(ctdh);
            }
            data.SubmitChanges();
            Session["Cart"] = null;
            return RedirectToAction("ConfirmOrder", "Cart");
        }
        public ActionResult ConfirmOrder()
        {
            return View();
        }

    }
}