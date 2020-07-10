using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJewellShop.Models
{
    public class ShoppingCartViewModel
    {
        public List<CartEntity> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}