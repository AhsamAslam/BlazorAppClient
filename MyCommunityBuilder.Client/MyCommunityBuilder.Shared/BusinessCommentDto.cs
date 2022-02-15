using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class BusinessCommentDto
    {
        public int BusinessCommentID { get; set; }
        public int BusinessID { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string UserID { get; set; }
        public DateTime? PublishDate { get; set; }

        //Relationship
        public BusinessDto BusinessDto { get; set; }
    }
}
