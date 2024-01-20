using AutoMapper;
using Booking.Application.Contracts.Persistence;
using Booking.Application.Features.Order.Queries.GetOrderDetails;
using Booking.Application.Models;
using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, ApiResult<List<OrdersVm>>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ApiResult<List<OrdersVm>>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByUserName(request.UserId);
            var orders = _mapper.Map<List<OrdersVm>>(orderList);
            return ApiResult<List<OrdersVm>>.Success(orders);
        }
    }
}
