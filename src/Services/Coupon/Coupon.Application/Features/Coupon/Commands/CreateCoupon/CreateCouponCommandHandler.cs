using AutoMapper;
using Booking.Application.Models;
using Coupon.Application.Contracts.Persistence;
using Coupon.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;

namespace Coupon.Application.Features.Coupon.Commands.CreateCoupon
{
    public class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommand, ApiResult<string>>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCouponCommandHandler> _logger;

        public CreateCouponCommandHandler(ICouponRepository couponRepository, IMapper mapper, ILogger<CreateCouponCommandHandler> logger)
        {
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<string>> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            var couponEntity = new Coupons()
            {
                Title = request.Title,
                Code = request.Code,
                Discount = request.Discount,
                Condition = request.Condition,
                TimeExpried = request.TimeExpried,
                CreatedBy = request.CreatedBy,
            };
            
            var newCoupon = await _couponRepository.AddAsync(couponEntity);

            _logger.LogInformation($"Coupon {newCoupon.Id} is successfully created.");
            return ApiResult<string>.Success(newCoupon.Id.ToString());
        }
    }
}
