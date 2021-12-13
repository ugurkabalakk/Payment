using FluentValidation;

namespace Application.Payment.Commands
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(t => t.Amount).GreaterThan(0);
            RuleFor(t => t.CurrencyCode).NotEmpty().NotNull();
            RuleFor(t => t.OrderInformation.ConsumerAddress).NotNull().NotEmpty();
            RuleFor(t => t.OrderInformation.ConsumerFullName).NotNull().NotEmpty();
        }
    }
}