using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngine.Application.Common.CommandQueryWrappers;
using ChannelEngine.Application.Common.Responses.Order;
using ChannelEngine.Domain.Dtos.Order;
using ChannelEngine.Domain.Repositories.Interfaces;
using ChannelEngine.Infrastructure.Loggers;

namespace ChannelEngine.Application.Order.Queries
{
    public class GetAllOrdersQueryHandler : IRequestHandlerWrapper<GetAllOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IConsoleLogger _logger;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IConsoleLogger logger, IMapper mapper, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orderDtos = await _orderRepository.GetAllOrders(request.Status);

            return orderDtos;
        }
    }
}
