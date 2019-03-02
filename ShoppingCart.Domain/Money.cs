using System;

namespace ShoppingCart.Domain
{
    public class Money
    {
        public Money(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; private set; }

        public static Money operator *(Money money, int other)
        {
            return new Money(money.Value * other);
        }

        public static Money operator +(Money money, int other)
        {
            return new Money(money.Value + other);
        }

        public static Money operator *(Money money, double other)
        {
            return new Money(money.Value * Convert.ToDecimal(other));
        }

        public static Money operator -(Money money, Money other)
        {
            return new Money(money.Value - other.Value);
        }
    }
}