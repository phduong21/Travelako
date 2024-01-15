using AutoMapper;
using Booking.Application.Models;
using Coupon.Application.Contracts.Persistence;
using Coupon.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon
{
    public class CreateUserCouponCommandHandler : IRequestHandler<CreateUserCouponCommand, ApiResult<string>>
    {
        private readonly ICouponUserRepository _userCouponRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCouponCommandHandler> _logger;

        public CreateUserCouponCommandHandler(ICouponUserRepository userCouponRepository, IMapper mapper, ILogger<CreateUserCouponCommandHandler> logger)
        {
            _userCouponRepository = userCouponRepository ?? throw new ArgumentNullException(nameof(userCouponRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<string>> Handle(CreateUserCouponCommand request, CancellationToken cancellationToken)
        {
            var couponEntity = _mapper.Map<CouponUser>(request);
            var newCoupon = await _userCouponRepository.AddAsync(couponEntity);

            _logger.LogInformation($"Coupon user {newCoupon.Id} is successfully created.");
            return ApiResult<string>.Success(newCoupon.Id.ToString());
        }
    }
}
