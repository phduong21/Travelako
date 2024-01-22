using Booking.API.Controllers;
using Booking.Application.Models;
using Coupon.Application.Features.Coupon.Commands.CreateCoupon;
using Coupon.Application.Features.Coupon.Queries.GetListCoupons;
using FT.Travelako.Common.Mappings;
using FT.Travelako.Services.CouponAPI.Controllers;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using NSubstitute;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Coupon
{
    public class CouponCommandHandleTest
    {
        private readonly IMediator _mediatorMock;
        private readonly IDistributedCache _distributeCacheMock;
        private readonly IServiceProvider _serviceProviderMock;

        public CouponCommandHandleTest()
        {
            _mediatorMock = Substitute.For<IMediator>();
            _distributeCacheMock = Substitute.For<IDistributedCache>();
            _serviceProviderMock = Substitute.For<IServiceProvider>();
        }

        [Fact]
        public async Task Create_coupon_success()
        {
            // Arrange
            var createCouponCommand = new CreateCouponCommand()
            {
                Title = "Test",
                Code = "Test",
                Condition = 10,
                Discount = 10,
                CreatedBy = "Test",
                TimeExpried = 10
            };
            var fakeResult = "45b53912-843c-4e2f-fa41-08dc16d59933";
            _mediatorMock.Send(createCouponCommand).Returns(ApiResult<string>.Success(fakeResult));

            // Act
            var couponController = new CouponController(_serviceProviderMock, _distributeCacheMock, _mediatorMock);
            var actionResult = await couponController.CreateCoupon(createCouponCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result).Value as ApiResult<string>;
            Assert.Same(fakeResult, okResult.Result);
        }

        [Fact]
        public async Task Get_coupon_userId_success()
        {
            // Arrange
            var userId = "45b53912-843c-4e2f-fa41-08dc16d59933";
            var fakeResult = new List<CouponViewModel>();
            fakeResult.Add(new CouponViewModel
            {
                Title = "Test",
                Code = "Test",
                Condition = 10,
                Discount = 10,
                TimeExpried = 10
            });
            _mediatorMock.Send(userId).Returns(fakeResult);

            // Act
            var couponController = new CouponController(_serviceProviderMock, _distributeCacheMock, _mediatorMock);
            var actionResult = await couponController.GetCouponsByUserId(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result).Value as IEnumerable<CouponViewModel>;
            Assert.Same(fakeResult, okResult);
        }

    }
}
