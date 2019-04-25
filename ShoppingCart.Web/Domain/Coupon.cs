namespace ShoppingCart.Web.Domain
{
    public class Coupon
    {
        public Coupon(string code, Percent discountPercentage, CouponType couponType)
        {
            Code = code;
            DiscountPercentage = discountPercentage;
            CouponType = couponType;
        }

        public string Code { get; private set; }

        public Percent DiscountPercentage { get; private set; }

        public CouponType CouponType { get; private set; }
    }
}