using MediatR;
using System;
using System.Collections.Generic;

namespace Booking.Application.Features.Order.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<OrderDetails>
    {
        public string OrderId { get; set; }

        public GetOrderDetailsQuery(string orderId)
        {
            OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        }

    }
}
