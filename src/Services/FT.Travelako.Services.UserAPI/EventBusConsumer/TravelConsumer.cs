using AutoMapper;
using FT.Travelako.Common.Entities;
using FT.Travelako.EventBus.Messages.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FT.Travelako.Services.UserAPI.EventBusConsumer
{
    public class TravelConsumer : IConsumer<TravelEvent>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TravelConsumer> _logger;

        public TravelConsumer(IMapper mapper, ILogger<TravelConsumer> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<TravelEvent> context)
        {
            var result = JsonConvert.SerializeObject(context.Message);
            //var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            //var result = await _mediator.Send(command);

            _logger.LogInformation("OrderDetalis Event consumed successfully. Order Id : {newOrderId}", result);
        }
    }
}
