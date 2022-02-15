using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class CSSClient
    {
        private readonly HttpClient httpClient;

        public CSSClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<CustomCssDto>> GetCSS(string SitePage) =>
            await httpClient.GetFromJsonAsync<IEnumerable<CustomCssDto>>($"CSSStyle?SitePage={SitePage}");
        //public async Task<CSSDto> AddCSS(CSSDto css)
        //{
        //    return await httpClient.PostAsJsonAsync("CSSStyle", css);
        //}
    }
}
