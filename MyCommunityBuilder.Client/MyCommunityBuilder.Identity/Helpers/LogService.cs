using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Identity.Helpers
{
    public class LogService
    {
        public static void WriteLogLine(string strComments)
        {
            var fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Logs\\Logs") + "_" + DateTime.Now.ToString("yyyy") + ".txt";
            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                file.WriteLine("WriteLogLine Comments: [" + DateTime.Now.ToString() + "] " + strComments + ".");
                file.Close();
            }
        }
    }
}
