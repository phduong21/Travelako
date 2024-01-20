using Booking.Application.Models;
using Booking.Domain.Entities;
using MediatR;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommand : IRequest<ApiResult<OrdersVm>>
    {
        public Guid UserId { get; set; }
        public string BusinessId { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public string TourName { get; set; }
        public int GuestSize { get; set; }
        public DateTime BookAt { get; set; }
        public decimal TotalCost { get; set; }
        public int Status { get; set; }
        public Guid TravelId { get; set; }
    }
}
