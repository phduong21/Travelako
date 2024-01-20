using AutoMapper;
using Booking.Application.Contracts.Persistence;
using Booking.Application.Models;
using MediatR;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;

namespace Booking.Application.Features.Order.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, ApiResult<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ApiResult<OrdersVm>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderRepository.GetByIdAsync(request.OrderId);
            var order = _mapper.Map<OrdersVm>(orderDetails);
            return ApiResult<OrdersVm>.Success(order);
        }
    }
}
