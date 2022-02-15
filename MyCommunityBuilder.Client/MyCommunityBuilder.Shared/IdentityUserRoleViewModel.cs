using System.Collections.Generic;

namespace MyCommunityBuilder.Shared
{
    public class IdentityUserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class AddUserRoleReqModel
    {
        public string UserId { get; set; }
        public string  Role { get; set; }
        public bool IsRemoved { get; set; }
    }

    public class UpdateUser2FAModelReqModel
    {
        public string UserId { get; set; }
        public bool TwoFA { get; set; }
    }
}
