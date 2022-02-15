using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class SiteClient
    {
        private readonly HttpClient httpClient;

        public SiteClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<SiteDto>> GetAllSites() =>
            await httpClient.GetFromJsonAsync<IEnumerable<SiteDto>>("Site");

        public async Task<int> GetSiteIDByURL(string SiteURL) =>
            await httpClient.GetFromJsonAsync<int>($"Site/GetSiteID?SiteURL={SiteURL}");

    }
}
