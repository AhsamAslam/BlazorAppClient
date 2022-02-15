using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Shared
{
    public partial class NavMenuBar
    {
        public int SiteID { get; set; }
        public string currentUrl { get; set; }
        protected async Task GetSitesID()
        {
            try
            {
                SiteID = await SiteClient.GetSiteIDByURL("https://localhost:5001/");
                Console.WriteLine("GetSitesID there", SiteID);
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
        }
    }
}
