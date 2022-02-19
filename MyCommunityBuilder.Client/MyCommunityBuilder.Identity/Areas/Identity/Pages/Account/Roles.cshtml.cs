using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCommunityBuilder.Identity.Helpers;

namespace MyCommunityBuilder.Identity.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RolesModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public List<IdentityRole> Roles = new List<IdentityRole>();
        public RolesModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string RoleId { get; set; } 

            [Required]
            [Display(Name = "Roles")]
            public string RoleName { get; set; }
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var role = _roleManager.Roles;
            foreach (var item in role)
            {
                Roles.Add(item);
            }
            return null;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var role = new IdentityRole { Name = Input.RoleName, NormalizedName = Input.RoleName };
                    var result = await _roleManager.CreateAsync(role);

                    if (result.Succeeded)
                    {

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                // If we got this far, something failed, redisplay form
                return RedirectToPage("Roles");
            }
            catch (Exception ex)
            {
                LogService.WriteLogLine(ex.ToString());
                throw;
            }
            
        }

        public async Task<IActionResult> OnDeleteAsync(string Id)
        {
            try
            {
                var Role = await _roleManager.FindByIdAsync(Id);
                if(Role == null)
                {
                    return Page();
                }
                else
                {
                    var result = await _roleManager.DeleteAsync(Role);
                    return RedirectToPage("Roles");
                }
            }
            catch (Exception ex)
            {
                LogService.WriteLogLine(ex.ToString());
                throw;
            }
        }

    }
}
