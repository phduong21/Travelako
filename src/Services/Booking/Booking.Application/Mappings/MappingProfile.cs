using AutoMapper;
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
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Domain.Entities.Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Domain.Entities.Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
