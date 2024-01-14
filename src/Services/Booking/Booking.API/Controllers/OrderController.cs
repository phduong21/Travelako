using Booking.Application.Features.Order.Queries.GetOrderDetails;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System.Net;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("get-orders/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrdersByUserId(string userId)
        {
            var query = new GetOrdersListQuery(userId);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("get-order/{orderId}")]
        [ProducesResponseType(typeof(OrderDetails), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderDetails>> GetOrderById(string orderId)
        {
            var query = new GetOrderDetailsQuery(orderId);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost("check-out")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
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
