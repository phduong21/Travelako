using Booking.Application.Models;
using MediatR;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public string Id { get; set; }
    }
}
