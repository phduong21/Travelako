using FT.Travelako.UI.Models.Booking;
using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Models.Users.ViewModel;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.UI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
		private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public PaymentController(ILogger<PaymentController> logger, IOrderService orderService, IUserService userService)
        {
            _logger = logger;
			_orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
			_userService = userService ?? throw new ArgumentNullException(nameof(userService));
		}

        public IActionResult Index(string orderId)
        {
            var model = new PaymentBooking() { BookingId = orderId };
            return View("Index",model);
        }

        [HttpPost]
        public async Task<IActionResult> Billing(string orderId)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", orderId);
            }
            // Booking service to change status

            var currentUser = _userService.GetCurrentUser();
            await _orderService.UpdateOrderStatus(new OrderStatus
            {
                Id = new Guid(orderId),
                Status = 1,
                UserId = !string.IsNullOrWhiteSpace(currentUser?.Id) ? currentUser?.Id : string.Empty
            });

            return View("PaymentSuccess");
        }
    }
}
