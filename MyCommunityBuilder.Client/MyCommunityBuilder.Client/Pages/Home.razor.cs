using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyCommunityBuilder.Shared;
using Syncfusion.Blazor.DropDowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Pages
{
    public partial class Home
    {
        public int SiteID { get; set; } = 0;
        private string SelectedSiteURL { get; set; } = "";

        IEnumerable<SiteDto> Sites = Enumerable.Empty<SiteDto>();


        protected async Task<IEnumerable<SiteDto>> LoadSites()
        {
            try
            {
                Sites = await SiteClient.GetAllSites();
                SiteID = (from cust in Sites
                                   select cust.SiteID).FirstOrDefault();
                //SelectedSiteURL = (from cust in Sites
                //                      select cust.URL).FirstOrDefault();
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return Sites;
        }
        //private void onSelect(ChangeEventArgs<string, SiteDto> args)
        //{
        //    SiteID = Int32.Parse(args.Value.ToString());
        //    SelectedSiteURL = (from cust in Sites
        //                       where cust.SiteID == SiteID
        //                       select cust.URL).FirstOrDefault();
        //    NavigationManager.NavigateTo($"Index/{SiteID}");
        //}
        async void OnSelect(int e)
        {
            //SiteID = Int32.Parse(e.Value.ToString());
            SiteID = Int32.Parse(e.ToString());
            SelectedSiteURL = (from cust in Sites
                               where cust.SiteID == SiteID
                               select cust.URL).FirstOrDefault();
            NavigationManager.NavigateTo($"Index/{SiteID}");
            //await InvokeAsync(() => StateHasChanged())
            //           .ConfigureAwait(false);

        }
    }
}
