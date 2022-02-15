using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class HeaderClient
    {
        private readonly HttpClient httpClient;

        public HeaderClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<SiteHeaders> GetHeader(int SiteID, string SitePage) =>
            await httpClient.GetFromJsonAsync<SiteHeaders>($"Header/BySiteID?SiteID={SiteID}&SitePage={SitePage}");
    }
}
