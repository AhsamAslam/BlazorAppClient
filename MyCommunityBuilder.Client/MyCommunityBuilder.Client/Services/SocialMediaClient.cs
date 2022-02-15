using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class SocialMediaClient
    {
        private readonly HttpClient httpClient;

        public SocialMediaClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<SocialMediaLinks>> GetTimeLine() =>
            await httpClient.GetFromJsonAsync<IEnumerable<SocialMediaLinks>>("socialMediaLinks");
    }
}
