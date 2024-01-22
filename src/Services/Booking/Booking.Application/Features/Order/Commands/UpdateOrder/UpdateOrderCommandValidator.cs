﻿using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class ChangeOrderStatusCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public ChangeOrderStatusCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.");
        }
    }
}
