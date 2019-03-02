using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Domain
{
    public class Shop
    {
        private List<Item> _items = new List<Item>();

        public Shop(List<ItemDto> itemDtos)
        {
            _items = itemDtos.Select(itemDto => new Item(
                code: itemDto.Code,
                price: new Money(value: itemDto.Price)
            )).ToList();
        }

        public IReadOnlyList<Item> Items {
            get => _items;
        }

        public decimal GetTotalCost(List<ShoppingItemDto> shoppingItemDtos)
        {
            return shoppingItemDtos.Sum(shoppingItemDto =>
            {
                var matchingItem = Items.SingleOrDefault(item => item.Code == shoppingItemDto.Item.Code);
                return matchingItem.DiscountedPrice.Value * shoppingItemDto.Quantity;
            });
        }

        public Item GetItem(string code)
        {
            return Items.Single(item => item.Code == code);
        }
    }
}
