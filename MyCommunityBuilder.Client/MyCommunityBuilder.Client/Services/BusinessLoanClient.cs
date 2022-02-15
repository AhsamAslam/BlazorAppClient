using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class BusinessLoanClient
    {
        private readonly HttpClient httpClient;

        public BusinessLoanClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<BusinessLoans>> GetBusinessLoans() =>
            await httpClient.GetFromJsonAsync<IEnumerable<BusinessLoans>>("businessLoans");
    }
}
