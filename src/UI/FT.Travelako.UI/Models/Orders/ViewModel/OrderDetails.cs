using FT.Travelako.UI.Models.Coupon;
using FT.Travelako.UI.Models.Travels;

namespace FT.Travelako.UI.Models.Orders.ViewModel
{
    public class OrderDetails
    {
        public string Id { get; set; }
        public string TourName { get; set; }
		public int GuestSize { get; set; }
        public string CreateDated { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string TravelId { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime BookAt { get; set; }
		public decimal TotalCost { get; set; }
		public string? CouponCode { get; set; }
	}

	public class ListOrders
	{
        public ListOrders()
        {
            Orders = new List<OrderDetails>();
        }
        public List<OrderDetails> Orders { get; set; }
	}
}
