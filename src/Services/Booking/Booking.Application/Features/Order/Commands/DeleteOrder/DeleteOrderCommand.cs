using Booking.Application.Models;
using MediatR;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<ApiResult<bool>>
    {
        public string Id { get; set; }
    }
}
