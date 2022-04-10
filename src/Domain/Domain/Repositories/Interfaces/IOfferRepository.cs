using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChannelEngine.Domain.Dtos.Offer;

namespace ChannelEngine.Domain.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        Task UpdateStock(OfferDto offerDto);
    }
}
