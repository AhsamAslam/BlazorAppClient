using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class SiteHeaders
    {
        public int SiteHeaderID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int SiteID { get; set; }
        public int SitePageID { get; set; }


        ////Relationship
        //public SiteDto SiteDto { get; set; }
        //public SitePageDto SitePageDto { get; set; }
    }
}
