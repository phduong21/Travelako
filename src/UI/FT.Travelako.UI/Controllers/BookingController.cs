using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IOrderService _orderService;

        public BookingController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));

        }

        public async Task<IActionResult> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _orderService.GetOrdersByUserId(userId);
            return View();
        }

        public async Task<IActionResult> GetOrderDetailsAsync(string orderId)
        {
            var orders = await _orderService.GetOrderDetails(orderId);
            return View();
        }

        public async Task<IActionResult> CheckoutAsync([FromBody] CheckoutModel model)
        {
            await _orderService.CheckoutOrder(model);
            return View();
        }

        public async Task<IActionResult> DeleteAsync(string orderId)
        {
            await _orderService.DeleteOrder(orderId);
            return View();
        }
    }
}
