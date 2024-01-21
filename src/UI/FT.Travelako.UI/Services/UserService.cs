using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Models;
using FT.Travelako.UI.Infrastructure.API;
using FT.Travelako.UI.Models.Authentication;
using FT.Travelako.UI.Models.Users;
using FT.Travelako.UI.Models.Users.ViewModel;
using FT.Travelako.UI.Services.Base;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using static FT.Travelako.Common.Utility.StaticData;

namespace FT.Travelako.UI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        private readonly string _remoteServiceBaseUrl;
        private readonly string _remoteServicePersonalizeBaseUrl;
        private readonly IBaseService _baseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string token;

        public UserService(HttpClient client, IBaseService baseService, IHttpContextAccessor httpContextAccessor)
        {
            _remoteServiceBaseUrl = $"user/v1/User";
            _remoteServicePersonalizeBaseUrl = $"user/v1/Personalization";
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _baseService = baseService;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            token = _httpContextAccessor.HttpContext.Session.GetString("AccessToken");
        }

        public async Task<UserDetailResponseModel> CreateUser(SignUpVM model)
        {
            var requestUri = ApiUser.CreateUser(_remoteServiceBaseUrl);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.POST,
                Url = _client.BaseAddress + requestUri,
                Data = new CreateUserModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Username,
                    Email = model.Email,
                    Address = model.Address,
                    Password = model.Password,
                    Image = string.IsNullOrEmpty(model.ImageUrl) ? "/img/default-profile-img.jpg" : model.ImageUrl,
                    //Role = model.IsTravelSeller ? UserRoles.Business : UserRoles.User
                    IsTravelSeller = model.IsTravelSeller
                }
            });

            if (result is null || result.IsSuccess == false)
            {
                if (!string.IsNullOrEmpty(result?.Message))
                {
                    return new UserDetailResponseModel
                    {
                        ResponseMessage = result.Message
                    };
                }
                return null;
            }

            return JsonConvert.DeserializeObject<UserDetailResponseModel>(result.Result.ToString());
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var requestUri = ApiUser.DeleteUser(_remoteServiceBaseUrl, userId);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.DELETE,
                Url = _client.BaseAddress + requestUri
            });

            if (result != null && result.IsSuccess)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<UserDetailResponseModel>> GetAllUsers()
        {
            var requestUri = ApiUser.GetAllUser(_remoteServiceBaseUrl);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.GET,
                Url = _client.BaseAddress + requestUri
            });

            if (result is null || result.Result == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<UserDetailResponseModel>>(result.Result.ToString());
        }

        public async Task<UserDetailResponseModel> GetUserInformationById(string userId)
        {
            var requestUri = ApiUser.GetUserInfoById(_remoteServiceBaseUrl, userId);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.GET,
                Url = _client.BaseAddress + requestUri,
            });

            if (result == null || result.Result == null)
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

            if (result is null || result.IsSuccess == false)
            {
                if (!string.IsNullOrEmpty(result?.Message))
                {
                    return new UserDetailResponseModel
                    {
                        ResponseMessage = result.Message
                    };
                }
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

            if (result is null || result.IsSuccess == false)
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

        public UserModel GetCurrentUser()
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var jwt = new JwtSecurityToken(token);
                if (jwt != null)
                {
                    var result = new UserModel();
                    result.UserName = jwt.Claims.First(c => c.Type == "name").Value;
                    result.Id = jwt.Claims.First(c => c.Type == "id").Value;
                    return result;
                }
            }
            return null;
        }

        public async Task<IEnumerable<UserDetailResponseModel>> GetAllBusinessUsers()
        {
            var requestUri = ApiUser.GetAllBusnessUser(_remoteServiceBaseUrl);
            var result = await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.GET,
                Url = _client.BaseAddress + requestUri
            });

            if (result is null || result.Result is null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<UserDetailResponseModel>>(result.Result.ToString());
        }
    }
}
