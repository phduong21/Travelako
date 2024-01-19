using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.Coupon.Queries.GetListCoupons
{
    public class GetCouponsListQuery : IRequest<List<CouponViewModel>>
    {
        public string UserId { get; set; }

        public GetCouponsListQuery(string userId )
        {
            UserId = userId;
        }
    }
}
