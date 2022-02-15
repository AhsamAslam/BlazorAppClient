using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class LocalizationDto
    {
        public int LocalizationID { get; set; }
        public int LanguageID { get; set; }
        public int SiteID { get; set; }

        public SiteDto SiteDto { get; set; }
        public LanguageDto LanguageDto { get; set; }

        public IAsyncEnumerable<LocalizationKeyValuesDto> LocalizationKeyValuesDto { get; set; }
    }
}
