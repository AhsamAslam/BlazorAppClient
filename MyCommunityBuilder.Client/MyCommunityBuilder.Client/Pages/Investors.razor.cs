using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Pages
{
    public partial class Investors
    {
        #region Properties


        public SiteHeaders SiteHeader { get; set; }
        #endregion


        protected async Task<SiteHeaders> LoadInvestorHeader()
        {
            try
            {
               //SiteHeader = await HeaderClient.GetHeader(8, "Investor");
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return SiteHeader;
        }
    }
}
