using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ChannelEngine.Domain.Dtos.Order;
using ChannelEngine.Domain.Entities;
using ChannelEngine.Domain.Repositories.Interfaces;
using Newtonsoft.Json;

namespace ChannelEngine.Domain.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<IEnumerable<OrderDto>> GetAllOrders(string status)
        {
            try
            {
                string Baseurl = "https://api-dev.channelengine.net/";
                using var client = new HttpClient();
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                var builder = new StringBuilder();
                
                HttpResponseMessage response = await client.GetAsync(
                    "api/v2/orders?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322&statuses=IN_PROGRESS");

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                   var orderEntity = JsonConvert.DeserializeObject<OrderEntity>(result);

                    if (orderEntity != null)
                    { 
                       var orderDto = orderEntity.Content.SelectMany(order => order.Lines)
                            .GroupBy(line => line.MerchantProductNo)
                            .Select(grp => new OrderDto
                            {
                                MerchantProductNo = grp.First().MerchantProductNo,
                                Gtin = grp.First().Gtin,
                                Description = grp.First().Description,
                                Quantity = grp.Sum(l => l.Quantity),
                            }).OrderByDescending(olg => olg.Quantity).Take(5);
                       return orderDto;
                    }
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }
    }
}
