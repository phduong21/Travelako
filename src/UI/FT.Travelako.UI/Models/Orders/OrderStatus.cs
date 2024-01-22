namespace FT.Travelako.UI.Models.Orders
{
    public class OrderStatus
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
    }
    public enum Status
    {
        Draft,
        Payment,
        Cancel
    }
}
