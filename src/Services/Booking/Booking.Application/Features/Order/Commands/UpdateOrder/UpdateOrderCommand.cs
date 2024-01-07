using MediatR;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public string Id { get; set; }
        public decimal TotalCost { get; set; }
        public int Status { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
    }
}
