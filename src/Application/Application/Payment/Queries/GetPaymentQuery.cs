using Application.Common.CommandQueryWrappers;
using Application.Common.Responses;

namespace Application.Payment.Queries
{
    public class GetPaymentQuery : IRequestWrapper<PaymentResponse>
    {
        public string PaymentId { get; set; }
    }
}