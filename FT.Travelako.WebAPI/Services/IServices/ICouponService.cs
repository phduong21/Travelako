using FT.Travelako.WebAPI.Base.Models;

namespace FT.Travelako.WebAPI.Services.IServices
{
    public interface ICouponService
    {
        Task<GenericAPIResponse> GetCoupon(string code);
    }
}
