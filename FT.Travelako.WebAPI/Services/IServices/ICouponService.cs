using FT.Travelako.WebAPI.Models.Common;

namespace FT.Travelako.WebAPI.Services.IServices
{
    public interface ICouponService
    {
        Task<GenericAPIResponse> GetCoupon(string code);
    }
}
