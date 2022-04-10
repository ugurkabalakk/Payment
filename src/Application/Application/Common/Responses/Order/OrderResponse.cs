using System;
using System.Collections.Generic;
using ChannelEngine.Domain.Entities;

namespace ChannelEngine.Application.Common.Responses.Order
{
    public class OrderResponse
    {
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