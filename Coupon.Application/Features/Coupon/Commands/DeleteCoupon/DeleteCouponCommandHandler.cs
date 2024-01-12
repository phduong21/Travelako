using AutoMapper;
using Coupon.Application.Contracts.Persistence;
using Coupon.Application.Exceptions;
using Coupon.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Coupon.Application.Features.Coupon.Commands.DeleteCoupon
{
    public class DeleteCouponCommandHandler : IRequestHandler<DeleteCouponCommand>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCouponCommandHandler> _logger;

        public DeleteCouponCommandHandler(ICouponRepository couponRepository, IMapper mapper, ILogger<DeleteCouponCommandHandler> logger)
        {
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            var couponToDelete = await _couponRepository.GetByIdAsync(request.Id);
            if (couponToDelete == null)
            {
                throw new NotFoundException(nameof(Coupons), request.Id);
            }

            await _couponRepository.DeleteAsync(couponToDelete);

            _logger.LogInformation($"Coupon {couponToDelete.Id} is successfully deleted.");
        }
    }
}
