using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.TravelAPI.Models;
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
            var travel = new Travel()
            {
				Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                Images = model.Images,
                Thumbnail = model.Thumbnail,
                HotelPrice = model.HotelPrice,
                HotelTitle = model.HotelTitle,
                Location = model.Location,
                Tag = model.Tag,
                Status = model.Status,
                TrafficType = model.TrafficType,
                Province = model.Province,
                CreatedBy = new Guid().ToString(),
                CreatedDate = DateTime.Now,

            };
            var travelResult = await _travelRepository.AddAsync(travel);
            if(travelResult != null) 
            { 
                result.Result = travelResult;
                result.IsSuccess = true;
                result.Message = "Suucess";
            }
            return result;
        }
    }
}