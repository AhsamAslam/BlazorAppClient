using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class TimeLineClient
    {
        private readonly HttpClient httpClient;

        public TimeLineClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<EventDto>> GetTimeLine() =>
            await httpClient.GetFromJsonAsync<IEnumerable<EventDto>>("timeLine");
    }
}
