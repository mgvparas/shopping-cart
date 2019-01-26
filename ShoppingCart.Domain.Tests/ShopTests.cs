using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingCart.Domain.Tests
{
    public class ShopTests
    {
        [Fact]
        public void ShopHasNoItemTypes()
        {
            var shop = new Shop();

            Assert.Equal(new List<ShoppingItemType>(), shop.ShoppingItemTypes);
        }

        [Fact]
        public void AddItemTypeToShop()
        {
            var shop = new Shop();

            shop.AddItemType(new ShoppingItemType());

            Assert.Single(shop.ShoppingItemTypes);
        }

        [Fact]
        public void ShopHasNoShoppingItems()
        {
            var shop = new Shop();

            Assert.Equal(new List<ShoppingItem>(), shop.ShoppingItems);
        }

        [Fact]
        public void AddShoppingItemToShop()
        {
            var shop = new Shop();

            shop.AddShoppingItem(new ShoppingItem(cost: 10));

            Assert.Single(shop.ShoppingItems);
        }

        [Fact]
        public void GetTotalCostFromSeveralShoppingItems()
        {
            var shop = new Shop();

            var totalCost = shop.GetTotalCost(
                new List<ShoppingItem>
                {
                    new ShoppingItem(cost: 10),
                    new ShoppingItem(cost: 10),
                    new ShoppingItem(cost: 10),
                }
            );

            Assert.Equal(30, totalCost);
        }
    }
}
