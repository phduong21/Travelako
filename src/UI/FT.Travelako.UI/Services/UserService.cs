using FT.Travelako.Common.BaseModels;
using FT.Travelako.UI.Extensions;
using FT.Travelako.UI.Infrastructure.API;
using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Models.Travels;
using FT.Travelako.UI.Models.Users;
using FT.Travelako.UI.Services.Base;
using Newtonsoft.Json;
using static FT.Travelako.Common.Utility.StaticData;

namespace FT.Travelako.UI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        private readonly string _remoteServiceBaseUrl;
        private readonly string _remoteServicePersonalizeBaseUrl;
        private readonly IBaseService _baseService;

        public UserService(HttpClient client, IBaseService baseService)
        {
            _remoteServiceBaseUrl = $"user/v1/User";
            _remoteServicePersonalizeBaseUrl = $"user/v1/Personalization";
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _baseService = baseService;
        }

        public async Task<UserDetailResponseModel> CreateUser(CreateUserModel model)
        {
            var requestUri = ApiUser.CreateUser(_remoteServiceBaseUrl);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.POST,
                Url = _client.BaseAddress + requestUri,
                Data = model
            });

            if (result is null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserDetailResponseModel>(result.Result.ToString());
        }

        public async Task DeleteUser(string userId)
        {
            var requestUri = ApiUser.DeleteUser(_remoteServiceBaseUrl, userId);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.DELETE,
                Url = _client.BaseAddress + requestUri
            });

            if (result.IsSuccess)
            {
                
            }
        }

        public async Task<IEnumerable<UserDetailResponseModel>> GetAllUsers()
        {
            var requestUri = ApiUser.GetAllUser(_remoteServiceBaseUrl);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.GET,
                Url = _client.BaseAddress + requestUri
            });

            if (result is null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<UserDetailResponseModel>>(result.Result.ToString());
        }

        public async Task<UserDetailResponseModel> GetUserInformation(string userName)
        {
            var requestUri = ApiUser.GetUserInfo(_remoteServiceBaseUrl, userName);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.GET,
                Url = _client.BaseAddress + requestUri
            });

            if(result is null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserDetailResponseModel>(result.Result.ToString());  
        }

        public async Task<UserDetailResponseModel> GetUserInformationById(string userId)
        {
            var requestUri = ApiUser.GetUserInfoById(_remoteServiceBaseUrl, userId);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.GET,
                Url = _client.BaseAddress + requestUri
            });

            if (result is null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserDetailResponseModel>(result.Result.ToString());
        }

        public async Task<UserDetailResponseModel> UpdateUser(UpdateUserModel model)
        {
            var requestUri = ApiUser.UpdateUser(_remoteServiceBaseUrl);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.PUT,
                Url = _client.BaseAddress + requestUri,
                Data = model
            });

            if (result is null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserDetailResponseModel>(result.Result.ToString());
        }

        public async Task<PersonalizeModel> GetPersonalizeUser(string userId)
        {
            var requestUri = ApiUser.GetPersonalizeUser(_remoteServicePersonalizeBaseUrl, userId);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.GET,
                Url = _client.BaseAddress + requestUri,
            });

            if (result is null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<PersonalizeModel>(result.Result.ToString());
        }

        public async Task UpdatePersonalizeUser(PersonalizeModel model)
        {
            var requestUri = ApiUser.UpdatePersonalizeUser(_remoteServicePersonalizeBaseUrl);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.PUT,
                Url = _client.BaseAddress + requestUri,
                Data = model
            });
        }

    }
}
