using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngine.Domain.Dtos.Order;
using ChannelEngine.Domain.Entities;

namespace ChannelEngine.Domain.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetAllOrders(string status);
    }
}