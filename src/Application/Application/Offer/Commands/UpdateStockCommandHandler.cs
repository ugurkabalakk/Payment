using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngine.Application.Common.CommandQueryWrappers;
using ChannelEngine.Application.Common.Responses.Offer;
using ChannelEngine.Domain.Repositories.Interfaces;
using ChannelEngine.Infrastructure.Loggers;
using ChannelEngine.Domain.Dtos.Offer;
using ChannelEngine.Domain.Dtos.Stock;

namespace ChannelEngine.Application.Offer.Commands
{
    public class UpdateStockCommandHandler : IRequestHandlerWrapper<UpdateStockCommand, OfferResponse>
    {
        private readonly IConsoleLogger _logger;
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public UpdateStockCommandHandler(IConsoleLogger logger, IMapper mapper, IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OfferResponse> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            //to do map
            var offerDto = new OfferDto
            {
                MerchantProductNo = request.MerchantProductNo,
                StockLocations = new List<StockLocationDto>{  new StockLocationDto{
                        Stock = request.StockLocations.Stock,
                        StockLocationId = request.StockLocations.StockLocationId
                    }
                }
            };

            await _offerRepository.UpdateStock(offerDto);

            var response = _mapper.Map<OfferResponse>(offerDto);

            return response;
        }
    }
}