using Booking.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Booking.Application.Features.Order.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<ApiResult<OrdersVm>>
    {
        public string OrderId { get; set; }

        public GetOrderDetailsQuery(string orderId)
        {
            OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        }

    }
}
