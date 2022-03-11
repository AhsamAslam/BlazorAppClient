using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyCommunityBuilder.Shared;
using MyCommunityBuilder.Shared.BusinessDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public class BusinessModal
        {
            public string Id { get; set; }
            [Required]
            public string Name { get; set; }
            public string Address { get; set; }
            [Required]
            public string Telephone { get; set; }
            public string Email { get; set; }
            public string Comment { get; set; }
        }
        #endregion

        protected async Task<IEnumerable<LocalBusinessCardDto>> LoadBusinessesBySiteID()
        {
            try
            {
                //BusinessBySite = await BusinessClient.GetBusinessBySiteID(4, "");
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
                CurrentBusinessLocalCardDto = new List<BusinessLocalCardDto>();
                foreach (var item in BusinessLocalCardDto)
                {
                    CurrentBusinessLocalCardDto.Add(new BusinessLocalCardDto()
                    {
                        BusinessLocalCardTitle = item.BusinessLocalCardTitle,
                        BusinessLocalCardImage = item.BusinessLocalCardImage,
                        BusinessLocalCardName = item.BusinessLocalCardName,
                        BusinessLocalCardCategory = item.BusinessLocalCardCategory,
                        BusinessLocalCardDescription = item.BusinessLocalCardDescription,
                        BusinessLocalCardLink = item.BusinessLocalCardLink,
                        BusinessLocalCardNewest = item.BusinessLocalCardNewest
                    });
                }

                SortBy = null;
                SearchText = "ALL";
                CategorySelect = "default";
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
                //BusinessBySite = await BusinessClient.GetBusinessBySiteID(4, SearchText);
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

        protected async Task<bool> SaveBusiness()
        {
            try
            {
                AddBusinessDto IBusiness = new AddBusinessDto
                {
                    BusinessId = Convert.ToInt32(businessModel.Id),
                    BusinessName = businessModel.Name,
                    BusinessAddress = businessModel.Address,
                    BusinessEmail = businessModel.Email,
                    BusinessTelephone = businessModel.Telephone,
                    BusinessComment = businessModel.Comment
                };

                await BusinessClient.AddBusiness(IBusiness);
                NavigationManager.NavigateTo("/BusinessList");
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return true;
        }

    }
}
