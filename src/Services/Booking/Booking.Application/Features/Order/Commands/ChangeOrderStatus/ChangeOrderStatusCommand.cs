using Booking.Application.Models;
using MediatR;

namespace Booking.Application.Features.Order.Commands.ChangeOrderStatus
{
    public class ChangeOrderStatusCommand : IRequest<ApiResult<OrdersVm>>
    {
        public string Id { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
    }
}
