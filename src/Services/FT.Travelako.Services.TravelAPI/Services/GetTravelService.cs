using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.TravelAPI.Models.DTOs;
using FT.Travelako.Services.TravelAPI.Repositories;

namespace FT.Travelako.Services.TravelAPI.Services
{
	public class GetTravelService : BaseService<GetTravelRequestDTO>
	{
		public GetTravelService(ITravelRepository travelRepository) : base(travelRepository)
		{
		}

		public override async Task<GenericAPIResponse> ExecuteApi(GetTravelRequestDTO model)
		{
			try
			{
				var result = new GenericAPIResponse();
				if (model?.Id == null && model?.UserId == null)
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
							result.Message = "Success";
							return result;
						}
						else
						{
							result.Result = null;
							result.IsSuccess = true;
							result.Message = $"Do not exist travel {model.Id}";
						}
					}
					else if(!string.IsNullOrWhiteSpace(model.Id))
					{
						var travel = await _travelRepository.GetByIdAsync(model.Id);
						if (travel != null)
						{
							result.Result = travel;
							result.IsSuccess = true;
							result.Message = "Success";
							return result;
						}
						else
						{
							result.Result = null;
							result.IsSuccess = true;
							result.Message = $"Do not exist travel {model.Id}";
						}
					}
					else if(!string.IsNullOrWhiteSpace(model.Loaction))
					{
                        var travel = await _travelRepository.GetAsync(x => model.Loaction.Contains(x.Location));
                        if (travel != null)
                        {
                            result.Result = travel;
                            result.IsSuccess = true;
                            result.Message = "Success";
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
				return result;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}