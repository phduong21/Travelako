using FT.Travelako.Base.BaseModels;

namespace FT.Travelako.WebAPI.Services.IServices
{
    public interface ICouponService
    {
        Task<GenericAPIResponse> GetCoupon(string code);
    }
}
