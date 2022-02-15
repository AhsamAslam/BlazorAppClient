using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class LocalizationKeyValuesDto
    {
        public int KeyValueID { get; set; }
        public int LocalizationID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public LocalizationDto LocalizationDto { get; set; }
    }
}
