namespace FT.Travelako.UI.Models.Orders
{
    public class CheckoutModel
    {
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public int GuestSize { get; set; }
        public DateTime BookAt { get; set; }
        public decimal TotalCost { get; set; }
        public int Status { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
        public string BusinessId { get; set; }
        public string CouponCode { get; set; }
    }
}
