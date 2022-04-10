using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChannelEngine.Domain.Dtos.Stock;

namespace ChannelEngine.Domain.Dtos.Offer
{
    public class OfferDto
    {
        public OfferDto()
        {
            StockLocations = new List<StockLocationDto>();
        }
        public string MerchantProductNo { get; set; }
        public List<StockLocationDto> StockLocations { get; set; }
    }
}
