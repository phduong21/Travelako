using FT.Travelako.UI.Models.Travels;

namespace FT.Travelako.UI.Services
{
    public interface ITravelService
    {
        Task<TravelListingResponseModel> GetTravelsByUserId(string userId);
        Task<TravelListingResponseModel> GetTravels();
        Task<TravelResponseModel> GetTravelDetail(string id);
    }
}
