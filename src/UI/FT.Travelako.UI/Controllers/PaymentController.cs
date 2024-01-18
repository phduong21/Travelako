using FT.Travelako.UI.Models.Booking;
using FT.Travelako.UI.Models.Users.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.UI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string userId)
        {
            var model = new PaymentBooking() { BookingId = userId };
            return View("Index",model);
        }

        [HttpPost]
        public async Task<IActionResult> Billing(PaymentBooking model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            // Booking service to change status

            return View("PaymentSuccess");
        }
    }
}
