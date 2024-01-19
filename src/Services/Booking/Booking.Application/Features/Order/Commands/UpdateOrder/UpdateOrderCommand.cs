using MediatR;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public string Id { get; set; }
        public int Status { get; set; }
    }
}
