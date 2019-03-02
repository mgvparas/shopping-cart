using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Domain.Tests
{
    public class ShopTests
    {
        public Shop StartShop()
        {
            return new Shop(
                itemDtos: new List<ItemDto> {
                    new ItemDto { Code = "banana", Price = 50 },
                    new ItemDto { Code = "potato", Price = 50 },
                    new ItemDto { Code = "bacon", Price = 50 }
                }
            );
        }

        [Fact]
        public void ShopContainsTenItems()
        {
            var items = new List<ItemDto> {
                new ItemDto { Code = "a", Price = 10 },
                new ItemDto { Code = "b", Price = 10 },
                new ItemDto { Code = "c", Price = 10 },
                new ItemDto { Code = "d", Price = 10 },
                new ItemDto { Code = "e", Price = 10 },
                new ItemDto { Code = "f", Price = 10 },
                new ItemDto { Code = "g", Price = 10 },
                new ItemDto { Code = "h", Price = 10 },
                new ItemDto { Code = "i", Price = 10 },
                new ItemDto { Code = "j", Price = 10 },
            };

            var shop = new Shop(itemDtos: items);

            Assert.Equal(10, shop.Items.Count);
        }

        [Fact]
        public void UserEntersShoppingItemsAndGetsTheTotalCost()
        {
            var shop = StartShop();

            var item1 = shop.GetItem(code: "banana");
            var item2 = shop.GetItem(code: "potato");

            var shoppingItemDtos = new List<ShoppingItemDto>
            {
                new ShoppingItemDto { Item = item1, Quantity = 3 },
                new ShoppingItemDto { Item = item2, Quantity = 1 }
            };

            var totalCost = shop.GetTotalCost(shoppingItemDtos);

            Assert.Equal(200, totalCost);
        }

        [Fact]
        public void ItemsCanOnSpecialByPercent()
        {
            var shop = StartShop();

            var item1 = shop.GetItem(code: "banana");
            item1.SetDiscountPercentage(50);

            var item2 = shop.GetItem(code: "potato");

            var shoppingItemDtos = new List<ShoppingItemDto>
            {
                new ShoppingItemDto { Item = item1, Quantity = 3 },
                new ShoppingItemDto { Item = item2, Quantity = 1 }
            };

            var totalCost = shop.GetTotalCost(shoppingItemDtos);

            Assert.Equal(125, totalCost);
        }

        [Fact]
        public void ItemsCanOnSpecialByAmount()
        {
            var shop = StartShop();

            var item1 = shop.GetItem(code: "banana");
            item1.SetDiscountAmount(new Money(25));

            var item2 = shop.GetItem(code: "potato");

            var shoppingItemDtos = new List<ShoppingItemDto>
            {
                new ShoppingItemDto { Item = item1, Quantity = 3 },
                new ShoppingItemDto { Item = item2, Quantity = 1 }
            };

            var totalCost = shop.GetTotalCost(shoppingItemDtos);

            Assert.Equal(125, totalCost);
        }
    }
}
