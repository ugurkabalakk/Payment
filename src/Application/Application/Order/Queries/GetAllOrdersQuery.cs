using System.Collections.Generic;
using ChannelEngine.Application.Common.CommandQueryWrappers;
using ChannelEngine.Application.Common.Responses.Order;
using ChannelEngine.Domain.Dtos.Order;

namespace ChannelEngine.Application.Order.Queries
{
    public class GetAllOrdersQuery : IRequestWrapper<IEnumerable<OrderDto>>
    {
        public string Status { get; set; }
    }
}
