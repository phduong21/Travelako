using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.Coupon.Queries.GetListCoupons
{
    public class CouponViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int Condition { get; set; }
        public TimeSpan TimeExpried { get; set; }
    }
}
