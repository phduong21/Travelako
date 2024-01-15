using AutoMapper;
using Booking.Application.EventBus;
using Booking.Application.Features.Order.Queries.GetOrderDetails;
using Booking.Domain.Entities;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;

namespace Booking.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderEvent>().ReverseMap();
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, OrderDetails>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
