using Domain.Entities.Order;
using Infrastructure.Domain;
using Infrastructure.Enums;

namespace Domain.Entities.Payment
{
    public class PaymentEntity : DomainEntity
    {
        public PaymentEntity()
        {
            Order = new OrderEntity();
        }

        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public PaymentStatus Status { get; set; }
        public OrderEntity Order { get; set; }
    }
}