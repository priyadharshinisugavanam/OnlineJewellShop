using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineJewellShop.BL
{
    public interface IShoppingCartBL
    {
        void AddToCart(Product product);
        int RemoveFromCart(int id);

        void EmptyCart();
        int GetCount();
        List<CartEntity> GetCartItems();
        decimal GetTotal();
        int CreateOrder(OrderEntity order);
        string GetCartId(HttpContextBase context);
        void MigrateCart(string userName);


    }
    public class ShoppingCartBL:IShoppingCartBL
    {

        IShoppingCart Shopping;
        public ShoppingCartBL()
        {
            Shopping = new ShoppingCart();
        }
        public void AddToCart(Product product)
        {
            Shopping.AddToCart(product);
        }
        public int RemoveFromCart(int id)
        {
            return Shopping.RemoveFromCart(id);
        }
        public void EmptyCart()
        {
            Shopping.EmptyCart();
        }
        public int GetCount()
        {
            return Shopping.GetCount();
        }
        public List<CartEntity> GetCartItems()
        {
            return Shopping.GetCartItems();
        }
        public decimal GetTotal()
        {
            return Shopping.GetTotal();
        }
        public int CreateOrder(OrderEntity order)
        {
            return Shopping.CreateOrder(order);
        }
        public string GetCartId(HttpContextBase context)
        {
            return Shopping.GetCartId(context);
        }
        public void MigrateCart(string userName)
        {
            Shopping.MigrateCart(userName);
        }
    }
}
