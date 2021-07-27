using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_CuoiKy.Models;

namespace Web_CuoiKy.Controllers
{
    public class ShoppingCartController : Controller
    {
        Model_SP db = new Model_SP();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;

        }
        //Phuong thuowcs them 1 item san pham vao gio hang
        public ActionResult AddtoCart(int id)
        {
            var pro = db.San_Pham.SingleOrDefault(s => s.MASP == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult UpdateCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_SanPham"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                _t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order _order = new Order();
                _order.OrderDate = DateTime.Now;
                _order.CodeCus = (form["CodeCustomer"]);
                _order.Descriptions = form["Address_Delivery"];
                db.Orders.Add(_order);
                foreach(var item in cart.Items)
                {
                    Orderdetail _oder_detail = new Orderdetail();
                    _oder_detail.IdOrder = _order.IDOrder;
                    _oder_detail.IDMASP = item._shopping_sanpham.MASP;
                    _oder_detail.GIASALE = item._shopping_sanpham.GIA;
                    _oder_detail.SOLUONGSALE = item._shopping_quantity;
                    db.Orderdetails.Add(_oder_detail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("Shopping_Success", "ShoppingCart");
            }
            catch
            {
                return Content("Lỗi. Vui lòng kiểm tra lại mã khách hàng");
            }
        }
        public ActionResult Shopping_Success()
        {
            return View();
        }
    }
}