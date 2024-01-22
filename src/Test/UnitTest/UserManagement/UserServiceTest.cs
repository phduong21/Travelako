using AutoMapper;
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
using FT.Travelako.Services.UserAPI.Models;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services;
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

namespace UnitTest.UserManagement
{
    public class UserServiceTest
    {
        private readonly IUserRepository _userRepositoryMock;
        private readonly IMapper _mapper;

        public UserServiceTest()
        {
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task Create_user_success()
        {
            // Arrange
            var fakeUser = new User()
            {
               UserName = "Test",
               Email = "Test@gmail.com",
               FirstName = "Test",
               LastName = "Test",
               Address = "17 Dich Vong, Cau giay"
            };

            var fakeUserDTO = new UserDTO()
            {
                UserName = "Test",
                Email = "Test@gmail.com",
                FirstName = "Test",
                LastName = "Test",
                Address = "17 Dich Vong, Cau giay"
            };

            var fakeUserDefault = new User();
            _userRepositoryMock.AddAsync(Arg.Any<User>()).Returns(fakeUser);
            _mapper.Map<User>(Arg.Any<User>()).Returns(fakeUserDefault);
            _mapper.Map<UserDTO>(Arg.Any<User>).Returns(fakeUserDTO);
            // Act
            var userService = new CreateUserService(_userRepositoryMock, _mapper);
            var actionResult = await userService.ExecuteApi(Arg.Any<CreateUserRequest>());

            // Assert
            Assert.Same(fakeUserDTO, actionResult.Result);
        }

        [Fact]
        public async Task Get_user_By_Id_success()
        {
            // Arrange
            var fakeUser = new User()
            {
                UserName = "Test",
                Email = "Test@gmail.com",
                FirstName = "Test",
                LastName = "Test",
                Address = "17 Dich Vong, Cau giay"
            };

            var fakeUserDTO = new UserDTO()
            {
                UserName = "Test",
                Email = "Test@gmail.com",
                FirstName = "Test",
                LastName = "Test",
                Address = "17 Dich Vong, Cau giay"
            };

            var fakeUserDefault = new User();
            _userRepositoryMock.GetByIdAsync(Arg.Any<string>()).Returns(fakeUser);
            _mapper.Map<UserDTO>(fakeUser).Returns(fakeUserDTO);
            // Act
            var userService = new GetUserService(_userRepositoryMock, _mapper);
            var actionResult = await userService.ExecuteApi(Arg.Any<GetUserRequest>());

            // Assert
            Assert.Same(fakeUserDTO, actionResult.Result);
        }

        [Fact]
        public async Task Get_all_user_success()
        {
            // Arrange
            var fakeUser = new User()
            {
                UserName = "Test",
                Email = "Test@gmail.com",
                FirstName = "Test",
                LastName = "Test",
                Address = "17 Dich Vong, Cau giay"
            };

            var fakeListUser = new List<User>()
            {
                fakeUser
            };

            var fakeUserDTO = new UserDTO()
            {
                UserName = "Test",
                Email = "Test@gmail.com",
                FirstName = "Test",
                LastName = "Test",
                Address = "17 Dich Vong, Cau giay"
            };

            var fakeListUserDTO = new List<UserDTO>()
            {
                fakeUserDTO
            };

            var fakeUserDefault = new User();
            _userRepositoryMock.GetAllAsync().Returns(fakeListUser);
            _mapper.Map<List<UserDTO>>(fakeListUser).Returns(fakeListUserDTO);

            // Act
            var userService = new GetAllUserService(_userRepositoryMock, _mapper);
            var actionResult = await userService.ExecuteApi(Arg.Any<GetAllUserRequest>());

            // Assert
            Assert.Same(fakeListUserDTO, actionResult.Result);
        }

        [Fact]
        public async Task Update_user_success()
        {
            // Arrange
            var fakeUser = new User()
            {
                UserName = "Test",
                Email = "Test@gmail.com",
                FirstName = "Test",
                LastName = "Test",
                Address = "17 Dich Vong, Cau giay"
            };

            var fakeUserDefault = new User();
            _userRepositoryMock.GetByIdAsync(Arg.Any<string>()).Returns(fakeUserDefault);
            _mapper.Map<User>(Arg.Any<UpdateUserRequest>()).Returns(fakeUser);
            _userRepositoryMock.UpdateUserInformationAsync(Arg.Any<User>()).Returns(fakeUser);

            // Act
            var userService = new UpdateUserService(_userRepositoryMock, _mapper);
            var actionResult = await userService.ExecuteApi(Arg.Any<UpdateUserRequest>());

            // Assert
            Assert.Same(fakeUser, actionResult.Result);
        }

        [Fact]
        public async Task Get_business_user_success()
        {
            // Arrange
            var fakeUser = new User()
            {
                UserName = "Test",
                Email = "Test@gmail.com",
                FirstName = "Test",
                LastName = "Test",
                Address = "17 Dich Vong, Cau giay"
            };

            var fakeListUser = new List<User>()
            {
                fakeUser
            };

            var fakeUserDTO = new UserDTO()
            {
                UserName = "Test",
                Email = "Test@gmail.com",
                FirstName = "Test",
                LastName = "Test",
                Address = "17 Dich Vong, Cau giay"
            };

            var fakeListUserDTO = new List<UserDTO>()
            {
                fakeUserDTO
            };

            var fakeUserDefault = new User();
            _userRepositoryMock.GetAllAsync().Returns(fakeListUser);
            _mapper.Map<List<UserDTO>>(fakeListUser).Returns(fakeListUserDTO);

            // Act
            var userService = new GetBusinessUserService(_userRepositoryMock, _mapper);
            var actionResult = await userService.ExecuteApi(Arg.Any<DefaultRequest>());

            // Assert
            Assert.Same(fakeListUserDTO, actionResult.Result);
        }

    }
}
