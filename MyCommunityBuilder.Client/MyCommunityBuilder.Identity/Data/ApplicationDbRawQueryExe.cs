using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MyCommunityBuilder.Identity.Data
{
    public class ApplicationDbRawQueryExe
    {
        public static void ExecuteInitRaw(ApplicationDbContext context)
        {
            if (context.Users.Any(x => x.TwoFactorEnabled == true && x.Was2faEnabledInit == false))
            {
                context.Users.Where(x => x.TwoFactorEnabled == true && x.Was2faEnabledInit == false).ToList().ForEach(x =>
                {
                    x.Was2faEnabledInit = true;
                    context.Users.Update(x);
                });

                context.SaveChanges();
            }
        }
    }
}
