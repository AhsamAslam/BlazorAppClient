using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Shared
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string ZipCode { get; set; }

        public string Name { get; set; }
        public bool Force2FA { get; set; }
        public bool Was2faEnabledInit { get; set; }
        public  string PhoneNumber { get; set; }
        public  string ConcurrencyStamp { get; set; }
        public  string SecurityStamp { get; set; }
        public  string PasswordHash { get; set; }
        public  string Email { get; set; }
        public  string UserName { get; set; }
        public  string Id { get; set; }
    }
}
