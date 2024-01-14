namespace FT.Travelako.UI.Models.Orders
{
    public class OrderResponseModel
    {
        public string Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
    }
}
