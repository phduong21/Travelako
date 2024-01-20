namespace FT.Travelako.UI.Models.Orders
{
    public class CheckoutModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public int GuestSize { get; set; }
        public DateTime BookAt { get; set; }
        public decimal TotalCost { get; set; }
        public int Status { get; set; }
        public string TravelId { get; set; }
        public string UserId { get; set; }
        public string BusinessId { get; set; }
        public string CouponCode { get; set; }
        public string TourName { get; set; }

    }
}