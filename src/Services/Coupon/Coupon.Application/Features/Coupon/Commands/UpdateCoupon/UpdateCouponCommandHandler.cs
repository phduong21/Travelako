using AutoMapper;
using Booking.Application.Models;
using Coupon.Application.Contracts.Persistence;
using Coupon.Application.Exceptions;
using Coupon.Application.Features.Coupon.Commands.CreateCoupon;
using Coupon.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.Coupon.Commands.UpdateCoupon
{
    public class UpdateCouponCommandHandler : IRequestHandler<UpdateCouponCommand>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCouponCommandHandler> _logger;

        public UpdateCouponCommandHandler(ICouponRepository couponRepository, IMapper mapper, ILogger<UpdateCouponCommandHandler> logger)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
        {
            var couponToUpdate = await _couponRepository.GetByIdAsync(request.Id);
            if (couponToUpdate == null)
            {
                throw new NotFoundException(nameof(Coupons), request.Id);
            }

            couponToUpdate.Title = request.Title ?? couponToUpdate.Title;
            couponToUpdate.Code = request.Title ?? couponToUpdate.Title;
            couponToUpdate.Discount = request.Discount == 0 ? request.Discount : couponToUpdate.Discount;
            couponToUpdate.Condition = request.Condition == 0 ? request.Condition : couponToUpdate.Condition;
            couponToUpdate.TimeExpried = request.TimeExpried == 0 ? request.TimeExpried : couponToUpdate.TimeExpried;
            couponToUpdate.LastModifiedBy = request.LastModifiedBy;
            await _couponRepository.UpdateAsync(couponToUpdate);

            _logger.LogInformation($"Order {couponToUpdate.Id} is successfully updated.");
        }
    }
}
