namespace ShoppingCart.Web.Domain
{
    public class CouponTypeCodes
    {
        public static string PER_ITEM = "Per Item";
        public static string SHOPWIDE = "Shop-wide";
    }

    public class CouponType
    {
        public static CouponType Shopwide()
        {
            return new CouponType
            {
                TypeCode = CouponTypeCodes.SHOPWIDE
            };
        }

        public static CouponType PerItemType(ItemType itemType)
        {
            return new CouponType
            {
                TypeCode = CouponTypeCodes.PER_ITEM,
                ItemType = itemType
            };
        }

        public string TypeCode { get; private set; }

        public ItemType ItemType { get; private set; }
    }
}
