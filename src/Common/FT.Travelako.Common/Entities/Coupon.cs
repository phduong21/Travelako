namespace FT.Travelako.Common.Entities
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Discount { get; set; }
        public int Condition { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public Guid UserCouponId { get; set; }
        public UserCoupon UserCoupon { get; set; }
    }
}