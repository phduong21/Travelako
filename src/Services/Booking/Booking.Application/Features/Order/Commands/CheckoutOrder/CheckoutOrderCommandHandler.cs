﻿using AutoMapper;
using Booking.Application.Contracts.Persistence;
using Booking.Application.Models;
using Booking.Domain.Entities;
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
        //private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            //_emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<OrdersVm>> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            await _orderRepository.AddAsync(orderEntity);
            var order = await _orderRepository.GetByIdAsync(orderEntity.Id.ToString());
            var newOrder = _mapper.Map<OrdersVm>(order);

            _logger.LogInformation($"Order {order.Id} is successfully created.");
            
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
