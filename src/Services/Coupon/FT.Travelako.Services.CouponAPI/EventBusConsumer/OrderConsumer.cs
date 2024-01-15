﻿using AutoMapper;
using FT.Travelako.EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FT.Travelako.Services.CouponAPI.EventBusConsumer
{
    public class OrderConsumer : IConsumer<OrderEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderConsumer> _logger;

        public OrderConsumer(IMediator mediator, IMapper mapper, ILogger<OrderConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<OrderEvent> context)
        {
            var result = JsonConvert.SerializeObject(context.Message);
            //var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            //var result = await _mediator.Send(command);

            _logger.LogInformation("OrderDetalis Event consumed successfully. Order Id : {newOrderId}", result);
        }
    }
}
