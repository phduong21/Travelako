using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.BookingAPI.Models.DTOs
{
    public class GetBookingRequestDTO : IBaseRequestModel
    {
        public string? Code { get; set; }
    }
}
