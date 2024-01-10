﻿using MediatR;
using System;
using System.Collections.Generic;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrdersVm>>
    {
        public string UserId { get; set; }

        public GetOrdersListQuery(string userId)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }
}