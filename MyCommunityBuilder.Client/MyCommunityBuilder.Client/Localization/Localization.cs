using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using MyCommunityBuilder.Client.Services;
//using MyCommunityBuilder.Client.Services;
using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Localization
{
    public class Localization : ComponentBase, ILocalization
    {
        #region Properties
        [Parameter] public int SiteID { get; set; }
        public int SelectedLanguage = 0;
        public IDictionary<string, string> LocalizationData = new Dictionary<string, string>();
        public IEnumerable<LanguageLocalizationDto> LanguageLocalization = Enumerable.Empty<LanguageLocalizationDto>();
        public IEnumerable<LanguageDto> Language = Enumerable.Empty<LanguageDto>();
        IEnumerable<GenericLocalizationKeyValuesDto> GenericLocalization = Enumerable.Empty<GenericLocalizationKeyValuesDto>();
        //public event Action OnChange;
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public SiteClient SiteClient { get; set; }
        [Inject]
        public  LanguageClient LanguageClient { get; set; }
        [Inject]
        public  GenericLocalizationClient GenericLocalizationClient { get; set; }
        [Inject]
        public ILogger<Index> _logger { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        #endregion
        #region Culture Coding 
        public CultureInfo[] cultures = new[]
        {
            new CultureInfo("EN-US"),
            new CultureInfo("ES-MX")
        };
        public CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    var Js = (IJSRuntime)JSRuntime;
                    Js.InvokeVoidAsync("blazorCulture.set", value.Name);
                    NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
                }
            }
        }
        #endregion
        public async void onSelect(ChangeEventArgs e)
        {
            SelectedLanguage = Int32.Parse(e.Value.ToString());
            //SelectedLanguageId = (from cust in Language
            //                      where cust.LanguageDescription == SelectedLanguage
            //                      select cust.LanguageID).FirstOrDefault();
            await LoadGenericLocalization();
            LocalizationData = FillDictionary();
            await InvokeAsync(() => StateHasChanged())
                        .ConfigureAwait(false);
            Console.WriteLine(string.Join(Environment.NewLine, LocalizationData));

        }
        public async Task<IEnumerable<LanguageDto>> LoadLanguage()
        {
            try
            {
                var currentUrl = NavigationManager.BaseUri;
                if (SiteID == 0)
                {
                    SiteID = await SiteClient.GetSiteIDByURL(currentUrl);
                }
                Console.WriteLine("SiteId there:", SiteID);

                Language = await LanguageClient.GetLanguage(SiteID);
                foreach (var item in Language)
                {
                    _logger.LogInformation(string.Join(Environment.NewLine, item.LanguageDescription));
                }
               
                Console.WriteLine(Language);
                SelectedLanguage = (from cust in Language
                                    where cust.LanguageID == cust.DefaultLanguageID
                                    select cust.LanguageID).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
            return Language;
        }

        public async Task<IEnumerable<GenericLocalizationKeyValuesDto>> LoadGenericLocalization()
        {
            try
            {

                GenericLocalization = await GenericLocalizationClient.GetGenericLocalization(SelectedLanguage);
            }
            catch (Exception ex)
            {
                throw;
            }
            return GenericLocalization;
        }

        public Task<IEnumerable<LanguageLocalizationDto>> LoadLanguageLocalization()
        {
            throw new NotImplementedException();
        }
        public IDictionary<string, string> FillDictionary()
        {
            try
            {
                LocalizationData.Clear();
                GenericLocalization = (from cust in GenericLocalization
                                       where cust.LanguageId == SelectedLanguage
                                       select cust).ToList();
                foreach (var item in GenericLocalization)
                {
                    LocalizationData.Add(item.Key, item.Value);
                }
                LanguageLocalization = (from cust in LanguageLocalization
                                        where cust.LanguageID == SelectedLanguage
                                        select cust).ToList();
                foreach (var item in LanguageLocalization)
                {
                    LocalizationData.Add(item.Key, item.Value);
                }

                return LocalizationData;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
