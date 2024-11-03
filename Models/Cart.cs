using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HungManhProject.Models
{
    public class Cart
    {
        dbBNGDataContext data = new dbBNGDataContext();
        public int id { get; set; }
        [Display(Name = "Tên")]
        public string ten { get; set; }
        [Display(Name = "Hình")]
        public string hinh { get; set; }
        [Display(Name = "Giá bán")]
        public Double gia { get; set; }
        [Display(Name = "Số lượng")]
        public int iSoluong { get; set; }
        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get { return iSoluong * gia; }
        }
        public Cart(int id)
        {
            this.id = id;
            Product product = data.Products.Single(n => n.product_id == id);
            ten = product.title;
            hinh = product.img_loop;
            gia = double.Parse(product.unit_price.ToString());
            iSoluong = 1;
        }
    }
}