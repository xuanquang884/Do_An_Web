using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_CuoiKy.Models
{

    public class CartItem
    {
        public San_Pham _shopping_sanpham { get; set; }
        public int _shopping_quantity { set; get; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(San_Pham _sp, int _quantity = 1)
        {
            var item = Items.FirstOrDefault(s => s._shopping_sanpham.MASP == _sp.MASP);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _shopping_sanpham = _sp,
                    _shopping_quantity = _quantity
                });
            }
            else
            {
                item._shopping_quantity += _quantity;
            }
        }
        public void Update_Quantity(int id, int quantity)
        {
            var item = items.Find(s => s._shopping_sanpham.MASP == id);
            if (item != null)
            {
                item._shopping_quantity = quantity;
            }
        }
        public double Total_Money()
        {
            var total = items.Sum(s => s._shopping_sanpham.GIA * s._shopping_quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._shopping_sanpham.MASP == id);
        }
        public int Total_Quantity()
        {
            return items.Sum(s => s._shopping_quantity);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}