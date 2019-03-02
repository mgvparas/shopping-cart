using System;

namespace ShoppingCart.Domain
{
    public class Item
    {
        public Item(string code, decimal price)
        {
            Code = code;
            Price = price;
            DiscountedPrice = price;
        }

        public string Code { get; private set; }

        public decimal Price { get; private set; }

        public decimal DiscountedPrice { get; private set; }

        public void SetDiscountPercentage(double percentage)
        {
            var discountAmount = Price * (Convert.ToDecimal(percentage / 100));
            DiscountedPrice = Price - discountAmount;
        }

        public void SetDiscountAmount(decimal amount)
        {
            DiscountedPrice = Price - amount;
        }
    }
}