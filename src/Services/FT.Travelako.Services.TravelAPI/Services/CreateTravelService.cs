using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.TravelAPI.Models.DTOs;
using FT.Travelako.Services.TravelAPI.Repositories;

namespace FT.Travelako.Services.TravelAPI.Services
{
    public class CreateTravelService : BaseService<CreateTravelRequestDTO>
    {
        public CreateTravelService(ITravelRepository travelRepository) : base(travelRepository)
        {
        }

        public override async Task<GenericAPIResponse> ExecuteApi(CreateTravelRequestDTO model)
        {
            var result = new GenericAPIResponse();
            return result;
        }
    }
}