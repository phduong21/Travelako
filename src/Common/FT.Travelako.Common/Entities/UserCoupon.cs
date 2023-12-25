namespace FT.Travelako.Common.Entities
{
    public class UserCoupon
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Coupon Coupon { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Coupon> Coupons { get; set; }
    }
}