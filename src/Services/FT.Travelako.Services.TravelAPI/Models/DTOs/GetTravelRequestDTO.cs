using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.TravelAPI.Models.DTOs
{
    public class GetTravelRequestDTO : IBaseRequestModel
    {
        public string? UserId { get; set; }
        public string? Loaction { get; set; }
    }
}
