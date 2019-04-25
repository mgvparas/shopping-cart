using ShoppingCart.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Web.Repositories
{
    public class ItemRepository
    {
        private readonly List<Item> _items = new List<Item>();

        public void Save(Item item)
        {
            _items.Add(item);
        }

        public List<Item> GetAll()
        {
            return new List<Item>();
        }

        public Item Get(string itemCode)
        {
            return _items.SingleOrDefault(item => item.Code == itemCode);
        }
    }
}
