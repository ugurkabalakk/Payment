using System.Threading;
using System.Threading.Tasks;
using Application.Common.CommandQueryWrappers;
using Application.Common.Responses;
using AutoMapper;
using Domain.Repositories;
using Infrastructure.Loggers;

namespace Application.Payment.Queries
{
    public class GetPaymentQueryHandler : IRequestHandlerWrapper<GetPaymentQuery, PaymentResponse>
    {
        private readonly IConsoleLogger _logger;
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentQueryHandler(IConsoleLogger logger, IMapper mapper, IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PaymentResponse> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var entity = await _paymentRepository.GetPayment(request.PaymentId);
            var paymentResponse = _mapper.Map<PaymentResponse>(entity);
            return paymentResponse;
        }
    }
}