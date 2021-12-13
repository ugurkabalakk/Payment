using FluentValidation;

namespace Application.Payment.Queries
{
    public class GetPaymentQueryValidator : AbstractValidator<GetPaymentQuery>
    {
        public GetPaymentQueryValidator()
        {
            RuleFor(t => t.PaymentId).NotNull().NotEmpty().Length(24);
        }
    }
}