using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class EventClient
    {
        private readonly HttpClient httpClient;

        public EventClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<EventDto>> GetTopEvent() =>
            await httpClient.GetFromJsonAsync<IEnumerable<EventDto>>("Event");
    }
}
