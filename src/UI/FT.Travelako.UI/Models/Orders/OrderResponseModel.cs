using FT.Travelako.UI.Models.Travels;

namespace FT.Travelako.UI.Models.Orders
{
    public class OrderResponseModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public string TourName { get; set; }
        public int GuestSize { get; set; }
        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
    }

    public class OrderListingResponseModel : BaseApiResponseModel
    {
        public List<OrderResponseModel> result { get; set; }
    }

    public class OrderDetailsResponseModel : BaseApiResponseModel
    {
        public OrderResponseModel result { get; set; }
    }
}
