using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Models.Orders.ViewModel;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FT.Travelako.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ITravelService _travelService;
        private readonly IUserService _userService;
        private readonly ICouponService _couponService;

        public BookingController(IOrderService orderService, ITravelService travelService, IUserService userService, ICouponService couponService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _travelService = travelService ?? throw new ArgumentNullException(nameof(travelService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _couponService = couponService ?? throw new ArgumentNullException(nameof(couponService));
        }

        public async Task<IActionResult> OrdersHistory(string userId)
        {
            var currentUser = _userService.GetCurrentUser();
            if (currentUser != null)
            {
                var orders = await _orderService.GetOrdersByUserId(currentUser.Id);
                return View(orders);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Detail(string orderId)
        {
            var orders = await _orderService.GetOrderDetails(orderId);
            return View(orders);
        }

        public async Task<IActionResult> CreateBooking(string id)
        {
            var travel = await _travelService.GetTravelDetail(id);
            var currentUser = _userService.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var coupon = await _couponService.GetCouponByUserId(currentUser.Id);
            ViewBag.TourName = travel.result.title;
            ViewBag.TourPrice = travel.result.hotelPrice;
            ViewBag.CouponCode = new SelectList(coupon.Select(x => x.Code).ToList());
            TempData["TravelId"] = travel.result.id;
            TempData["BusinessId"] = travel.result.createdBy;
            TempData["TourName"] = travel.result.title;
            TempData["Price"] = travel.result.hotelPrice;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order model)
        {
            model.TravelId = Convert.ToString(TempData["TravelId"]);
            var price = Convert.ToDecimal(TempData["Price"]);
            if (!ModelState.IsValid)
            {
                return View("CheckoutAsync", model);
            }
            var currentUser = _userService.GetCurrentUser();

            var order = new CheckoutModel()
            {
                FullName = model.FullName,
                GuestSize = model.GuestSize,
                BookAt = model.BookAt,
                Phone = model.Phone,
                UserEmail = model.Email,
                TotalCost = model.GuestSize * price,
                TravelId = model.TravelId,
                Status = 0,
                UserId = currentUser.Id,
                BusinessId = Convert.ToString(TempData["BusinessId"]),
                TourName = Convert.ToString(TempData["TourName"]),
                CouponCode = model.CouponCode,
            };
            await _orderService.CheckoutOrder(order);
            return RedirectToAction("Index", "Home");
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
