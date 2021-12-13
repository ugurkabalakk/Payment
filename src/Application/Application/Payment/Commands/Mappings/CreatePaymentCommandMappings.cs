using Application.Common.Responses;
using AutoMapper;
using Domain.Entities.Payment;

namespace Application.Payment.Commands.Mappings
{
    public class CreatePaymentCommandMappings : Profile
    {
        public CreatePaymentCommandMappings()
        {
            CreateMap<CreatePaymentCommand, PaymentEntity>();
            CreateMap<PaymentEntity, PaymentResponse>();
        }
    }
}