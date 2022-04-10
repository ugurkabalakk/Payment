using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChannelEngine.Domain.Dtos.Stock;

namespace ChannelEngine.Domain.Dtos.Order
{
    public class OrderDto
    {
        public string MerchantProductNo { get; set; }
        public string Gtin { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

    }
}
