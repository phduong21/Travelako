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
			try
			{
				var result = new GenericAPIResponse();

				return result;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}