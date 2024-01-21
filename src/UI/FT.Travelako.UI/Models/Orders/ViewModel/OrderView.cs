using FT.Travelako.UI.Models.Coupon;
using FT.Travelako.UI.Models.Travels;
using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.UI.Models.Orders.ViewModel
{
    public class OrderView
    {
		public string Id { get; set; }
		public string FullName { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }
		public int GuestSize { get; set; }
		public DateTime BookAt { get; set; }
		public decimal TotalCost { get; set; }
		public string? CouponCode { get; set; }
		public string? TravelId { get; set; }
	}
}
