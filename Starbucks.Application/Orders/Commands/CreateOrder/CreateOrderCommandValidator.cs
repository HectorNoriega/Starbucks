using FluentValidation;

namespace Starbucks.Application.Orders.Commands
{
    public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() { 
            RuleFor(x => x.ClientName).NotEmpty();
            RuleFor(x => x.NameAtention).NotEmpty();
        }
    }
}
