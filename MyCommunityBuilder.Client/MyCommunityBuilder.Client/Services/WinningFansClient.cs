using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class WinningFansClient
    {
        private readonly HttpClient httpClient;
        public WinningFansClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<WinningFans>> GetWinningFans() =>
           await httpClient.GetFromJsonAsync<IEnumerable<WinningFans>>("winningFans");
    }
}
