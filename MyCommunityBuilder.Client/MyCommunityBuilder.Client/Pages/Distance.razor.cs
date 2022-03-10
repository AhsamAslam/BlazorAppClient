using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Pages
{
    public partial class Distance
    {
        #region Property
        IEnumerable<BusinessNameDto> BusinessName = Enumerable.Empty<BusinessNameDto>();
        #endregion

        protected async Task<IEnumerable<BusinessNameDto>> LoadBusinessesName()
        {
            try
            {
                //BusinessName = await BusinessClient.GetBusinessName();
                //BusinessFiles = (from cust in BusinessDetail
                //                 where cust.BusinessID == int.Parse(ID)
                //                 select cust.FileURL).ToList();
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return BusinessName;
        }
    }
}
