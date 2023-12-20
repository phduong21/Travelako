using FT.Travelako.Base.BaseInterface;

namespace FT.Travelako.Services.CouponAPI.Models.DTOs
{
    public class GetCouponRequestDTO : IBaseRequestModel
    {
        public string Code { get; set; }
    }
}
