using System;
using System.Collections.Generic;
using System.Text;

namespace BethanyPieShopMobile.Core.Model
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new List<ShoppingCartItem>();
        }
        public List<ShoppingCartItem> CartItems { get; set; }
    }
}
