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
        private readonly HttpContext _context;
        private readonly string token;

        public CouponService(HttpClient client, IBaseService baseService, IHttpContextAccessor context)
        {
            _remoteServiceBaseUrl = $"coupon/v1/UserCoupon";
            _client = client ?? throw new ArgumentNullException(nameof(client));
            //_context = context ?? throw new ArgumentNullException(nameof(context));
            token = context.HttpContext.Session.GetString("AccessToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<CouponResponseModel>> GetCouponByUserId(string userId, string businessUserId)
        {
            var getCouponByUserIdUri = ApiCoupon.GetUsersCouponsByUserId(_remoteServiceBaseUrl, userId, businessUserId);
            var response = await _client.GetAsync(getCouponByUserIdUri);
            return await response.ReadContentAs<List<CouponResponseModel>>();
        }
    }
}
