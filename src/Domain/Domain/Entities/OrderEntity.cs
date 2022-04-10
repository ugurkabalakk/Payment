using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.Domain.Entities
{
    public class OrderEntity
    {
        public OrderEntity()
        {
            Content = new List<ContentEntity>();
        }
        public List<ContentEntity> Content { get; set; }
        public int? Count { get; set; }
        public int? ItemsPerPage { get; set; }
        public int? LogId { get; set; }
        public string Message { get; set; }
        public int? StatusCode { get; set; }
        public bool Success { get; set; }
        public int? TotalCount { get; set; }
    }
}
