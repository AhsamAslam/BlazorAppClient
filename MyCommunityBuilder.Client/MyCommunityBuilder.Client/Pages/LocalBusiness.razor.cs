using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Pages
{
    public partial class LocalBusiness
    {
        #region Property
        [Parameter] public int SiteID { get; set; }
        protected IEnumerable<LocalBusinessCardDto> BusinessBySite = Enumerable.Empty<LocalBusinessCardDto>();
        protected string SearchText { get; set; }
        #endregion

        protected async Task<IEnumerable<LocalBusinessCardDto>> LoadBusinessesBySiteID()
        {
            try
            {
                BusinessBySite = await BusinessClient.GetBusinessBySiteID(4, "");
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return BusinessBySite;
        }
        private async Task GetAllLocalBusinessCard()
        {
            
            try
            {
                BusinessBySite = await BusinessClient.GetBusinessBySiteID(4, "");
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
        }
        private async Task GetLocalBusinessCardBySearchText2()
        {
            try
            {
                BusinessBySite = await BusinessClient.GetBusinessBySiteID(4, SearchText);
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
        }
        void GetBusinessDetail(int ID)
        {
            NavigationManager.NavigateTo("/Design"+"/"+ID);
        }
        private async Task OnSelectCat(string e)
        {
            try
            {
                BusinessLocalCardDto = BusinessLocalCardDto.Where(x => x.BusinessLocalCardCategory == e).ToList();
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
        }
    }
}
