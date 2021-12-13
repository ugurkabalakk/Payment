using Domain.Entities.Order;
using Infrastructure.Enums;

namespace Application.Common.Responses
{
    public class PaymentResponse : IPaymentResponse
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public PaymentStatus Status { get; set; }
        public OrderEntity Order { get; set; }
        public string Id { get; set; }
    }
}