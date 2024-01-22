using Booking.Application.Models;
using MediatR;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<ApiResult<OrdersVm>>
    {
        public string Id { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
    }
}
