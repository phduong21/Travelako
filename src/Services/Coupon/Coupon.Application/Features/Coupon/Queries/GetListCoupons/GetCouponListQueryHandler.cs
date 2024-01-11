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
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CouponViewModel>> Handle(GetCouponsListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _couponRepository.GetCouponsByUser(request.UserId);
            return _mapper.Map<List<CouponViewModel>>(orderList);
        }
    }
}
