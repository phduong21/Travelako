using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.TravelAPI.Models.DTOs;
using FT.Travelako.Services.TravelAPI.Repositories;

namespace FT.Travelako.Services.TravelAPI.Services
{
    public class UpdateTravelService : BaseService<UpdateTravelRequestDTO>
    {
        public UpdateTravelService(ITravelRepository travelRepository) : base(travelRepository)
        {
        }

        public override async Task<GenericAPIResponse> ExecuteApi(UpdateTravelRequestDTO model)
        {
            var result = new GenericAPIResponse();
            if (model != null && !string.IsNullOrWhiteSpace(model.Id))
            {
                var travel = await _travelRepository.GetById(new Guid(model.Id));
                if (travel != null)
                {
                    result.Result = travel;
                    result.IsSuccess = true;
                    result.Message = "Suucess";
                    return result;
                }
                else
                {
                    result.Result = null;
                    result.IsSuccess = true;
                    result.Message = $"Do not exist travel {model.Id}";
                }
            }
            else
            {
                result.Result = await _travelRepository.GetAll();
                result.IsSuccess = true;
                result.Message = "Success";
            }
            return result;
        }
    }
}