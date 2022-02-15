using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Localization
{
    public interface ILocalization
    {
        public Task<IEnumerable<LanguageDto>> LoadLanguage();
        public Task<IEnumerable<LanguageLocalizationDto>> LoadLanguageLocalization();
        public Task<IEnumerable<GenericLocalizationKeyValuesDto>> LoadGenericLocalization();
        public IDictionary<string, string> FillDictionary();
    }
}
