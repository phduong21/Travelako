using Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.CouponsUser.Commands.UpdateUserCoupon
{
    public class UpdateUserCouponCommandValidator : AbstractValidator<UpdateUserCouponCommand>
    {
        public UpdateUserCouponCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("ID: {Id} is not null");
            RuleFor(p => p.CouponId)
                .Custom((id, context) => {
                    if (!Guid.TryParse(id, out var couponId))
                    {
                        context.AddFailure($"Coupon ID: {id} is incorrect format");
                    }
                });

            RuleFor(p => p.UserId)
            .Custom((id, context) => {
                if (!Guid.TryParse(id, out var userId))
                {
                    context.AddFailure($"User ID: {id} is incorrect format");
                }
            });
        }
    }
}
