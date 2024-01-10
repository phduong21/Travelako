using Coupon.Application.Features.Coupon.Commands.CreateCoupon;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.Coupon.Commands.UpdateCoupon
{
    public class UpdateCouponCommandValidator : AbstractValidator<UpdateCouponCommand>
    {
        public UpdateCouponCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.");
            RuleFor(p => p.Discount)
               .GreaterThan(0).WithMessage("{Discount} is greater than 0%")
               .LessThan(100).WithMessage("{Discount} is less than 0%");
            RuleFor(p => p.Condition)
               .GreaterThan(0).WithMessage("{Condition} is greater than 0%");
        }
    }
}
