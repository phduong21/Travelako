using FT.Travelako.UI.Models.Coupon;
using FT.Travelako.UI.Models.Travels;

namespace FT.Travelako.UI.Models.Orders.ViewModel
{
    public class OrderView
    {
        public List<CouponResponseModel> Coupons { get; set; }
        public TravelDetailModel TravelDetails { get; set; }
    }
}
