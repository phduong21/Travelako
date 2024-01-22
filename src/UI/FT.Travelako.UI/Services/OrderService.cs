using FT.Travelako.UI.Extensions;
using FT.Travelako.UI.Infrastructure.API;
using FT.Travelako.UI.Models;
using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Models.Orders.ViewModel;
using NuGet.Common;
using NuGet.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FT.Travelako.UI.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        private readonly string _remoteServiceBaseUrl;
        private readonly HttpContext _context;
        private readonly string token;


        public OrderService(HttpClient client, IHttpContextAccessor context)
        {
            _remoteServiceBaseUrl = $"/booking/v1/Order";
            _client = client ?? throw new ArgumentNullException(nameof(client));
            //token = _httpContextAccessor.HttpContext.Session.GetString("AccessToken");
            token = context.HttpContext.Session.GetString("AccessToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserId(string userId)
        {
            var getOrderByUserIdUri = ApiOrder.GetOrdersByUserId(_remoteServiceBaseUrl, userId);
            var response = await _client.GetAsync(getOrderByUserIdUri);
            var result = await response.ReadContentAs<BaseApiResponseModel<List<OrderResponseModel>>>();
            return result.Result;
        }

        public async Task<OrderResponseModel> GetOrderDetails(string orderId)
        {
            var getOrderByUserIdUri = ApiOrder.GetOrderDetails(_remoteServiceBaseUrl, orderId);
            var response = await _client.GetAsync(getOrderByUserIdUri);
            var result = await response.ReadContentAs<BaseApiResponseModel<OrderResponseModel>>();
            return result.Result;
        }

        public async Task<OrderResponseModel> CheckoutOrder(CheckoutModel checkoutModel)
        {
            var checkoutOrderUri = ApiOrder.CheckOutOrder(_remoteServiceBaseUrl);
            var response = await _client.PostAsJsonAsync(checkoutOrderUri, checkoutModel);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
            var result = await response.ReadContentAs<BaseApiResponseModel<OrderResponseModel>>();
            return result.Result;
        }

        public async Task<OrderResponseModel> UpdateOrderStatus(OrderStatus orderStatus)
        {
            var updateOrderStatus = ApiOrder.UpdateOrderStatus(_remoteServiceBaseUrl);
            var response = await _client.PutAsJsonAsync(updateOrderStatus, orderStatus);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
            var result = await response.ReadContentAs<BaseApiResponseModel<OrderResponseModel>>();
            return result.Result;
        }

        public async Task DeleteOrder(string userId)
        {
            var deleteOrderUri = ApiOrder.DeleteOrder(_remoteServiceBaseUrl, userId);
            var response = await _client.DeleteAsync(deleteOrderUri);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
