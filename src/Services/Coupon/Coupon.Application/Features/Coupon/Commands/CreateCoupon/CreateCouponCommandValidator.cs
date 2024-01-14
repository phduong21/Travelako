using FluentValidation;

namespace Coupon.Application.Features.Coupon.Commands.CreateCoupon
{
    internal class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
    {
        public CreateCouponCommandValidator()
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{Code} is required.");
            RuleFor(p => p.Discount)
               .NotEmpty().WithMessage("{Discount} is required.")
               .GreaterThan(0).WithMessage("{Discount} is greater than 0%")
               .LessThan(100).WithMessage("{Discount} is less than 0%");
            RuleFor(p => p.Condition)
               .NotEmpty().WithMessage("{Condition} is required.")
               .GreaterThan(0).WithMessage("{Condition} is greater than 0%");
        }
    }
}
