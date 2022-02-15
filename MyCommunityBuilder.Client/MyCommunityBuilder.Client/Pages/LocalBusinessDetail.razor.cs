using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyCommunityBuilder.Client.Services;
using MyCommunityBuilder.Shared;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Pages
{
    public partial class LocalBusinessDetail
    {
        #region Property
        [Parameter] public string ID { get; set; }
        IEnumerable<BusinessDetailDto> BusinessDetail = Enumerable.Empty<BusinessDetailDto>();
        IEnumerable<BusinessFileDto> BusinessFiles = Enumerable.Empty<BusinessFileDto>();
        IEnumerable<BusinessGridDto> BusinessGrid = Enumerable.Empty<BusinessGridDto>();
        private SfGrid<BusinessGridDto> SfGrid;
        
        //string img = "";
        //List<string> ImgList = new List<string>();
        #endregion

        protected async Task<IEnumerable<BusinessDetailDto>> LoadBusinessesByBusinessID()
        {
            try
            {
                BusinessDetail = await BusinessClient.GetBusinessByBusinessID(int.Parse(ID));
                //BusinessFiles = (from cust in BusinessDetail
                //                 where cust.BusinessID == int.Parse(ID)
                //                 select cust.FileURL).ToList();
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return BusinessDetail;
        }
        protected async Task<IEnumerable<BusinessGridDto>> LoadBusinessesGrid()
        {
            try
            {
                BusinessGrid = await BusinessClient.GetBusinessGrid();


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
