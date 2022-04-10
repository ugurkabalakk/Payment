using FluentValidation;

namespace ChannelEngine.Application.Offer.Commands
{
    public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
    {
        public UpdateStockCommandValidator()
        {
            RuleFor(t => t.MerchantProductNo).NotEmpty().NotNull();
            RuleFor(t => t.StockLocations.Stock).NotNull().NotEmpty();
            RuleFor(t => t.StockLocations.StockLocationId).NotNull().NotEmpty();
        }
    }
}