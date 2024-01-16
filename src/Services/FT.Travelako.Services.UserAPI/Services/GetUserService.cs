using AutoMapper;
using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Entities;
using FT.Travelako.EventBus.Messages.Events;
using FT.Travelako.Services.UserAPI.Data;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;
using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class GetUserService : UserBaseService<GetUserRequest>
    {
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public GetUserService(IUserRepository userRepository, IMapper mapper, IPublishEndpoint publishEndpoint) : base(userRepository)
        {
            _mapper = mapper;
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }


        public override async Task<GenericAPIResponse> ExecuteApi(GetUserRequest model)
        {
            var result = new GenericAPIResponse()
            {
                IsSuccess = false
            };
            if(model.Id is null)
            {
                result.Message = "Id cannot be null";
                return result;
            }

            var user = await _userRepository.GetByIdAsync(model.Id);
            var eventMessage = new TravelEvent()
            {
            };
            await _publishEndpoint.Publish<OrderEvent>(eventMessage);

            if (user == null)
            {

            }
            UserDTO data = _mapper.Map<UserDTO>(user);

            return  new GenericAPIResponse
            {
                IsSuccess = true,
                Result = data
            };
        }
         
    }
}
