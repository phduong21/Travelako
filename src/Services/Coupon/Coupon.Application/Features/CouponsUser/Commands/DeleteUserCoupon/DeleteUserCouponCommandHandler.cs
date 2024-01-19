using AutoMapper;
using Coupon.Application.Contracts.Persistence;
using Coupon.Application.Exceptions;
using Coupon.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Coupon.Application.Features.CouponsUser.Commands.DeleteUserCoupon
{
    public class DeleteUserCouponCommandHandler : IRequestHandler<DeleteUserCouponCommand>
    {
        private readonly ICouponUserRepository _userCouponRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserCouponCommandHandler> _logger;

        public DeleteUserCouponCommandHandler(ICouponUserRepository userCouponRepository, IMapper mapper, ILogger<DeleteUserCouponCommandHandler> logger)
        {
            _userCouponRepository = userCouponRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(DeleteUserCouponCommand request, CancellationToken cancellationToken)
        {
            var couponToDelete = await _userCouponRepository.GetByIdAsync(request.Id);
            if (couponToDelete == null)
            {
                throw new NotFoundException(nameof(Coupons), request.Id);
            }

            await _userCouponRepository.DeleteAsync(couponToDelete);

            _logger.LogInformation($"User Coupon {couponToDelete.Id} is successfully deleted.");
        }
    }
}
