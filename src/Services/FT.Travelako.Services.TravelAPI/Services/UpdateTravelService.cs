using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.TravelAPI.Models;
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
				if(model!= null) 
				{
                    var existTravel = await _travelRepository.GetByIdAsync(model.Id);
					if(existTravel == null)
					{
						result.Result = null;
						result.IsSuccess = true;
						result.Message = $"Do not exist travel id {model.Id}";
						return result;
					}
                    var travel = new Travel();
                    if (!string.IsNullOrWhiteSpace(travel.Title))
					{
						existTravel.Title = travel.Title;
					}
                    if (!string.IsNullOrWhiteSpace(travel.Description))
                    {
                        existTravel.Description = travel.Description;
                    }
                    if (!string.IsNullOrWhiteSpace(travel.Thumbnail))
                    {
                        existTravel.Thumbnail = travel.Thumbnail;
                    }
                    if (!string.IsNullOrWhiteSpace(travel.Images))
                    {
                        existTravel.Images = travel.Images;
                    }
                    if (!string.IsNullOrWhiteSpace(travel.Content))
                    {
                        existTravel.Content = travel.Content;
                    }
                    if (!string.IsNullOrWhiteSpace(travel.Province))
                    {
                        existTravel.Province = travel.Province;
                    }
					if (!string.IsNullOrWhiteSpace(travel.Location))
					{
						existTravel.Location = travel.Location;
					}
                    if (!string.IsNullOrWhiteSpace(travel.Tag))
                    {
                        existTravel.Tag = travel.Tag;
                    }
                    if (!string.IsNullOrWhiteSpace(travel.Status.ToString()))
                    {
                        existTravel.Status = travel.Status;
                    }
                    if (!string.IsNullOrWhiteSpace(travel.HotelTitle))
                    {
                        existTravel.HotelTitle = travel.HotelTitle;
                    }
                    if (!string.IsNullOrWhiteSpace(travel.HotelPrice))
                    {
                        existTravel.HotelPrice = travel.HotelPrice;
                    }
                    if (!string.IsNullOrWhiteSpace(travel.TrafficType.ToString()))
                    {
                        existTravel.TrafficType = travel.TrafficType;
                    }
                    await _travelRepository.UpdateAsync(existTravel);
                    result.Result = existTravel;
                    result.IsSuccess = true;
                    result.Message = "Success";
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