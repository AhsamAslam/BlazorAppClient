using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class BusinessFileDto
    {
        public int FileID { get; set; }
        public int BusinessID { get; set; }
        public string FileURL { get; set; }
        public string IconURL { get; set; }
        public int? SortIndex { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime? Stamp { get; set; }

        //Relationship
        public BusinessDto BusinessDto { get; set; }
    }
}
