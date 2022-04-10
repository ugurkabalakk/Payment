using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ChannelEngine.Domain.Dtos.Offer;
using ChannelEngine.Domain.Dtos.Stock;
using ChannelEngine.Domain.Entities;
using ChannelEngine.Domain.Repositories.Interfaces;
using Newtonsoft.Json;

namespace ChannelEngine.Domain.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        public async Task UpdateStock(OfferDto offerDto)
        {

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-dev.channelengine.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var offer = JsonConvert.SerializeObject(offerDto);
            var requestContent = new StringContent(offer, Encoding.UTF8);
            var uri = "api/v2/offer/stock?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
            var response = await client.PutAsJsonAsync(uri, offer);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                
            }
        }
    }
}

