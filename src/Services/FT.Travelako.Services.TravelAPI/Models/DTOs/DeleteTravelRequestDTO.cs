using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.TravelAPI.Models.DTOs
{
    public class DeleteTravelRequestDTO : IBaseRequestModel
    {
        public string Id { get; set; }
    }
}
