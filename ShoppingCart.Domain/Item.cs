using System;

namespace ShoppingCart.Domain
{
    public class Item
    {
        public Item(string code, Money price)
        {
            Code = code;
            Price = price;
            DiscountedPrice = price;
        }

        public string Code { get; private set; }

        public Money Price { get; private set; }

        public Money DiscountedPrice { get; private set; }

        public void SetDiscountPercentage(double percentage)
        {
            var discountAmount = Price * (percentage / 100);
            DiscountedPrice = Price - discountAmount;
        }

        public void SetDiscountAmount(Money amount)
        {
            DiscountedPrice = Price - amount;
        }
    }
}