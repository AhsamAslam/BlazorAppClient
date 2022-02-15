using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class SiteDto
    {
        public int SiteID { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Comments { get; set; }
        public bool IsMasterSite { get; set; }
        public int? ParentID { get; set; }
        public int DefaultLanguageID { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedByUserID { get; set; }
        public string LogoPath { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string YoutubeURL { get; set; }
        public string InstagramURL { get; set; }



        //Relationship
        public IAsyncEnumerable<SiteHeaders> SiteHeaderDto { get; set; }
        public IAsyncEnumerable<BusinessDto> BusinessDto { get; set; }

        public ICollection<LocalizationDto> LocalizationDto { get; set; }
    }
}
