using AutoMapper;
using Coupon.Application.Contracts.Persistence;
using Coupon.Domain.Entities;
using FT.Travelako.Common.Entities;
using MediatR;
using System.Linq;


namespace Coupon.Application.Features.CouponsUser.Queries.GetListCouponByUserId
{
    public class GetUserCouponListQueryHandler : IRequestHandler<GetUserCouponsListQuery, List<CouponUserModel>>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly ICouponUserRepository _userCouponRepository;
        private readonly IMapper _mapper;

        public GetUserCouponListQueryHandler(ICouponRepository couponRepository, ICouponUserRepository userCouponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
            _userCouponRepository = userCouponRepository ?? throw new ArgumentNullException(nameof(userCouponRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CouponUserModel>> Handle(GetUserCouponsListQuery request, CancellationToken cancellationToken)
        {
            var couponList = await _couponRepository.GetCouponsByUser(request.BusinessUserId);
            var userCouponList = await _userCouponRepository.GetCouponsByUser(request.UserId);

            var couponVM = couponList.Join(userCouponList, coupon => coupon.Id.ToString(), userCoupon => userCoupon.CouponId,
                (coupon, userCoupon) => new CouponUserModel(userCoupon.Id.ToString(), userCoupon.CouponId, userCoupon.UserId, userCoupon.IsUsed.Value, coupon.Title, coupon.Code, coupon.Discount, coupon.TimeExpried)).ToList();

            return couponVM;
        }
    }
}
