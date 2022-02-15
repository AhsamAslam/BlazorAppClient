using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Identity.Models
{
    // This is where we add custom properties to a user in Identity.
    // Then run these two commands in this order.
    // PM> Add-Migration "Purpose of Migration"
    // PM> Update-Databasev
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(250)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(250)")]
        public string LastName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ZipCode { get; set; }

        public string Name { get; set; }
        public bool Force2FA { get; set; }
        public bool Was2faEnabledInit { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ImagePath { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ImageBase64 { get; set; }
    }
}
