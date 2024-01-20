using FT.Travelako.UI.Models.Coupon;

namespace FT.Travelako.UI.Services
{
    public interface ICouponService
    {
        Task<List<CouponResponseModel>> GetCouponByUserId(string userId, string businessUserId);
    }
}