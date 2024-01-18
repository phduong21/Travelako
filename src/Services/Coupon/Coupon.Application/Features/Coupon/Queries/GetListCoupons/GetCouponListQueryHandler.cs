using AutoMapper;
using Coupon.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.Coupon.Queries.GetListCoupons
{
    public class GetCouponListQueryHandler : IRequestHandler<GetCouponsListQuery, List<CouponViewModel>>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public GetCouponListQueryHandler(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<List<CouponViewModel>> Handle(GetCouponsListQuery request, CancellationToken cancellationToken)
        {
            var result = new List<CouponViewModel>();
            var couponList = await _couponRepository.GetCouponsByUser(request.UserId);
            foreach (var item in couponList)
            {
                result.Add(new CouponViewModel(item));
            }
            return result;
        }
    }
}
