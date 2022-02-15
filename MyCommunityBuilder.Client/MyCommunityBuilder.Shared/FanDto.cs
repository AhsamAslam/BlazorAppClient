using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class FanDto
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int BusinessID { get; set; }
        public DateTime? Date { get; set; }
        public int ThisWeek { get; set; }

        //Relationship
        public BusinessDto BusinessDto { get; set; }
    }
}
