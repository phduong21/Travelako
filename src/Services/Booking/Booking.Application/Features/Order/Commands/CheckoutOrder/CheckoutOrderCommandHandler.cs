using AutoMapper;
using Booking.Application.Contracts.Persistence;
using Booking.Application.Exceptions;
using Booking.Application.Models;
using Booking.Domain.Entities;
using FT.Travelako.Common.Helpers;
using FT.Travelako.EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, ApiResult<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        //private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            //_emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<OrdersVm>> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            //if (!StringHelper.IsEmail(request.UserEmail))
            //{
            //    return ResponseExtension.ErrorResponse(UserConstants.ErrorMessage.WrongEmailFormat);
            //}
            var orderEntity = _mapper.Map<Order>(request);
            orderEntity.Status = Status.Draft;
            orderEntity.CreatedBy = request.UserId.ToString();
            await _orderRepository.AddAsync(orderEntity);
            var order = await _orderRepository.GetByIdAsync(orderEntity.Id.ToString());
            if (order == null)
            {
                return ApiResult<OrdersVm>.Failure($"Check out order is fail.");
            }
            var newOrder = _mapper.Map<OrdersVm>(order);

            _logger.LogInformation($"Order {order.Id} is successfully created.");

            var orders = await _orderRepository.GetOrdersByUserName(request.UserId.ToString());
            var eventMessage = new CouponEvent()
            {
                UserId = request.UserId.ToString(),
                BusinessId = request.BusinessId,
                Count = orders.Count()
            };

            await _publishEndpoint.Publish<CouponEvent>(eventMessage);

            //await SendMail(newOrder);

            return ApiResult<OrdersVm>.Success(newOrder);
        }

        //private async Task SendMail(Order order)
        //{            
        //    var email = new Email() { To = "ezozkme@gmail.com", Body = $"Order was created.", Subject = "Order was created" };

        //    try
        //    {
        //        await _emailService.SendEmail(email);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
        //    }
        //}
    }
}
