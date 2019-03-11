using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Domain.Tests
{
  public class ShopTests
  {
    public Shop StartShop()
    {
      return new Shop(
        itemTypeDtos: new List<ItemTypeDto>
        {
          new ItemTypeDto { Code = "fruit" },
          new ItemTypeDto { Code = "vegetable" },
          new ItemTypeDto { Code = "meat" },
        },
        itemDtos: new List<ItemDto> {
          new ItemDto { Code = "banana", Price = 50, ItemTypeCode = "fruit" },
          new ItemDto { Code = "potato", Price = 50, ItemTypeCode = "vegetable" },
          new ItemDto { Code = "bacon", Price = 50, ItemTypeCode = "meat" }
        }
      );
    }

    [Fact]
    public void ShopContainsTenItems()
    {
      var itemDtos = new List<ItemDto> {
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

      var shop = new Shop(
        itemTypeDtos: new List<ItemTypeDto>(),
        itemDtos: itemDtos
      );

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
      item1.SetDiscountPercentage(new Percent(50));

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

    [Fact]
    public void ItemsCanOnSpecialByPercentAndAmountOnlyApplyHighestDiscount()
    {
      var shop = StartShop();

      var item1 = shop.GetItem(code: "banana");
      item1.SetDiscountAmount(new Money(25));
      item1.SetDiscountPercentage(new Percent(25));

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
    public void ItemsCanOnSpecialBySeveralWaysOnlyApplyHighestDiscount()
    {
      var shop = StartShop();
      shop.AddCoupon(
        new CouponDto
        {
          Code = "75PERCENT",
          DiscountPercentage = 75,
          CouponType = CouponTypeEnum.ShopWide,
        }
      );

      var item1 = shop.GetItem(code: "banana");
      item1.SetDiscountAmount(new Money(25));
      item1.SetDiscountPercentage(new Percent(25));

      var item2 = shop.GetItem(code: "potato");

      var shoppingItemDtos = new List<ShoppingItemDto>
      {
        new ShoppingItemDto { Item = item1, Quantity = 3 },
        new ShoppingItemDto { Item = item2, Quantity = 1 }
      };

      var totalCost = shop.GetTotalCost(
        shoppingItemDtos: shoppingItemDtos,
        couponCode: "75PERCENT"
      );

      Assert.Equal(50, totalCost);
    }

    [Fact]
    public void ItemsOfACertainTypeCanOnSpecialBySeveralWaysOnlyApplyHighestDiscount()
    {
      var shop = StartShop();
      shop.AddCoupon(
        new CouponDto {
          Code = "FRUITS75PERCENT",
          DiscountPercentage = 75,
          ItemTypeCode = "fruit",
          CouponType = CouponTypeEnum.PerItemType
        }
      );

      var item1 = shop.GetItem(code: "banana");
      item1.SetDiscountAmount(new Money(25));
      item1.SetDiscountPercentage(new Percent(25));

      var item2 = shop.GetItem(code: "potato");

      var shoppingItemDtos = new List<ShoppingItemDto>
      {
        new ShoppingItemDto { Item = item1, Quantity = 3 },
        new ShoppingItemDto { Item = item2, Quantity = 1 }
      };

      var totalCost = shop.GetTotalCost(
        shoppingItemDtos: shoppingItemDtos,
        couponCode: "FRUITS75PERCENT"
      );

      Assert.Equal(87.5m, totalCost);
    }
  }
}
