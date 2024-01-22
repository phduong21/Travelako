using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{FullName} is required.");

            RuleFor(p => p.UserId)
               .NotEmpty().WithMessage("{UserId} is required.");

            RuleFor(p => p.BusinessId)
               .NotEmpty().WithMessage("{BusinessId} is required.");

            RuleFor(p => p.UserEmail)
               .NotEmpty().WithMessage("{UserEmail} is required.")
               .EmailAddress().WithMessage("Please specify a valid email address");

            RuleFor(p => p.TotalCost)
                .NotEmpty().WithMessage("{TotalCost} is required.")
                .GreaterThan(0).WithMessage("{TotalCost} should be greater than zero.");
        }
    }
}
