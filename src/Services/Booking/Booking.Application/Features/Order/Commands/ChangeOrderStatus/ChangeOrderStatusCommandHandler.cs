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

namespace Booking.Application.Features.Order.Commands.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand, ApiResult<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ChangeOrderStatusCommandHandler> _logger;

        public ChangeOrderStatusCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<ChangeOrderStatusCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<OrdersVm>> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }
            if (orderToUpdate.Status != Status.Draft && request.Status == (int)Status.Cancel)
            {
                return ApiResult<OrdersVm>.Failure($"Can not cancel order with {orderToUpdate.Status} status");
            }
            orderToUpdate.Status = (Status)request.Status;
            orderToUpdate.LastModifiedBy = request.UserId;

            await _orderRepository.UpdateAsync(orderToUpdate);
            var result = _mapper.Map<OrdersVm>(orderToUpdate);

            _logger.LogInformation($"Order {orderToUpdate.Id} is successfully updated.");
            return ApiResult<OrdersVm>.Success(result);
        }
    }
}
