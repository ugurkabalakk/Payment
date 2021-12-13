using Infrastructure.Domain;

namespace Domain.Entities.Order
{
    public class OrderEntity : DomainEntity
    {
        public string ConsumerFullName { get; set; }
        public string ConsumerAddress { get; set; }
    }
}