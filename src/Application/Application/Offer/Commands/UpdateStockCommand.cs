using ChannelEngine.Application.Common.CommandQueryWrappers;
using ChannelEngine.Application.Common.Responses;
using ChannelEngine.Application.Common.Responses.Offer;

namespace ChannelEngine.Application.Offer.Commands
{
    public class UpdateStockCommand : IRequestWrapper<OfferResponse>
    {
        public string MerchantProductNo { get; set; }
        public StockLocations StockLocations { get; set; }
    }

    public class StockLocations
    {
        public int Stock { get; set; }
        public int StockLocationId { get; set; }
    }
}