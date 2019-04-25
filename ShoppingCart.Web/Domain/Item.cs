namespace ShoppingCart.Web.Domain
{
  public class Item
  {
    public Item(string code, Money price, ItemType itemType)
    {
      Code = code;
      Price = price;
      DiscountedPrice = price;
      ItemType = itemType;
    }

    public string Code { get; private set; }

    public Money Price { get; private set; }

    public Money DiscountedPrice { get; private set; }

    public ItemType ItemType { get; set; }

    public void SetDiscountPercentage(Percent percentage)
    {
      Money discountAmount = Price * percentage.DecimalValue;

      ApplyDiscount(discountAmount);
    }

    public void SetDiscountAmount(Money amount)
    {
      ApplyDiscount(amount);
    }

    private void ApplyDiscount(Money discountAmount)
    {
      Money discountedPrice = Price - discountAmount;

      DiscountedPrice = discountedPrice < DiscountedPrice
        ? discountedPrice
        : DiscountedPrice;
    }
  }
}