﻿using FT.Travelako.UI.Base;
using FT.Travelako.UI.Infrastructure.API;
using FT.Travelako.UI.Models.Authentication;
using FT.Travelako.UI.Models.Travels;

namespace FT.Travelako.UI.Services
{
	public class TravelService : ITravelService
	{
		private readonly string _remoteServiceBaseUrl = "travel/v1/Travel";
		private readonly IBaseApiClient _baseApiClient;
		private readonly HttpClient _client;

		public TravelService(HttpClient client)
		{
			_client = client;
			_baseApiClient = new BaseApiClient("http://host.docker.internal:5400", new HttpContextAccessor());
		}

		public async Task<TravelDetailResponseModel> GetTravelDetail(string id)
		{
			var requestUri = ApiTravel.GetTravelDetail(_remoteServiceBaseUrl, id);
			var result = await _baseApiClient.GetAsync<TravelDetailResponseModel>(requestUri);
			return result;
		}

		public async Task<TravelListingResponseModel> GetTravels(string personalizasion = null)
		{
			var requestUri = ApiTravel.GetTravels(_remoteServiceBaseUrl);
			var result = await _baseApiClient.GetAsync<TravelListingResponseModel>(requestUri);
			if(personalizasion != null && !string.IsNullOrWhiteSpace(personalizasion))
			{
				result.result = result.result.Where(x => personalizasion.ToLower().Contains(x.location.ToLower())).ToList();

            }
			return result;
		}

		public async Task<TravelListingResponseModel> GetTravelsByUserId(string userId)
		{
            var requestUri = ApiTravel.GetTravelsByUserId(_remoteServiceBaseUrl, userId);
            var result = await _baseApiClient.GetAsync<TravelListingResponseModel>(requestUri);
            return result;
        }

		//private UserModel GetUser(string userId) 
		//{
		//	var allUser = await _userService.GetAllUsers();
		//	var user = await _userService.GetUserInformation("duong123");
		//	var updateUser = await _userService.UpdateUser(new Models.Users.UpdateUserModel
		//	{
		//		Id = "69121893-3AFC-4F92-85F3-40BB5E7C7E29",
		//		FirstName = "duong updated 1601"
		//	});
		//	await _userService.DeleteUser("4f075e3d-a935-45b2-8667-08dc1526dd2b");

		//	var personalize = await _userService.GetPersonalizeUser("4f075e3d-a935-45b2-8667-08dc1526dd2b");
		//	await _userService.UpdatePersonalizeUser(new Models.Users.PersonalizeModel
		//	{
		//		Id = "4f075e3d-a935-45b2-8667-08dc1526dd2b",
		//		Location = "Danang"
		//	});
		//}
    }
}