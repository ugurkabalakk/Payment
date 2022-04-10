using FluentValidation;

namespace ChannelEngine.Application.Order.Queries
{
    public class GetAllOrdersQueryValidator : AbstractValidator<GetAllOrdersQuery>
    {
        public GetAllOrdersQueryValidator()
        {
            RuleFor(t => t.Status).NotEmpty().NotNull();
        }
    }
}
