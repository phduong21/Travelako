using AutoMapper;
using Coupon.Application.Contracts.Persistence;
using Coupon.Application.Exceptions;
using Coupon.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Coupon.Application.Features.CouponsUser.Commands.UpdateUserCoupon
{
    public class UpdateUserCouponCommandHandler : IRequestHandler<UpdateUserCouponCommand>
    {
        private readonly ICouponUserRepository _userCouponRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserCouponCommandHandler> _logger;

        public UpdateUserCouponCommandHandler(ICouponUserRepository userCouponRepository, IMapper mapper, ILogger<UpdateUserCouponCommandHandler> logger)
        {
            _userCouponRepository = userCouponRepository ?? throw new ArgumentNullException(nameof(userCouponRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(UpdateUserCouponCommand request, CancellationToken cancellationToken)
        {
            var couponToUpdate = await _userCouponRepository.GetByIdAsync(request.Id);
            if (couponToUpdate == null)
            {
                throw new NotFoundException(nameof(CouponUser), request.Id);
            }

            couponToUpdate.CouponId = request.CouponId ?? couponToUpdate.CouponId;
            couponToUpdate.IsUsed = request.IsUsed ?? couponToUpdate.IsUsed;

            await _userCouponRepository.UpdateAsync(couponToUpdate);

            _logger.LogInformation($"Order {couponToUpdate.Id} is successfully updated.");
        }
    }
}
