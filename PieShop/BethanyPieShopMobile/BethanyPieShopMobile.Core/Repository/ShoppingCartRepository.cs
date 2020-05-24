using System;
using System.Collections.Generic;
using System.Text;
using BethanyPieShopMobile.Core.Model;

namespace BethanyPieShopMobile.Core.Repository
{
    public class ShoppingCartRepository
    {
        private static ShoppingCart _shoppingCart = new ShoppingCart();

        public void AddToShoppingCart(Pie pie, int amount)
        {
            var shoppingCartItems = new ShoppingCartItem()
            {
                Amount = amount,
                Pie = pie
            };
            _shoppingCart.CartItems.Add(shoppingCartItems);
        }

        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return _shoppingCart.CartItems;
        }
    }
}
