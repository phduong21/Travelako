using FT.Travelako.Services.CouponAPI.Base.Interface;

namespace FT.Travelako.Services.CouponAPI.Models.DTOs
{
    public class CouponDTO : IBaseRequestModel
    {
        public string Code { get; set; }
    }
}
