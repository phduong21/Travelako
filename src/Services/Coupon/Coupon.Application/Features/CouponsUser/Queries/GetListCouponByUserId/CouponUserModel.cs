
namespace Coupon.Application.Features.CouponsUser.Queries.GetListCouponByUserId
{
    public class CouponUserModel
    {
        public string Id { get; set; }
        public string CouponId { get; set; }
        public string UserId { get; set; }
        public bool? IsUsed { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public TimeSpan TimeExpried { get; set; }
    }
}
