using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Models.Orders.ViewModel;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ITravelService _travelService;
        private readonly IUserService _userService;
        private readonly ICouponService _couponService;

        public BookingController(IOrderService orderService, ITravelService travelService, IUserService userService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _travelService = travelService ?? throw new ArgumentNullException(nameof(travelService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
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

        public async Task<IActionResult> CreateBooking(string travelId)
        {
            var travel = await _travelService.GetTravelDetail(travelId);
            var currentUser = _userService.GetCurrentUser();
            var coupon = await _couponService.GetCouponByUserId(currentUser.Id);
            var orderView = new Order
            {
                Coupons = coupon,
                TravelDetails = travel.result
            };
            return View(orderView);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order model)
        {
            if (!ModelState.IsValid)
            {
                return View("CheckoutAsync", model);
            }
            var travel = await _travelService.GetTravelDetail(model.TravelDetails.id);
            var currentUser = _userService.GetCurrentUser();

            var order = new CheckoutModel()
            {
                FullName = model.FullName,
                GuestSize = model.GuestSize,
                BookAt = model.BookAt,
                Phone = model.Phone,
                UserEmail = model.Email,
                TotalCost = model.TotalCost,
                TravelId = new Guid(model.TravelDetails.id),
                Status = 0,
                UserId = new Guid(currentUser.Id),
                BusinessId = travel.result.createdBy
                
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
