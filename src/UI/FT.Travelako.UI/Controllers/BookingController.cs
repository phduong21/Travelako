using Elasticsearch.Net;
using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Models.Orders.ViewModel;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using System;

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

        public async Task<IActionResult> OrdersHistory()
        {
            var currentUser = _userService.GetCurrentUser();
            if (currentUser != null)
            {
                var orders = await _orderService.GetOrdersByUserId(currentUser.Id);
                var listOrderDetails = orders.Select(x => new OrderDetails()
                {
                    Id = x.Id,
                    TravelId = x.TravelId.ToString(),
                    TourName = x.TourName,
                    TotalPrice = x.TotalCost,
                    GuestSize = x.GuestSize,
                    CreateDated = x.CreatedDate.ToString("dd MM yyyy"),
                    Status = OrderStatus(x.Status)
                });
                var listOrders = new ListOrders();
                listOrders.Orders.AddRange(listOrderDetails);
                return View(listOrders);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Detail(string orderId)
        {
            var order = await _orderService.GetOrderDetails(orderId);
            if (order == null)
            {
                return View("NotFound");
            }
            var orderDetails = new OrderDetails()
            {
                Id = order.Id,
                TravelId = order.TravelId.ToString(),
                TourName = order.TourName,
                TotalPrice = order.TotalCost,
                GuestSize = order.GuestSize,
                CreateDated = order.CreatedDate.ToString("dd MM yyyy")
            };
            return View(orderDetails);
        }

        [Route("Booking/CreateBooking/{id}")]
        public async Task<IActionResult> CreateBooking(string id)
        {
            var travel = await _travelService.GetTravelDetail(id);
            var currentUser = _userService.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var coupon = await _couponService.GetCouponByUserId(currentUser.Id, travel.result.createdBy);
            ViewBag.TourName = travel.result.title;
            ViewBag.TourPrice = travel.result.hotelPrice;
            ViewBag.CouponCode = new SelectList(coupon.Select(x => x.Code).ToList());
            ViewBag.Coupon = coupon.Select(x => new CouponOrder
            {
                Id = x.Id,
                Title = x.Title,
                Code = x.Code,
                Discount = x.Discount
            }).ToList();
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
		        return RedirectToAction("CreateBooking", "Booking", new { id = model.TravelId });
	        }
            var currentUser = _userService.GetCurrentUser();

            var order = new CheckoutModel()
            {
                FullName = model.FullName,
                GuestSize = model.GuestSize,
                BookAt = model.BookAt,
                Phone = model.Phone,
                UserEmail = model.Email,
                TotalCost = (model.GuestSize * price) * model.CouponDiscount / 100,
                TravelId = model.TravelId,
                Status = 0,
                UserId = currentUser.Id,
                BusinessId = Convert.ToString(TempData["BusinessId"]),
                TourName = Convert.ToString(TempData["TourName"]),
                CouponCode = model.CouponCode,
            };
            var newOrder = await _orderService.CheckoutOrder(order);
            return RedirectToAction("Index", "Payment", new { orderId = newOrder.Id });
        }

        [HttpPost]
		public async Task<IActionResult> UpdateOrderStatus(string orderId)
        {
            var orderStatus = new OrderStatus()
            {
                Id = new Guid(orderId),
                Status = (int)Status.Cancel
            };
            await _orderService.UpdateOrderStatus(orderStatus);
            return RedirectToAction("OrdersHistory", "Booking");
        }
        public async Task<IActionResult> DeleteAsync(string orderId)
        {
            await _orderService.DeleteOrder(orderId);
            return View();
        }

        private string OrderStatus(int status)
        {
            if (status == (int)Status.Draft)
            {
                return nameof(Status.Draft);
            }
            else if (status == (int)Status.Ordered)
            {
                return nameof(Status.Ordered);
            }
            else if (status == (int)Status.Payment)
            {
                return nameof(Status.Payment);
            }
            else if (status == (int)Status.Cancel)
            {
                return nameof(Status.Cancel);
            }
            return string.Empty;
        }
    }
}
