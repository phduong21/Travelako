using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Models.Orders.ViewModel;
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

        public async Task<IActionResult> OrdersHistory(string userId)
        {
            var orders = await _orderService.GetOrdersByUserId(userId);
            return View(orders);
        }

        public async Task<IActionResult> Detail(string orderId)
        {
            var orders = await _orderService.GetOrderDetails(orderId);
            return View(orders);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CheckoutAsync", model);
            }
            //var accesskey = HttpContext.Session.GetString("AccessToken");
            var order = new CheckoutModel()
            {
                FullName = model.FullName,
                GuestSize = model.GuestSize,
                BookAt = model.BookAt,
                Phone = model.Phone,
                UserEmail = model.Email,
            };
            await _orderService.CheckoutOrder(order);
            return Redirect("/Home/Index");
        }

        public async Task<IActionResult> UpdateOrderStatus(OrderStatus orderStatus)
        {
            await _orderService.UpdateOrderStatus(orderStatus);
            return View();
        }
        public async Task<IActionResult> DeleteAsync(string orderId)
        {
            await _orderService.DeleteOrder(orderId);
            return View();
        }
    }
}
