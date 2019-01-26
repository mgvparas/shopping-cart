using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Domain
{
    public class Shop
    {
        private List<ShoppingItem> shoppingItems = new List<ShoppingItem>();

        private List<ShoppingItemType> shoppingItemTypes = new List<ShoppingItemType>();

        public List<ShoppingItemType> ShoppingItemTypes
        {
            get => shoppingItemTypes;
            set => shoppingItemTypes = value;
        }
        public List<ShoppingItem> ShoppingItems
        {
            get => shoppingItems;
            set => shoppingItems = value;
        }

        public void AddItemType(ShoppingItemType shoppingItemType)
        {
            shoppingItemTypes.Add(shoppingItemType);
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
