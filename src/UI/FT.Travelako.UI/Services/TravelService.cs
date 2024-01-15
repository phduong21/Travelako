using FT.Travelako.UI.Base;
using FT.Travelako.UI.Infrastructure.API;
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
			_baseApiClient = new BaseApiClient("http://host.docker.internal:5400");
		}

		public async Task<TravelResponseModel> GetTravelDetail(string id)
		{
			var requestUri = ApiTravel.GetTravelDetail(_remoteServiceBaseUrl, id);
			var result = await _baseApiClient.GetAsync<TravelResponseModel>(requestUri);
			return result;
		}

		public async Task<TravelListingResponseModel> GetTravels()
		{
			var requestUri = ApiTravel.GetTravels(_remoteServiceBaseUrl);
			var result = await _baseApiClient.GetAsync<TravelListingResponseModel>(requestUri);
			return result;
		}

		public Task<TravelListingResponseModel> GetTravelsByUserId(string userId)
		{
			throw new NotImplementedException();
		}
	}
}