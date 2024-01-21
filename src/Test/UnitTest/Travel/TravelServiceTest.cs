using Booking.API.Controllers;
using Booking.Application.Models;
using Coupon.Application.Features.Coupon.Commands.CreateCoupon;
using Coupon.Application.Features.Coupon.Queries.GetListCoupons;
using Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon;
using Coupon.Application.Features.CouponsUser.Queries.GetListCouponByUserId;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Mappings;
using FT.Travelako.Services.CouponAPI.Controllers;
using FT.Travelako.Services.TravelAPI.Models;
using FT.Travelako.Services.TravelAPI.Models.DTOs;
using FT.Travelako.Services.TravelAPI.Repositories;
using FT.Travelako.Services.TravelAPI.Services;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using NSubstitute;
using NSubstitute.Core.Arguments;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.CouponUser
{
    public class TravelServiceTest
    {
        private readonly ITravelRepository _travelRepositoryMock;

        public TravelServiceTest()
        {
            _travelRepositoryMock = Substitute.For<ITravelRepository>();
        }

        [Fact]
        public async Task Create_travel_success()
        {
            // Arrange
            var fakeTravel = new Travel()
            {
                Content = "this is a nice city",
                Description = "Description",
                HotelTitle = "Title",
                HotelPrice = "10000",
                Location = "vietnam",
                Images = "images-hanoi",
                Province = "hanoi",
                Title = "Nha Trang",
                TrafficType = 0
            };

            var fakeResult = new GenericAPIResponse()
            {
                Result = fakeTravel
            };

            _travelRepositoryMock.AddAsync(Arg.Any<Travel>()).Returns(fakeTravel);

            // Act
            var travelService = new CreateTravelService(_travelRepositoryMock);
            var actionResult = await travelService.ExecuteApi(Arg.Any<CreateTravelRequestDTO>());

            // Assert
            Assert.Same(fakeTravel, actionResult.Result);
        }

        [Fact]
        public async Task Get_travel_success()
        {
            // Arrange
            var travel = new Travel()
            {
                Content = "this is a nice city",
                Description = "Description",
                HotelTitle = "Title",
                HotelPrice = "10000",
                Location = "vietnam",
                Images = "images-hanoi",
                Province = "hanoi",
                Title = "Nha Trang",
                TrafficType = 0
            };

            var fakeListTravel = new List<Travel>()
            {
                travel
            };

            var fakeResult = new GenericAPIResponse()
            {
                Result = fakeListTravel
            };

            _travelRepositoryMock.GetAllAsync().Returns(fakeListTravel);
            // Act
            var travelService = new GetTravelService(_travelRepositoryMock);
            var actionResult = await travelService.ExecuteApi(Arg.Any<GetTravelRequestDTO>());

            // Assert
            Assert.Same(fakeListTravel, actionResult.Result);
        }

    }
}
