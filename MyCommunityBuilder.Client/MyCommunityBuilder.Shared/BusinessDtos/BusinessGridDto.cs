using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared.BusinessDtos
{
    public class BusinessGridDto
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessTelephone { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessComment { get; set; }
    }
}
