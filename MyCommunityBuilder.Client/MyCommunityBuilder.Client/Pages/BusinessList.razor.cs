using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyCommunityBuilder.Shared.BusinessDtos;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Pages
{
    public partial class BusinessList
    {
        #region Property
        [Parameter] public string ID { get; set; }
        IEnumerable<BusinessGridDto> BusinessGrid = Enumerable.Empty<BusinessGridDto>();
        private SfGrid<BusinessGridDto> SfGrid;

        //string img = "";
        //List<string> ImgList = new List<string>();
        #endregion
        protected async Task<IEnumerable<BusinessGridDto>> LoadBusinessesGrid()
        {
            try
            {
                BusinessGrid = (await BusinessClient.GetBusinessGrid()).ToList();



            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return BusinessGrid;
        }
        public async Task PdfExport()
        {
            await this.SfGrid.PdfExport();
        }
        public async Task ExcelExport()
        {
            await this.SfGrid.ExcelExport();
        }
    }
}
