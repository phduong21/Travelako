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
			try
			{
				var result = new GenericAPIResponse();
				if (model != null && !string.IsNullOrWhiteSpace(model.Id))
				{
					if (Guid.TryParse(model.Id, out Guid id))
					{
						var existItem = await _travelRepository.GetByIdAsync(model.Id);
						if (existItem != null)
						{
							await _travelRepository.DeleteAsync(existItem);
							result.IsSuccess = true;
							result.Message = "Delete success";
						}
					}
					else
					{
						result.IsSuccess = false;
						result.Message = $"Could not find Travel with id {model.Id}";
					}
				}
				else
				{
					result.IsSuccess = false;
					result.Message = "Please input the Id of travel";
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