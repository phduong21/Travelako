using FT.Travelako.UI.Models.Coupon;
using FT.Travelako.UI.Models.Travels;
using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.UI.Models.Orders
{
    public class Order
    {
        [Required(ErrorMessage = "Username is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]

        public string Phone { get; set; }
        public int GuestSize { get; set; }
        [Required(ErrorMessage = "Enter the Book date.")]
        [DataType(DataType.Date)]
        public DateTime BookAt { get; set; }
        public decimal TotalCost { get; set; }
        public string? CouponCode { get; set; }
        public string? TravelId { get; set; }

	}
}
