using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class EventDto
    {
        public int EventID { get; set; }
        public string VirtualOrPhysical { get; set; }
        public string VirtualType { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public string TimeZone { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Hyperlink1 { get; set; }
        public string Hyperlink2 { get; set; }
        public string Comment { get; set; }
        public DateTime? DateAdded { get; set; }
        public string AddedByUserID { get; set; }
        public bool Inactive { get; set; }
        public DateTime? DeactivateOn { get; set; }
        public string DeactivatedByUserID { get; set; }
    }
}
