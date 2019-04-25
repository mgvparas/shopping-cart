using ShoppingCart.Web.Domain;

namespace ShoppingCart.Web.Dtos
{
    public class CouponDto
    {
        public string Code { get; set; }

        public double DiscountPercentage { get; set; }

        public string ItemTypeCode { get; set; }

        public CouponTypeEnum CouponType { get; set; }
    }
}