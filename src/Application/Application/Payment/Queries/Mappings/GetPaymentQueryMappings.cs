using Application.Common.Responses;
using AutoMapper;
using Domain.Entities.Payment;

namespace Application.Payment.Queries.Mappings
{
    public class GetPaymentQueryMappings : Profile
    {
        public GetPaymentQueryMappings()
        {
            CreateMap<PaymentEntity, PaymentResponse>();
        }
    }
}