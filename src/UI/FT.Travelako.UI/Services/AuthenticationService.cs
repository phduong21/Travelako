using FT.Travelako.Common.BaseModels;
using FT.Travelako.UI.Infrastructure.API;
using FT.Travelako.UI.Models.Authentication;
using FT.Travelako.UI.Models.Users;
using FT.Travelako.UI.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using static FT.Travelako.Common.Utility.StaticData;

namespace FT.Travelako.UI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly string _remoteServiceBaseUrl;
        private readonly IBaseService _baseService;

        public AuthenticationService(HttpClient client, IBaseService baseService)
        {
            _remoteServiceBaseUrl = $"authen/v1/UserManagerment";
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _baseService = baseService;
        }

        public async Task<AuthenRespone> LoginUser(LoginModel model)
        {
            var requestUri = ApiAuthen.Login(_remoteServiceBaseUrl);
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

            return JsonConvert.DeserializeObject<AuthenRespone>(result.Data.ToString());
        }
    }
}
