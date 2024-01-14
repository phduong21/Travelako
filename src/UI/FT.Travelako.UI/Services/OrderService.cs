using FT.Travelako.UI.Extensions;
using FT.Travelako.UI.Infrastructure.API;
using FT.Travelako.UI.Models.Orders;
using NuGet.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FT.Travelako.UI.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        private readonly string _remoteServiceBaseUrl;

        public OrderService(HttpClient client)
        {
            _remoteServiceBaseUrl = $"/booking/v1/Order";
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersById(string userId)
        {
            var getOrderByUserIdUri = ApiOrder.GetOrderByUserId(_remoteServiceBaseUrl, userId);
            var response = await _client.GetAsync(getOrderByUserIdUri);
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }

        public async Task CheckoutOrder(CheckoutModel checkoutModel)
        {
            var checkoutOrderUri = ApiOrder.CheckOutOrder(_remoteServiceBaseUrl);
            var response = await _client.PostAsJsonAsync(checkoutOrderUri, checkoutModel);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
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
