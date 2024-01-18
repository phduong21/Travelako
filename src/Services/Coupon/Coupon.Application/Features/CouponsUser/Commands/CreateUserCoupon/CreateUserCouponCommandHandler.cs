using AutoMapper;
using Booking.Application.Models;
using Coupon.Application.Contracts.Persistence;
using Coupon.Domain.Entities;
using FT.Travelako.Common.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon
{
    public class CreateUserCouponCommandHandler : IRequestHandler<CreateUserCouponCommand, ApiResult<string>>
    {
        private readonly ICouponUserRepository _userCouponRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCouponCommandHandler> _logger;

        public CreateUserCouponCommandHandler(ICouponUserRepository userCouponRepository, ICouponRepository _couponRepository, IMapper mapper, ILogger<CreateUserCouponCommandHandler> logger)
        {
            _userCouponRepository = userCouponRepository ?? throw new ArgumentNullException(nameof(userCouponRepository));
            _couponRepository = _couponRepository ?? throw new ArgumentNullException(nameof(_couponRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<string>> Handle(CreateUserCouponCommand request, CancellationToken cancellationToken)
        {
            var listCouponUser = new List<CouponUser>();
            var coupons = await _couponRepository.GetCouponsByUser(request.BusinessId);
            if (coupons == null)
            {
                return ApiResult<string>.Success($"Business user : {request.BusinessId} not have coupons");
            }
            foreach (var item in coupons)
            {
                listCouponUser.Add(new CouponUser() {UserId = request.UserId,CouponId = item.Id.ToString(),IsUsed = request.IsUsed});
            }
            var newCoupon = await _userCouponRepository.AddRangeAsync(listCouponUser);

            _logger.LogInformation($"Coupon user {request.UserId} is successfully created.");
            return ApiResult<string>.Success("User Coupon created successfully");
        }
    }
}
