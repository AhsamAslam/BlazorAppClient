
using MyCommunityBuilder.Shared.BusinessDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{
    public class BusinessClient
    {
        private readonly HttpClient httpClient;
        private readonly HttpService _httpService;
        public BusinessClient(HttpClient httpClient, HttpService httpService)
        {
            this.httpClient = httpClient;
            _httpService = httpService;
        }

        //public async Task<IEnumerable<BusinessDto>> GetTopBusiness() =>
        //    await httpClient.GetFromJsonAsync<IEnumerable<BusinessDto>>("Business");
        //public async Task<IEnumerable<LocalBusinessCardDto>> GetBusinessBySiteID(int SiteID, string SearchText) =>
        //    await httpClient.GetFromJsonAsync<IEnumerable<LocalBusinessCardDto>>($"Business/BySite?SiteID={SiteID}&SearchText={SearchText}");
        //public async Task<IEnumerable<BusinessDetailDto>> GetBusinessByBusinessID(int BusinessID) =>
        //   await httpClient.GetFromJsonAsync<IEnumerable<BusinessDetailDto>>($"Business/ByBusinessID?BusinessID={BusinessID}");
        public async Task<IEnumerable<BusinessGridDto>> GetBusinessGrid() =>
            await httpClient.GetFromJsonAsync<IEnumerable<BusinessGridDto>>("Business/BusinessGrid");
        public async Task<HttpResponseMessage> AddBusiness(AddBusinessDto business) =>
           await httpClient.PostAsJsonAsync<AddBusinessDto>($"Business/AddBusiness", business);

        //public async Task<IEnumerable<BusinessNameDto>> GetBusinessName() =>
        //    await httpClient.GetFromJsonAsync<IEnumerable<BusinessNameDto>>("Business/BusinessName");
    }
}
