using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Domain.Tests
{
    public class ShopTests
    {
        public Shop StartShop()
        {
            return new Shop(
                items: new List<Item> {
                    new Item(code: "banana", price: 50),
                    new Item(code: "potato", price: 50),
                    new Item(code: "bacon", price: 50)
                }
            );
        }

        [Fact]
        public void ShopContainsTenItems()
        {
            var items = new List<Item> {
                new Item(code: "a", price: 10),
                new Item(code: "b", price: 10),
                new Item(code: "c", price: 10),
                new Item(code: "d", price: 10),
                new Item(code: "e", price: 10),
                new Item(code: "f", price: 10),
                new Item(code: "g", price: 10),
                new Item(code: "h", price: 10),
                new Item(code: "i", price: 10),
                new Item(code: "j", price: 10),
            };

            var shop = new Shop(items: items);

            Assert.Equal(10, shop.Items.Count);
        }

        [Fact]
        public void UserEntersShoppingItemsAndGetsTheTotalCost()
        {
            var shop = StartShop();

            var item1 = shop.GetItem(code: "banana");
            var item2 = shop.GetItem(code: "potato");

            var shoppingItems = new List<ShoppingItem>
            {
                new ShoppingItem(item: item1, quantity: 3),
                new ShoppingItem(item: item2, quantity: 1)
            };

            var totalCost = shop.GetTotalCost(shoppingItems);

            Assert.Equal(200, totalCost);
        }

        [Fact]
        public void ItemsCanOnSpecialByPercent()
        {
            var shop = StartShop();

            var item1 = shop.GetItem(code: "banana");
            item1.SetDiscountPercentage(50);

            var item2 = shop.GetItem(code: "potato");

            var shoppingItems = new List<ShoppingItem>
            {
                new ShoppingItem(item: item1, quantity: 3),
                new ShoppingItem(item: item2, quantity: 1)
            };

            var totalCost = shop.GetTotalCost(shoppingItems);

            Assert.Equal(125, totalCost);
        }

        [Fact]
        public void ItemsCanOnSpecialByAmount()
        {
            var shop = StartShop();

            var item1 = shop.GetItem(code: "banana");
            item1.SetDiscountAmount(25);

            var item2 = shop.GetItem(code: "potato");

            var shoppingItems = new List<ShoppingItem>
            {
                new ShoppingItem(item: item1, quantity: 3),
                new ShoppingItem(item: item2, quantity: 1)
            };

            var totalCost = shop.GetTotalCost(shoppingItems);

            Assert.Equal(125, totalCost);
        }
    }
}
