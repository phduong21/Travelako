using FT.Travelako.Common.Entities;

namespace Coupon.Domain.Entities
{
    public class Coupons : EntityBase
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int Condition { get; set; }

        public TimeSpan TimeExpried { get; set; }
    }
}
