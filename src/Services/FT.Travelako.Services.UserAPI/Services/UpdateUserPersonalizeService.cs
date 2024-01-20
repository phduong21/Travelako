﻿using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class UpdateUserPersonalizeService : UserBaseService<PersonalizeRequest>
    {
        private readonly IMapper _mapper;
        private const int MaximumPersonalization = 5;
        public UpdateUserPersonalizeService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _mapper = mapper;
        }

        public override async Task<GenericAPIResponse> ExecuteApi(PersonalizeRequest model)
        {
            var result = new GenericAPIResponse()
            {
                IsSuccess = false
            };
            if (string.IsNullOrEmpty(model.Id) || string.IsNullOrEmpty(model.Location))
            {
                result.Message = "Id and Location cannot be null";
                return result;
            }

            var currentUser = await _userRepository.GetByIdAsync(model.Id);

            if (currentUser == null)
            {
                result.Message = "Cannnot find specified user";
                return result;
            }

            currentUser.Personalization ??= new List<string>();
            if (!currentUser.Personalization.Contains(model.Location))
            {
                currentUser.Personalization.Add(model.Location);

                if (currentUser.Personalization.Count > MaximumPersonalization)
                {
                    currentUser.Personalization.RemoveAt(0);
                }
            }
            else
            {
                currentUser.Personalization.Remove(model.Location);
                currentUser.Personalization.Add(model.Location);
            }

            currentUser.LastModifiedDate = DateTime.Now;
            var updatedUser = await _userRepository.UpdateUserInformationAsync(currentUser);
            UserDTO data = _mapper.Map<UserDTO>(updatedUser);

            return new GenericAPIResponse
            {
                IsSuccess = true,
                Result = data
            };
        }
    }
}
