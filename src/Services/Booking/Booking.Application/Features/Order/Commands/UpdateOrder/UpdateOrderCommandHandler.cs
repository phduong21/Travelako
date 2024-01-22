using AutoMapper;
using Booking.Application.Contracts.Persistence;
using Booking.Application.Exceptions;
using Booking.Application.Models;
using Booking.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ApiResult<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<UpdateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<OrdersVm>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }
            if(orderToUpdate.Status != Status.Draft && request.Status == (int)Status.Cancel)
            {
                return ApiResult<OrdersVm>.Failure($"Can not cancel order with {orderToUpdate.Status} status");
            }
            orderToUpdate.Status = (Status)request.Status;
            orderToUpdate.LastModifiedBy = request.UserId;
            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));

            await _orderRepository.UpdateAsync(orderToUpdate);
            var result = _mapper.Map<OrdersVm>(orderToUpdate);

            _logger.LogInformation($"Order {orderToUpdate.Id} is successfully updated.");
            return ApiResult<OrdersVm>.Success(result);
        }
    }
}
