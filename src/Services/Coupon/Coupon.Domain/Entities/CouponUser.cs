using FT.Travelako.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Entities
{
    public class CouponUser : EntityBase
    {
        public string CouponId { get; set; }
        public string UserId { get; set; }
        public bool? IsUsed { get; set; }
    }
}
