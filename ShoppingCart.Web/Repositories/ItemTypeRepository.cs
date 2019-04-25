using ShoppingCart.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Web.Repositories
{
    public class ItemTypeRepository
    {
        private List<ItemType> _itemTypes = new List<ItemType>();

        public void Save(ItemType itemType)
        {
            _itemTypes.Add(itemType);
        }

        public List<ItemType> GetAll()
        {
            return _itemTypes;
        }

        public ItemType Get(string code)
        {
            return _itemTypes.SingleOrDefault(itemType => itemType.Code == code);
        }
    }
}
