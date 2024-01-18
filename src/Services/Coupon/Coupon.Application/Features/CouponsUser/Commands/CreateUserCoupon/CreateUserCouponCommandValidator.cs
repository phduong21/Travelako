using FluentValidation;


namespace Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon
{
    public class CreateUserCouponCommandValidator : AbstractValidator<CreateUserCouponCommand>
    {
        public CreateUserCouponCommandValidator()
        {
            RuleFor(p => p.BusinessId)
                .NotEmpty().WithMessage("{CouponId} is required.")
                .Custom((id,context) => {
                    if (!Guid.TryParse(id, out var couponId))
                    {
                    context.AddFailure($"Coupon ID: {id} is incorrect format");
                    }
                });

            RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("{UserId} is required.")
            .Custom((id, context) => {
                if (!Guid.TryParse(id, out var userId))
                {
                    context.AddFailure($"User ID: {id} is incorrect format");
                }
            });
        }
    }
}
