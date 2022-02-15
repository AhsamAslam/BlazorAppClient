using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class SubCommentDto
    {
        public int SubCommentID { get; set; }
        public int CommentID { get; set; }
        public string UserID { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Comment { get; set; }
    }
}
