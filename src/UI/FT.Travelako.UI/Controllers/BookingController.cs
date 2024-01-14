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

        public async Task<IActionResult> IndexAsync()
        {
            var orders = await _orderService.GetOrdersById("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            return View();
        }

        public async Task<IActionResult> CheckoutAsync()
        {
            var model = new CheckoutModel()
            {
                TotalCost = 30,
                Status = 2,
                UserId = Guid.NewGuid(),
            };
            await _orderService.CheckoutOrder(model);
            return View();
        }

        public async Task<IActionResult> DeleteAsync()
        {
            await _orderService.DeleteOrder("CD9EAC1E-34C5-4983-740C-08DC1467D1D4");
            return View();
        }
    }
}
