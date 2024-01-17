using FT.Travelako.UI.Models.Users;

namespace FT.Travelako.UI.Models.Travels.ViewModel
{
    public class TravelDetailViewModel
    {
        public TravelDetailModel TravelDetail { get; set; }
        public TravelListingResponseModel RecentTravels { get; set; }
        public UserDetailResponseModelNew Author { get; set; }
    }
}
