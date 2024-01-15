using FT.Travelako.UI.Base;
using FT.Travelako.UI.Infrastructure.API;
using FT.Travelako.UI.Models.Travels;

namespace FT.Travelako.UI.Services
{
    public class TravelService : ITravelService
    {
        private readonly string _remoteServiceBaseUrl = $"http://localhost:5400/travel/v1/Travel";
        private readonly IBaseApiClient _baseApiClient;

        public TravelService(IBaseApiClient baseApiClient)
        {
                _baseApiClient = baseApiClient;
        }
        public async Task<TravelDetailResponseModel> GetTravelDetail(string id)
        {
            var requestUri = ApiTravel.GetTravelDetail(_remoteServiceBaseUrl, id);
            var result = await _baseApiClient.GetAsync<TravelDetailResponseModel>(requestUri);
            return result;
        }

        public async Task<IEnumerable<TravelDetailResponseModel>> GetTravels()
        {
            var requestUri = ApiTravel.GetTravels(_remoteServiceBaseUrl);
            var result = await _baseApiClient.GetListAsync<TravelDetailResponseModel>(requestUri);
            return result;
        }

        public Task<IEnumerable<TravelDetailResponseModel>> GetTravelsByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
