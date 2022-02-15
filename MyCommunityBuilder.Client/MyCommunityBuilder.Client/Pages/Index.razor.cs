using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using MyCommunityBuilder.Client.Services;
using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Pages
{
    public partial class Index
    {
        //public int SiteID { get; set; } = 0;
        //private string SelectedSiteURL { get; set; } = "";
        
        //IEnumerable<SiteDto> Sites = Enumerable.Empty<SiteDto>();


        //protected async Task<IEnumerable<SiteDto>> LoadSites()
        //{
        //    try
        //    {
        //        Sites = await SiteClient.GetAllSites();
        //        //SiteID = (from cust in Sites
        //        //                    select cust.SiteID).FirstOrDefault();
        //        //SelectedSiteURL = (from cust in Sites
        //        //                      select cust.URL).FirstOrDefault();
        //    }
        //    catch (AccessTokenNotAvailableException ex)
        //    {
        //        ex.Redirect();
        //    }
        //    return Sites;
        //}
        //async void onSelect(ChangeEventArgs e)
        //{
        //    SiteID = Int32.Parse(e.Value.ToString());
        //    SelectedSiteURL = (from cust in Sites
        //                       where cust.SiteID == SiteID
        //                      select cust.URL).FirstOrDefault();
        //    //NavigationManager.NavigateTo(SelectedSiteURL);
        //    //await jsRuntime.InvokeAsync<object>("open", SelectedSiteURL, "_blank");

        //    await InvokeAsync(() => StateHasChanged())
        //               .ConfigureAwait(false);

        //}

    }

}
