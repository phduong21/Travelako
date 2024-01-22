using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class GetOrderDetailsCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public GetOrderDetailsCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.");
        }
    }
}
