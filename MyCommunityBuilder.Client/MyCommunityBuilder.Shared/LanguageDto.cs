using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class LanguageDto
    {
        public int LanguageID { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageDescription { get; set; }

        //Custom
        public int DefaultLanguageID { get; set; }

        public ICollection<LocalizationDto> LocalizationDto { get; set; }
    }
}
