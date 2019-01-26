using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Domain
{
    public class Shop
    {
        private List<ShoppingItem> shoppingItems = new List<ShoppingItem>();

        public List<ShoppingItem> ShoppingItems
        {
            get => shoppingItems;
            set => shoppingItems = value;
        }

        public void AddShoppingItem(ShoppingItem shoppingItem)
        {
            shoppingItems.Add(shoppingItem);
        }

        public object GetTotalCost(List<ShoppingItem> shoppingItems)
        {
            return shoppingItems
                .Select(item => item.Cost)
                .Sum();
        }
    }
}
