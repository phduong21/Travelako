using FT.Travelako.UI.Extensions;
using FT.Travelako.UI.Models.Orders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FT.Travelako.UI.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersById(string userId)
        {
            var response = await _client.GetAsync($"/booking/v1/Order/get-orders/{userId}");
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }

        public async Task CheckoutOrder(CheckoutModel checkoutModel)
        {
            var response = await _client.PostAsJsonAsync($"/booking/v1/Order/check-out", checkoutModel);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task DeleteOrder(string userId)
        {
            var response = await _client.DeleteAsync($"/booking/v1/Order/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
