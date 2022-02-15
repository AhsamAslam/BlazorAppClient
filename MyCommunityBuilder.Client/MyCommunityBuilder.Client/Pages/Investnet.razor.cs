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
    public partial class Investnet
    {
        #region Properties
        //public List<CSSStyleDto> CSS;
        IEnumerable<CustomCssDto> Css = Enumerable.Empty<CustomCssDto>();
        #region Card Css

        // Heading Style //
        public string CardHeadingCss;
        public string CardHeadingColor = "red";
        public string CardHeadingFontSize = "16px";
        public string CardHeadingFontWeight = "bold";
        public string CardHeadingFontFamily = "'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif";
        public string CardHeadingTextDecoration = "none";
        // Body Style //
        public string CardBodyCss;
        public string CardBodyTextColor;
        public string CardBodyTextFontSize;
        public string CardBodyTextFontWeight;
        public string CardBodyTextFontFamily;
        public string CardBodyTextDecoration;
        // Button Style //
        public string CardButtonCss;
        public string CardBodyButtonBackGroundColor;
        public string CardBodyButtonTextColor;
        public string CardBodyButtonTextFontSize;
        public string CardBodyButtonTextFontWeight;
        public string CardBodyButtonTextFontFamily;
        public string CardBodyButtonTextDecoration;
        #endregion




        [Parameter] public int SiteID { get; set; }
        private int SelectedLanguage = 0;
        //private int SelectedLanguageId { get; set; } = 0;
        private string mfaName = "[\"mfa\"]";
        private string mfaForceText = "True";
        private Claim amrClaim;
        private Claim force2FAClaim;
        private IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();
        private AuthenticationState authState;
        private string _authMessage;
        private string _surnameMessage;
        public IDictionary<string, string> Localization = new Dictionary<string, string>();
        IEnumerable<LanguageLocalizationDto> LanguageLocalization = Enumerable.Empty<LanguageLocalizationDto>();
        IEnumerable<LanguageDto> Language = Enumerable.Empty<LanguageDto>();
        IEnumerable<GenericLocalizationKeyValuesDto> GenericLocalization = Enumerable.Empty<GenericLocalizationKeyValuesDto>();
        #endregion
        protected async Task<IEnumerable<BusinessDto>> LoadBusinesses()
        {
            IEnumerable<BusinessDto> business = Enumerable.Empty<BusinessDto>();
            try
            {
                business = await BusinessClient.GetTopBusiness();
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return business;
        }
        protected async Task<IEnumerable<BusinessFans>> LoadFans()
        {
            var Fans = Enumerable.Empty<BusinessFans>();
            try
            {
                Fans = await FanClient.GetBusinessFan();
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return Fans;
        }
        protected async Task<IEnumerable<EventDto>> LoadEvents()
        {
            var events = Enumerable.Empty<EventDto>();
            try
            {

                events = await EventClient.GetTopEvent();
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return events;
        }

        protected async Task<IEnumerable<LanguageDto>> LoadLanguage()
        {
            string currentUrl = NavigationManager.BaseUri;

            try
            {
                if (SiteID == 0)
                {
                    SiteID = await SiteClient.GetSiteIDByURL(currentUrl);
                }

                Language = await LanguageClient.GetLanguage(SiteID);
                Console.WriteLine(Language);
                SelectedLanguage = (from cust in Language
                                    where cust.LanguageID == cust.DefaultLanguageID
                                    select cust.LanguageID).FirstOrDefault();


            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return Language;
        }
        async void onSelect(ChangeEventArgs e)
        {
            SelectedLanguage = Int32.Parse(e.Value.ToString());
            //SelectedLanguageId = (from cust in Language
            //                      where cust.LanguageDescription == SelectedLanguage
            //                      select cust.LanguageID).FirstOrDefault();
            await LoadGenericLocalization();
            FillDictionary();
            await InvokeAsync(() => StateHasChanged())
                        .ConfigureAwait(false);
            Console.WriteLine(string.Join(Environment.NewLine, Localization));

        }
        protected async Task<IEnumerable<LanguageLocalizationDto>> LoadLanguageLocalization()
        {
            string currentUrl = NavigationManager.Uri;
            try
            {

                LanguageLocalization = await LocalizationClient.GetLocalization(SiteID);
                Console.WriteLine(LanguageLocalization);
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return LanguageLocalization;
        }
        protected async Task<IEnumerable<GenericLocalizationKeyValuesDto>> LoadGenericLocalization()
        {

            try
            {

                GenericLocalization = await GenericLocalizationClient.GetGenericLocalization(SelectedLanguage);
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return GenericLocalization;
        }
        protected async Task<SiteHeaders> LoadHeader()
        {
            return await HeaderClient.GetHeader(SiteID, "Investnet");
        }
        protected async Task<IEnumerable<CustomCssDto>> LoadCSS()
        {
            try
            {
                Css = await CSSClient.GetCSS("Investnet");

                #region Card 
                var CardTitleCss = (from cust in Css
                                where cust.Tag == "Title"
                                select cust).FirstOrDefault();
                CardHeadingColor = CardTitleCss.TextColor.ToString();
                CardHeadingFontSize = CardTitleCss.FontSize.ToString();
                CardHeadingFontWeight = CardTitleCss.FontWeight.ToString();
                CardHeadingFontFamily = CardTitleCss.FontFamily.ToString();
                CardHeadingTextDecoration = CardTitleCss.TextDecoration.ToString();
                var CardContentCss = (from cust in Css
                                    where cust.Tag == "Content"
                                      select cust).FirstOrDefault();
                CardBodyTextColor = CardContentCss.TextColor.ToString();
                CardBodyTextFontSize = CardContentCss.FontSize.ToString();
                CardBodyTextFontWeight = CardContentCss.FontWeight.ToString();
                CardBodyTextFontFamily = CardContentCss.FontFamily.ToString();
                CardBodyTextDecoration = CardContentCss.TextDecoration.ToString();
                var CardButtonCss = (from cust in Css
                                      where cust.Tag == "Button"
                                      select cust).FirstOrDefault();
                CardBodyButtonTextColor = CardButtonCss.TextColor.ToString();
                CardBodyButtonTextFontSize = CardButtonCss.FontSize.ToString();
                CardBodyButtonTextFontWeight = CardButtonCss.FontWeight.ToString();
                CardBodyButtonTextFontFamily = CardButtonCss.FontFamily.ToString();
                CardBodyButtonTextDecoration = CardButtonCss.TextDecoration.ToString();
                CardBodyButtonBackGroundColor = CardButtonCss.BackGroundColor.ToString();
                #endregion

            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return Css;
        }
        private void FillDictionary()
        {
            Localization.Clear();
            GenericLocalization = (from cust in GenericLocalization
                                   where cust.LanguageId == SelectedLanguage
                                   select cust).ToList();
            foreach (var item in GenericLocalization)
            {
                Localization.Add(item.Key, item.Value);
            }
            LanguageLocalization = (from cust in LanguageLocalization
                                    where cust.LanguageID == SelectedLanguage
                                    select cust).ToList();
            foreach (var item in LanguageLocalization)
            {
                Localization.Add(item.Key, item.Value);
            }


        }

        

    }

}
