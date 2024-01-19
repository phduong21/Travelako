using Coupon.Application.Features.Coupon.Queries.GetListCoupons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.CouponsUser.Queries.GetListCouponByUserId
{
    public class GetUserCouponsListQuery : IRequest<List<CouponUserModel>>
    {
        public string UserId { get; set; }
        public string BusinessUserId { get; set; }

        public GetUserCouponsListQuery(string userId,string businessUserId)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            BusinessUserId = businessUserId ?? throw new ArgumentNullException(nameof(businessUserId)); ;
        }
    }
}
