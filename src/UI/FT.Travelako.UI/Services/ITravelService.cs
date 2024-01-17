using FT.Travelako.UI.Models.Travels;

namespace FT.Travelako.UI.Services
{
    public interface ITravelService
    {
        Task<TravelListingResponseModel> GetTravelsByUserId(string userId);
        Task<TravelListingResponseModel> GetTravels(string personalizasion = null);
        Task<TravelDetailResponseModel> GetTravelDetail(string id);
    }
}
