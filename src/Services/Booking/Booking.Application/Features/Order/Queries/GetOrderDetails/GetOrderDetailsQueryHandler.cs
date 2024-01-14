using AutoMapper;
using Booking.Application.Contracts.Persistence;
using MediatR;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;

namespace Booking.Application.Features.Order.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetails>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OrderDetails> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderRepository.GetByIdAsync(request.OrderId);
            return _mapper.Map<OrderDetails>(orderDetails);
        }
    }
}
