using FT.Travelako.Common.BaseModels;
using FT.Travelako.UI.Extensions;
using FT.Travelako.UI.Infrastructure.API;
using FT.Travelako.UI.Models.Authentication;
using FT.Travelako.UI.Models.Coupon;
using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Models.Travels;
using FT.Travelako.UI.Models.Users;
using FT.Travelako.UI.Services.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using static FT.Travelako.Common.Utility.StaticData;

namespace FT.Travelako.UI.Services
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _client;
        private readonly string _remoteServiceBaseUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string token;

        public CouponService(HttpClient client, IBaseService baseService, IHttpContextAccessor httpContextAccessor)
        {
            _remoteServiceBaseUrl = $"coupon/v1/Coupon";
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            token = _httpContextAccessor.HttpContext.Session.GetString("AccessToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<CouponResponseModel>> GetCouponByUserId(string userId)
        {
            var getCouponByUserIdUri = ApiCoupon.GetCouponsByUserId(_remoteServiceBaseUrl, userId);
            var response = await _client.GetAsync(getCouponByUserIdUri);
            return await response.ReadContentAs<List<CouponResponseModel>>();
        }
    }
}
