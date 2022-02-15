using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Shared
{
    public partial class LocalizationDropDown
    {
        #region Properties
        [Parameter] public int SiteID { get; set; }
        private int SelectedLanguage = 0;
        public static IDictionary<string, string> Localization = new Dictionary<string, string>();
        IEnumerable<LanguageLocalizationDto> LanguageLocalization = Enumerable.Empty<LanguageLocalizationDto>();
        IEnumerable<LanguageDto> Language = Enumerable.Empty<LanguageDto>();
        IEnumerable<GenericLocalizationKeyValuesDto> GenericLocalization = Enumerable.Empty<GenericLocalizationKeyValuesDto>();
        public event Action OnChange;
        #endregion

        protected async Task<IEnumerable<LanguageDto>> LoadLanguage()
        {
            StateHasChanged();

            try
            {
                if (SiteID == 0)
                {
                    SiteID = await SiteClient.GetSiteIDByURL(currentUrl);
                }
                Console.WriteLine("SiteId there:", SiteID);

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
            Localization = FillDictionary();
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
            StateHasChanged();
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

        private IDictionary<string, string> FillDictionary()
        {
            StateHasChanged();
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

            return Localization;
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
