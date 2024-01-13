namespace FT.Travelako.UI.Models.Orders
{
    public class CheckoutModel
    {
        public decimal TotalCost { get; set; }
        public int Status { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
    }
}
