using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class BusinessLoans
    {
        public int BusinessLoanId { get; set; }
        public Business Businesses { get; set; }
        public Loans Loans { get; set; }
 

    }
}
