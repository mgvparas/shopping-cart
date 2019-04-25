using ShoppingCart.Web.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Web.Domain
{
  public class Shop
  {
    private List<ItemType> _itemTypes = new List<ItemType>();

    private readonly List<Item> _items = new List<Item>();

    private List<Coupon> _coupons = new List<Coupon>();

    public Shop(List<ItemTypeDto> itemTypeDtos, List<ItemDto> itemDtos)
    {
      _itemTypes = itemTypeDtos
        .Select(itemTypeDto => new ItemType(itemTypeDto.Code))
        .ToList();

      _items = itemDtos
        .Select(itemDto => {
          return new Item(
            code: itemDto.Code,
            price: new Money(value: itemDto.Price),
            itemType: _itemTypes.SingleOrDefault(type => type.Code == itemDto.ItemTypeCode)
          );
        })
        .ToList();
    }

    public IReadOnlyList<Item> Items
    {
      get => _items;
    }

    public IReadOnlyList<Coupon> Coupons
    {
      get => _coupons;
    }

    public decimal GetTotalCost(List<ShoppingItem> shoppingItems, string couponCode = "")
    {
      if (!couponCode.IsNullOrWhiteSpace())
      {
        ApplyCoupon(couponCode);
      }

      return shoppingItems.Sum(shoppingItemDto =>
      {
        Item matchingItem = Items.SingleOrDefault(item => item.Code.ToLower() == shoppingItemDto.Item.Code.ToLower());
        return matchingItem.DiscountedPrice.Value * shoppingItemDto.Quantity;
      });
    }

    public Item GetItem(string code)
    {
      return Items.Single(item => item.Code == code);
    }

    public void AddCoupon(CouponDto couponDto)
    {
      CouponType couponType = null;
      if (couponDto.CouponType == CouponTypeEnum.ShopWide)
      {
        couponType = CouponType.Shopwide();
      }
      else if (couponDto.CouponType == CouponTypeEnum.PerItemType)
      {
        ItemType couponItemType = _itemTypes.SingleOrDefault(itemType => itemType.Code == couponDto.ItemTypeCode);
        couponType = CouponType.PerItemType(couponItemType);
      }

      if (couponType != null)
      {
        _coupons.Add(
          new Coupon(
            code: couponDto.Code,
            discountPercentage: new Percent(couponDto.DiscountPercentage),
            couponType: couponType
          )
        );
      }
    }

    private void ApplyCoupon(string code)
    {
      Coupon matchingCoupon = _coupons.SingleOrDefault(coupon => coupon.Code == code);

      List<Item> items = _items;
      if (matchingCoupon.CouponType.TypeCode == CouponTypeCodes.PER_ITEM)
      {
        items = items
          .Where(item => item.ItemType.Code == matchingCoupon.CouponType.ItemType.Code)
          .ToList();
      }

      foreach (Item item in items)
      {
        item.SetDiscountPercentage(matchingCoupon.DiscountPercentage);
      }
    }
  }
}
