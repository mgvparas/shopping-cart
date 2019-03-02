using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Domain
{
    public class Shop
    {
        private List<Item> _items = new List<Item>();

        public Shop(List<Item> items)
        {
            _items = items;
        }

        public List<Item> Items {
            get => _items;
            set => _items = value;
        }

        public decimal GetTotalCost(List<ShoppingItem> shoppingItems)
        {
            return shoppingItems.Sum(shoppingItem =>
            {
                var matchingItem = Items.SingleOrDefault(item => item.Code == shoppingItem.ItemCode);
                return matchingItem.DiscountedPrice * shoppingItem.Quantity;
            });
        }

        public Item GetItem(string code)
        {
            return Items.Single(item => item.Code == code);
        }
    }
}
