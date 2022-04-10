using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChannelEngine.Application.Common.Responses.Order;
using AutoMapper;
using ChannelEngine.Domain.Dtos.Order;
using ChannelEngine.Domain.Entities;

namespace ChannelEngine.Application.Order.Queries.Mappings
{
    public class GetAllOrdersQueryMappings : Profile
    {
        public GetAllOrdersQueryMappings()
        {
            CreateMap<OrderEntity, OrderResponse>();
        }
        
    }
}
