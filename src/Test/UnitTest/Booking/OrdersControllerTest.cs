using AutoMapper;
using Booking.API.Controllers;
using Booking.Application.Contracts.Persistence;
using Booking.Application.Features.Order.Queries.GetOrderDetails;
using Booking.Application.Models;
using Booking.Domain.Entities;
using Booking.Infrastructure.Repositories;
using Castle.Core.Logging;
using FT.Travelako.Common.Mappings;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.ValidationResultExtensions;

namespace UnitTest.Booking
{
    public class OrdersCommandHandleTest
    {
        private readonly IMediator _mediatorMock;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IOrderRepository _orderRepositorMock;
        private readonly IMapper _mapperMock;
        private readonly ILogger<CheckoutOrderCommandHandler> _loggerMock;

        public OrdersCommandHandleTest()
        {
            _mediatorMock = Substitute.For<IMediator>();
            _publishEndpoint = Substitute.For<IPublishEndpoint>();
            _orderRepositorMock = Substitute.For<IOrderRepository>();
            _mapperMock = Substitute.For<IMapper>();
            _loggerMock = Substitute.For<ILogger<CheckoutOrderCommandHandler>>();
        }

        [Fact]
        public async Task Checkout_order_success()
        {
            // Arrange
            var fakeCheckoutCommand = new CheckoutOrderCommand()
            {
                FullName = "linh tran",
                GuestSize = 4,
                Phone = "0123456",
                TotalCost = 5000,
                Status = 0,
                UserEmail = "linhtran@gmail.com",
                TravelId = Guid.Parse("D4421C80-8102-4C5D-F0B0-08DC1355935F"),
                UserId = Guid.Parse("7E00590A-612A-4CA8-1289-08DC17F35A49"),
                TourName = "Ha Noi",
                BusinessId = "45b53912-843c-4e2f-fa41-08dc16d59933",
                BookAt = DateTime.Now,
            };
            var fakeOrderMapping = FakeOrderItem(fakeCheckoutCommand);
            var fakeResult = FakeOrderResult(fakeOrderMapping);
            _mediatorMock.Send(fakeCheckoutCommand).Returns(ApiResult<OrdersVm>.Success(fakeResult));
            
            // Act
            var orderController = new OrderController(_mediatorMock);
            var actionResult = await orderController.CheckoutOrder(fakeCheckoutCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result).Value as ApiResult<OrdersVm>;
            Assert.Same(fakeResult, okResult.Result);
        }

        [Fact]
        public async Task Get_order_details_success()
        {
            // Arrange
            string fakeOrderId = "45b53912-843c-4e2f-fa41-08dc16d59933";
            var fakeOrderDetailsQuery = new GetOrderDetailsQuery(fakeOrderId);
            var fakeOrder = new Order()
            {
                FullName = "linh tran",
                GuestSize = 4,
                Phone = "0123456",
                TotalCost = 5000,
                Status = 0,
                UserEmail = "linhtran@gmail.com",
                TravelId = Guid.Parse("D4421C80-8102-4C5D-F0B0-08DC1355935F"),
                UserId = Guid.Parse("7E00590A-612A-4CA8-1289-08DC17F35A49"),
                TourName = "Ha Noi",
                BookAt = DateTime.Now,
            };
            var fakeResult = FakeOrderResult(fakeOrder);
            _mediatorMock.Send(fakeOrderDetailsQuery).Returns(ApiResult<OrdersVm>.Success(fakeResult));

            // Act
            var orderController = new OrderController(_mediatorMock);
            var actionResult = await orderController.GetOrderById(fakeOrderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result).Value as ApiResult<OrdersVm>;
            Assert.Same(fakeResult, okResult.Result);
        }

        [Fact]
        public async Task Get_orders_by_userId_success()
        {
            // Arrange
            string fakeUserId = "7E00590A-612A-4CA8-1289-08DC17F35A49";
            var fakeOrderListQuery = new GetOrdersListQuery(fakeUserId);
            var fakeOrder = new Order()
            {
                FullName = "linh tran",
                GuestSize = 4,
                Phone = "0123456",
                TotalCost = 5000,
                Status = 0,
                UserEmail = "linhtran@gmail.com",
                TravelId = Guid.Parse("D4421C80-8102-4C5D-F0B0-08DC1355935F"),
                UserId = Guid.Parse("7E00590A-612A-4CA8-1289-08DC17F35A49"),
                TourName = "Ha Noi",
                BookAt = DateTime.Now,
            };
            var fakeResult = new List<OrdersVm>()
            {
                FakeOrderResult(fakeOrder)
            };
            _mediatorMock.Send(fakeOrderListQuery).Returns(ApiResult<List<OrdersVm>>.Success(fakeResult));

            // Act
            var orderController = new OrderController(_mediatorMock);
            var actionResult = await orderController.GetOrdersByUserId(fakeUserId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result).Value as ApiResult<List<OrdersVm>>;
            Assert.Same(fakeResult, okResult.Result);
        }

        private Order FakeOrderItem(CheckoutOrderCommand orderCommand)
        {
            return new Order
            {
                FullName = orderCommand.FullName,
                GuestSize = orderCommand.GuestSize,
                Phone = orderCommand.Phone,
                TotalCost = orderCommand.TotalCost,
                Status = orderCommand.Status,
                UserEmail = orderCommand.UserEmail,
                TravelId = orderCommand.TravelId,
                UserId = orderCommand.UserId,
                TourName  = orderCommand.TourName,
                BookAt = orderCommand.BookAt,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            };
        }

        private OrdersVm FakeOrderResult(Order order)
        {
            return new OrdersVm
            {
                FullName = order.FullName,
                GuestSize = order.GuestSize,
                Phone = order.Phone,
                TotalCost = order.TotalCost,
                Status = order.Status,
                UserEmail = order.UserEmail,
                TravelId = order.TravelId,
                UserId = order.UserId,
                TourName = order.TourName,
                CreatedDate = DateTime.Now,
            };
        }
    }
}
