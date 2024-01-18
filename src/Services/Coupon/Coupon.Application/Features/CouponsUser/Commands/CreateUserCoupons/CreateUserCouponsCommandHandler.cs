using AutoMapper;
using Booking.Application.Models;
using Coupon.Application.Contracts.Persistence;
using Coupon.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupons
{
    public class CreateUserCouponsCommandHandler : IRequestHandler<CreateUserCouponsCommand>
    {
        private readonly ICouponUserRepository _userCouponRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCouponsCommandHandler> _logger;

        public CreateUserCouponsCommandHandler(ICouponUserRepository userCouponRepository, ICouponRepository couponRepository, IMapper mapper, ILogger<CreateUserCouponsCommandHandler> logger)
        {
            _userCouponRepository = userCouponRepository;
            _couponRepository = couponRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(CreateUserCouponsCommand request, CancellationToken cancellationToken)
        {
            var listCouponUser = new List<CouponUser>();
            var coupons = await _couponRepository.GetCouponsByUser(request.BusinessId);
            if (coupons == null)
            {
               return;
            }
            foreach (var item in coupons)
            {
                if (item.Condition <= request.CountBooking)
                {
                    listCouponUser.Add(new CouponUser() { UserId = request.UserId, CouponId = item.Id.ToString(), IsUsed = request.IsUsed });
                }
            }
            var couponsUser = (await _userCouponRepository.GetCouponsByUser(request.UserId)).Select(x=> x.CouponId);
            if (couponsUser != null)
            {
                var isHasCoupons = listCouponUser.Where(x=> couponsUser.Contains(x.CouponId)).ToList();
                foreach (var item in isHasCoupons) 
                {
                    listCouponUser.Remove(item);
                }
            }
            await _userCouponRepository.AddRangeAsync(listCouponUser);
            _logger.LogInformation($"Coupon user {request.UserId} is successfully created.");
        }
    }
}
