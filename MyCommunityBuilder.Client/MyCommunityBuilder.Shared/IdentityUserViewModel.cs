using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCommunityBuilder.Shared
{
    public class IdentityUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string ZipCode { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Force2FA { get; set; }
        public bool Was2faEnabledInit { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string SecurityStamp { get; set; }
        public string PasswordHash { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ImagePath { get; set; }
        public string ImageBase64 { get; set; }
        public IList<IdentityRoleViewModel> Roles { get; set; }
    }

    public class UpdateIdentityUserViewModel
    {
        //public string Email { get; set; }
        //public string Password { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }

    public class VerifyTwoFactorTokenReqModel
    { 
        [Required]
        public string TokenCode { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
