using ShoppingCart.Web.Domain;

namespace ShoppingCart.Web.Dtos
{
    public class ShoppingItem
    {
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}