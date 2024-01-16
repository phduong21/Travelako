﻿using AutoMapper;
using Coupon.Application.Contracts.Persistence;
using Coupon.Application.Exceptions;
using Coupon.Application.Features.Coupon.Commands.UpdateCoupon;
using Coupon.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var couponToUpdate = await _userCouponRepository.GetByIdAsync(request.Id.ToString());
            if (couponToUpdate == null)
            {
                throw new NotFoundException(nameof(CouponUser), request.Id);
            }

            _mapper.Map(request, couponToUpdate, typeof(UpdateUserCouponCommand), typeof(CouponUser));

            await _userCouponRepository.UpdateAsync(couponToUpdate);

            _logger.LogInformation($"Order {couponToUpdate.Id} is successfully updated.");
        }
    }
}