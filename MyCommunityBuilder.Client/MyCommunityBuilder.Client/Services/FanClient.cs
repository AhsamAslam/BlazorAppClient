using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class FanClient
    {
        private readonly HttpClient httpClient;

        public FanClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<BusinessFans>> GetBusinessFan() =>
            await httpClient.GetFromJsonAsync<IEnumerable<BusinessFans>>("Fan");
    }
}
