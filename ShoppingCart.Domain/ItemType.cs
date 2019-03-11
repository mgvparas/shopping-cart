namespace ShoppingCart.Domain
{
    public class ItemType
    {
        public ItemType(string code)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}