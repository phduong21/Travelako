namespace FT.Travelako.UI.Models.Coupon
{
    public class CouponResponseModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int Condition { get; set; }
        public int TimeExpried { get; set; }
    }
}
