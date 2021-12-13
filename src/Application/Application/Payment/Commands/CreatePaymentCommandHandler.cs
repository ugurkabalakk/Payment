using System.Threading;
using System.Threading.Tasks;
using Application.Common.CommandQueryWrappers;
using Application.Common.Responses;
using AutoMapper;
using Domain.Entities.Payment;
using Domain.Repositories;
using Infrastructure.Enums;
using Infrastructure.Loggers;

namespace Application.Payment.Commands
{
    public class CreatePaymentCommandHandler : IRequestHandlerWrapper<CreatePaymentCommand, PaymentResponse>
    {
        private readonly IConsoleLogger _logger;
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentCommandHandler(IConsoleLogger logger, IMapper mapper, IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PaymentResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PaymentEntity>(request);
            entity.Status = PaymentStatus.Created;
            entity.Order.ConsumerAddress = request.OrderInformation.ConsumerAddress;
            entity.Order.ConsumerFullName = request.OrderInformation.ConsumerFullName;
            await _paymentRepository.InsertPayment(entity);
            var response = _mapper.Map<PaymentResponse>(entity);
            return response;
        }
    }
}