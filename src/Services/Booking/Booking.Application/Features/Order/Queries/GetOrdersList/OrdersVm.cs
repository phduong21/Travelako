namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrdersVm
    {
        public string Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
    }
}
