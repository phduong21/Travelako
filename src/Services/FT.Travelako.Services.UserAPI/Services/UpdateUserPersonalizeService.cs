using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Constants;
using FT.Travelako.Services.UserAPI.Extensions;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class UpdateUserPersonalizeService : UserBaseService<PersonalizeRequest>
    {
        private readonly IMapper _mapper;
        public UpdateUserPersonalizeService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _mapper = mapper;
        }

        public override async Task<GenericAPIResponse> ExecuteApi(PersonalizeRequest model)
        {
            try
            {
                var result = new GenericAPIResponse();
                if (string.IsNullOrEmpty(model.Id) || string.IsNullOrEmpty(model.Location))
                {
                    return ResponseExtension.ErrorResponse(string.Format(UserConstants.ErrorMessage.NullError, $"{nameof(model.Id)} and {nameof(model.Location)}"));
                }

                var currentUser = await _userRepository.GetByIdAsync(model.Id);

                if (currentUser == null)
                {
                    return ResponseExtension.ErrorResponse(UserConstants.ErrorMessage.UserNotFound);
                }

                currentUser.Personalization ??= new List<string>();
                if (!currentUser.Personalization.Contains(model.Location))
                {
                    currentUser.Personalization.Add(model.Location);

                    if (currentUser.Personalization.Count > UserConstants.MaximumPersonalization)
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

                return ResponseExtension.SuccessResponse(_mapper.Map<UserDTO>(updatedUser));
            }
            catch (Exception ex)
            {
                return ResponseExtension.ErrorResponse(ex.Message);
            }
        }
    }
}
