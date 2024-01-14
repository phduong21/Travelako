using FT.Travelako.UI.Models.Travels;

namespace FT.Travelako.UI.Services
{
    public interface ITravelService
    {
        Task<IEnumerable<TravelDetailResponseModel>> GetTravelsByUserId(string userId);
        Task<IEnumerable<TravelDetailResponseModel>> GetTravels();
        Task<TravelDetailResponseModel> GetTravelDetail(string id);
    }
}
