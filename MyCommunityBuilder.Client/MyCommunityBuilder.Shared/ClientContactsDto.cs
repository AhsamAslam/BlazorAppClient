using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class ClientContactsDto
    {
        public int ContactID { get; set; }
        public int ClientID { get; set; }
        public DateTime? DateAdded { get; set; }
        public string AddedByUserID { get; set; }
    }
}
