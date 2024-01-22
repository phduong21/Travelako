using Booking.API.Controllers;
using Booking.Application.Models;
using Coupon.Application.Features.Coupon.Commands.CreateCoupon;
using Coupon.Application.Features.Coupon.Queries.GetListCoupons;
using Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon;
using Coupon.Application.Features.CouponsUser.Queries.GetListCouponByUserId;
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

namespace UnitTest.CouponUser
{
    public class CouponUserCommandHandleTest
    {
        private readonly IMediator _mediatorMock;
        private readonly IDistributedCache _distributeCacheMock;
        private readonly IServiceProvider _serviceProviderMock;

        public CouponUserCommandHandleTest()
        {
            _mediatorMock = Substitute.For<IMediator>();
            _distributeCacheMock = Substitute.For<IDistributedCache>();
            _serviceProviderMock = Substitute.For<IServiceProvider>();
        }

        [Fact]
        public async Task Create_user_coupon_success()
        {
            // Arrange
            var createUserCouponCommand = new CreateUserCouponCommand()
            {
                BusinessId = "D4421C80-8102-4C5D-F0B0-08DC1355935F",
                UserId = "7E00590A-612A-4CA8-1289-08DC17F35A49"
            };
            string fakeResult = "45b53912-843c-4e2f-fa41-08dc16d59933";
            _mediatorMock.Send(createUserCouponCommand).Returns(ApiResult<string>.Success(fakeResult));

            // Act
            var userCouponController = new UserCouponController(_serviceProviderMock, _distributeCacheMock, _mediatorMock);
            var actionResult = await userCouponController.CreateUserCoupon(createUserCouponCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result).Value as ApiResult<string>;
            Assert.Same(fakeResult, okResult.Result);
        }

        [Fact]
        public async Task Get_user_coupon_userId_success()
        {
            // Arrange
            var userId = "45b53912-843c-4e2f-fa41-08dc16d59933";
            var businessId = "D4421C80-8102-4C5D-F0B0-08DC1355935F";
            var fakeResult = new List<CouponUserModel>();
            fakeResult.Add(new CouponUserModel
            {
                Title = "Test",
                Code = "Test",
                Discount = 10,
                TimeExpried = 10,
                CouponId = "7E00590A-612A-4CA8-1289-08DC17F35A49",
                UserId= "45b53912-843c-4e2f-fa41-08dc16d59933"
            });
            _mediatorMock.Send(userId).Returns(fakeResult);

            // Act
            var userCouponController = new UserCouponController(_serviceProviderMock, _distributeCacheMock, _mediatorMock);
            var actionResult = await userCouponController.GetUsersCouponsByUserId(userId, businessId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result).Value as IEnumerable<CouponUserModel>;
            Assert.Same(fakeResult, okResult);
        }

    }
}
