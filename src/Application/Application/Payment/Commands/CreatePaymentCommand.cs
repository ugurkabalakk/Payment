using Application.Common.CommandQueryWrappers;
using Application.Common.Responses;

namespace Application.Payment.Commands
{
    public class CreatePaymentCommand : IRequestWrapper<PaymentResponse>
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public OrderInformation OrderInformation { get; set; }
    }

    public class OrderInformation
    {
        public string ConsumerFullName { get; set; }
        public string ConsumerAddress { get; set; }
    }
}