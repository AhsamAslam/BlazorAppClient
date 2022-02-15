using Microsoft.AspNetCore.Components;
using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Components
{
    public partial class JLocalizationDropDown
    {
        #region Properties
        [Parameter] public int SiteID { get; set; }
        private int SelectedLanguage = 0;
        //private int SelectedLanguageId { get; set; } = 0;
        public static IDictionary<string, string> Localization = new Dictionary<string, string>();
        IEnumerable<LanguageLocalizationDto> LanguageLocalization = Enumerable.Empty<LanguageLocalizationDto>();
        IEnumerable<LanguageDto> Language = Enumerable.Empty<LanguageDto>();
        IEnumerable<GenericLocalizationKeyValuesDto> GenericLocalization = Enumerable.Empty<GenericLocalizationKeyValuesDto>();
        HttpClient Http = new HttpClient();
        //public event Action OnChange;
        #endregion

        protected async Task<IEnumerable<LanguageDto>> LoadLanguage()
        {
            string currentUrl = NavigationManager.Uri;
            try
            {
                if (SiteID == 0)
                {
                    SiteID = await Http.GetFromJsonAsync<int>("http://localhost:5002/api/Site/GetSiteID?SiteURL=" + currentUrl);
                }

                Language = await Http.GetFromJsonAsync<IEnumerable<LanguageDto>>("http://localhost:5002/api/Localization/Language?SiteID="+SiteID);
                Console.WriteLine(Language);
                SelectedLanguage = (from cust in Language
                                    where cust.LanguageID == cust.DefaultLanguageID
                                    select cust.LanguageID).FirstOrDefault();


            }
            catch (Exception ex)
            {
                
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

                LanguageLocalization = await Http.GetFromJsonAsync<IEnumerable<LanguageLocalizationDto>>("http://localhost:5002/api/Localization?SiteID="+SiteID);
                Console.WriteLine(LanguageLocalization);
            }
            catch (Exception ex)
            {
               
            }
            return LanguageLocalization;
        }
        protected async Task<IEnumerable<GenericLocalizationKeyValuesDto>> LoadGenericLocalization()
        {

            try
            {

                GenericLocalization = await Http.GetFromJsonAsync<IEnumerable<GenericLocalizationKeyValuesDto>>("http://localhost:5002/api/Localization/Generic?LanguageId="+SelectedLanguage);
            }
            catch (Exception ex)
            {
               
            }
            return GenericLocalization;
        }

        private IDictionary<string, string> FillDictionary()
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

            return Localization;
        }
    }
}
