using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.TravelAPI.Models.DTOs
{
    public class GetTravelRequestDTO : IBaseRequestModel
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
    }
}
