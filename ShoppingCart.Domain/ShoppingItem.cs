namespace ShoppingCart.Domain
{
    public class ShoppingItem
    {
        public ShoppingItem(int cost)
        {
            Cost = cost;
        }

        public int Cost { get; private set; }
    }
}