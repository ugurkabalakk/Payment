using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChannelEngine.Application.Common.Responses.Offer;
using AutoMapper;
using ChannelEngine.Domain.Dtos.Offer;

namespace ChannelEngine.Application.Offer.Commands.Mappings 
{
    public class UpdateStockCommandMappings : Profile
    {
        public UpdateStockCommandMappings()
        {
            CreateMap<UpdateStockCommand, OfferDto>();
            CreateMap<OfferDto, OfferResponse>();
        }
    }
}
