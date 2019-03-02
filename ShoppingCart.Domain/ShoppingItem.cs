namespace ShoppingCart.Domain
{
    public class ShoppingItem
    {
        public ShoppingItem(Item item, int quantity)
        {
            ItemCode = item.Code;
            Quantity = quantity;
        }

        public string ItemCode { get; private set; }

        public int Quantity { get; private set; }
    }
}