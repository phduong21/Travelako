using FT.Travelako.Common.BaseModels;
using FT.Travelako.EventBus.Messages.Events;
using FT.Travelako.Services.TravelAPI.Models.DTOs;
using FT.Travelako.Services.TravelAPI.Repositories;
using MassTransit;
using MassTransit.Transports;
using Newtonsoft.Json;
using System.Text.Json;

namespace FT.Travelako.Services.TravelAPI.Services
{
	public class GetTravelService : BaseService<GetTravelRequestDTO>
	{
        private readonly IPublishEndpoint _publishEndpoint;

        public GetTravelService(ITravelRepository travelRepository, IPublishEndpoint publishEndpoint) : base(travelRepository)
        {
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public override async Task<GenericAPIResponse> ExecuteApi(GetTravelRequestDTO model)
		{
			try
			{
				var result = new GenericAPIResponse();
				if (model == null && model?.Id == null && model?.UserId == null)
				{
					result.Result = await _travelRepository.GetAllAsync();
					result.IsSuccess = true;
					result.Message = "Success";
				}
				else
				{
					if (!string.IsNullOrWhiteSpace(model.UserId))
					{
						var travel = await _travelRepository.GetAsync(x => x.CreatedBy == model.UserId);
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
						var travel = await _travelRepository.GetByIdAsync(model.Id);
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
				}
    
				var eventMessage = JsonConvert.DeserializeObject<TravelEvent>(result.Data.ToString());
                await _publishEndpoint.Publish<TravelEvent>(eventMessage);


                return result;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}