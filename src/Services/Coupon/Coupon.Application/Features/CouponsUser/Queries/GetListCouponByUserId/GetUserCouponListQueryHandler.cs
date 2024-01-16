using AutoMapper;
using Coupon.Application.Contracts.Persistence;
using Coupon.Domain.Entities;
using MediatR;


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
            var listCoupon = new List<Coupons>();
            var userCouponList = (await _userCouponRepository.GetCouponsByUser(request.UserId)).ToList();
            for (int i = 0; i < userCouponList.Count(); i++)
            {
                listCoupon.Add(await _couponRepository.GetByIdAsync(userCouponList[i].CouponId));
            }
            var couponVM = _mapper.Map<List<CouponUserModel>>(listCoupon);
            couponVM = _mapper.Map<List<CouponUserModel>>(userCouponList);

            return _mapper.Map<List<CouponUserModel>>(couponVM);
        }
    }
}
