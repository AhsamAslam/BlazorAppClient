using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class LanguageClient
    {
        private readonly HttpClient httpClient;

        public LanguageClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

       // var FlatData = await Http.GetFromJsonAsync<IEnumerable<TreeItem>>("TreeItem?Id=3FD09A3");
        public async Task<IEnumerable<LanguageDto>> GetLanguage(int SiteID) =>
            await httpClient.GetFromJsonAsync<IEnumerable<LanguageDto>>($"Language?SiteID={SiteID}");
    }
}
