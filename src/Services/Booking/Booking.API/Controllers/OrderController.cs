using AutoMapper;
using Booking.API.Filter;
using Booking.Application.Features.Order.Queries.GetOrderDetails;
using Booking.Application.Models;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System.Net;
using static MassTransit.ValidationResultExtensions;
using CouponEvent = FT.Travelako.EventBus.Messages.Events.CouponEvent;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        [HttpGet("get-orders/{userId}")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business,administrator")]
        [ProducesResponseType(typeof(ApiResult<List<OrdersVm>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<List<OrdersVm>>>> GetOrdersByUserId(string userId)
        {
            var query = new GetOrdersListQuery(userId);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("get-order/{orderId}")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business,administrator")]
        [ProducesResponseType(typeof(ApiResult<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<OrdersVm>>> GetOrderById(string orderId)
        {
            var query = new GetOrderDetailsQuery(orderId);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost("check-out")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business,administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResult<OrdersVm>>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);

            var query = new GetOrdersListQuery(command.UserId.ToString());
            var orders = await _mediator.Send(query);
            var eventMessage = new CouponEvent()
            {
                UserId = command.UserId.ToString(),
                BusinessId = command.BusinessId,
                Count = orders.Result.Count
            };

            await _publishEndpoint.Publish<CouponEvent>(eventMessage);
            return Ok(result);
        }

        [HttpPut("UpdateOrder")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business,administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business,administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(string id)
        {
            var command = new DeleteOrderCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
