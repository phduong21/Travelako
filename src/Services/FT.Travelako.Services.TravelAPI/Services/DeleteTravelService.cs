using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.TravelAPI.Models.DTOs;
using FT.Travelako.Services.TravelAPI.Repositories;

namespace FT.Travelako.Services.TravelAPI.Services
{
    public class DeleteTravelService : BaseService<DeleteTravelRequestDTO>
    {
        public DeleteTravelService(ITravelRepository travelRepository) : base(travelRepository)
        {
        }

        public override async Task<GenericAPIResponse> ExecuteApi(DeleteTravelRequestDTO model)
        {
            var result = new GenericAPIResponse();
            return result;
        }
    }
}