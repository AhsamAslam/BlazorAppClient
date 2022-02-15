using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class LocalizationClient
    {
        private readonly HttpClient httpClient;
        public LocalizationClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // var FlatData = await Http.GetFromJsonAsync<IEnumerable<TreeItem>>("TreeItem?Id=3FD09A3");
        public async Task<IEnumerable<LanguageLocalizationDto>> GetLocalization(int SiteID) =>
            await httpClient.GetFromJsonAsync<IEnumerable<LanguageLocalizationDto>>($"Localization?SiteID={SiteID}");
    }
}
