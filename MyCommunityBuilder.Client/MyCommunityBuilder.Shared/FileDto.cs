using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class FileDto
    {
        public string FileID { get; set; }
        public string FileOriginalName { get; set; }
        public string FileExtension { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public float FileSize { get; set; }
    }
}
