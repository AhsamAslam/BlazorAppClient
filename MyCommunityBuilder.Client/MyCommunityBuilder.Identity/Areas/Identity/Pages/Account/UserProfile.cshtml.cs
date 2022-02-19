using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyCommunityBuilder.Identity.Helpers;
using MyCommunityBuilder.Identity.Models;

namespace MyCommunityBuilder.Identity.Areas.Identity.Pages.Account
{
    public class UserProfileModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        public UserProfileModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
             IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public class InputModel
        {
            public string Id { get; set; }
            public string ConcurrencyStamp { get; set; }
            public string SecurityStamp { get; set; }
            public string PasswordHash { get; set; }
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }
            [Display(Name = "LastName")]
            public string LastName { get; set; }
            [Display(Name = "UserName")]
            public string UserName { get; set; }
            [Display(Name = "Phone Number")]

            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            [Required]
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Old Password")]
            public string OldPassword { get; set; }

            [Required]
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "NewPassword")]
            public string NewPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public ApplicationUser User { get; private set; }

        public async Task OnGet(string ID, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            try
            {
                ReturnUrl = returnUrl;
                User = await _userManager.FindByIdAsync(ID);
                #region Bind
                //InputModel Input = new InputModel();
                Input = new InputModel
                {
                    Id = User.Id,
                    ConcurrencyStamp = User.ConcurrencyStamp,
                    SecurityStamp = User.SecurityStamp,
                    PasswordHash = User.PasswordHash,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    PhoneNumber = User.PhoneNumber,
                    ZipCode = User.ZipCode,
                    UserName = User.UserName,
                    Email = User.Email,
                };

                #endregion
            }
            catch (Exception ex)
            {
                LogService.WriteLogLine(ex.ToString());
                throw;
            }

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            try
            {
                var User = await _userManager.FindByEmailAsync(Input.Email);

                User.FirstName = Input.FirstName;
                User.LastName = Input.LastName;
                User.PhoneNumber = Input.PhoneNumber;
                User.UserName = Input.UserName;
                User.ZipCode = Input.ZipCode;


                if (ModelState.IsValid)
                {

                    var updateOtherRecord = await _userManager.UpdateAsync(User);
                    //var ifExist =


                    if (updateOtherRecord.Succeeded)
                    {
                        var getCurrentUser = await _userManager.FindByEmailAsync(Input.Email);
                        var changePasswordResult = await _userManager.ChangePasswordAsync(getCurrentUser, Input.OldPassword, Input.NewPassword);

                        if (changePasswordResult.Succeeded)
                        {

                            return LocalRedirect("/");
                        }

                    }
                    foreach (var error in updateOtherRecord.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                // If we got this far, something failed, redisplay form
                return Page();
            }
            catch (Exception ex)
            {
                LogService.WriteLogLine(ex.ToString());
                throw;
            }
            
        }

    }
}
