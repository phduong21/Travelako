using FluentValidation;

namespace Booking.Application.Features.Order.Commands.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandValidator : AbstractValidator<ChangeOrderStatusCommand>
    {
        public ChangeOrderStatusCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.");
        }
    }
}
