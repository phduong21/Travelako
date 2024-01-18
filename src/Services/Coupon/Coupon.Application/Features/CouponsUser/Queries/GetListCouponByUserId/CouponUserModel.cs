
namespace Coupon.Application.Features.CouponsUser.Queries.GetListCouponByUserId
{
    public class CouponUserModel
    {
        public CouponUserModel()
        {
            
        }

        public CouponUserModel(string id, string couponId, string userId, bool isUsed, string title, string code, int discount, int timeExpired)
        {
            Id = id;
            CouponId = couponId;
            UserId = userId;
            Title = title;
            Code = code;
            Discount = discount;
            TimeExpried = timeExpired;
        }
        public string Id { get; set; }
        public string CouponId { get; set; }
        public string UserId { get; set; }
        public bool? IsUsed { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int TimeExpried { get; set; }
    }
}
