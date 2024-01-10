using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.TravelAPI.Models.DTOs
{
    public class CreateTravelRequestDTO : IBaseRequestModel
    {
        public string Name { get; set; }
    }
}
