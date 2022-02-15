using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using MyCommunityBuilder.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel;

namespace MyCommunityBuilder.Identity.Areas.Identity.Pages.Account
{
    public enum RoleType
    {
        [Description("Business Owner")]
        BusinessRole,
        [Description("Investor")]
        InvestorRole,
        [Description("Customer")]
        Customer
    }
    public static class MyEnumExtensions
    {
        public static string ToDescriptionString(this RoleType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
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

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            public bool BusinessRole { get; set; }
         
            public bool InvestorRole { get; set; }
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }
            [Display(Name = "LastName")]
            public string LastName { get; set; }
            [Display(Name = "UserName")]
            public string UserName { get; set; }
            [Display(Name = "Tpye")]
            public string Type { get; set; }
            [Display(Name = "Phone Number")]

            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }

            [Required]
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {FirstName = Input.FirstName, LastName = Input.LastName, 
                    PhoneNumber = Input.PhoneNumber, Type = "null", UserName = Input.UserName,
                    Email = Input.Email, Name = Input.Name, NormalizedUserName = Input.Name, ZipCode = Input.ZipCode };
                var result = await _userManager.CreateAsync(user, Input.Password);
      
                if (Input.BusinessRole != null && Input.BusinessRole != false)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, RoleType.BusinessRole.ToDescriptionString());
                    var roleResultCustomer = await _userManager.AddToRoleAsync(user, RoleType.Customer.ToDescriptionString());
                }
                if (Input.InvestorRole != null && Input.InvestorRole != false)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, RoleType.InvestorRole.ToDescriptionString());
                    var roleResultCustomer = await _userManager.AddToRoleAsync(user, RoleType.Customer.ToDescriptionString());
                }
                if ((Input.BusinessRole == null || Input.BusinessRole == false) &&
                    (Input.InvestorRole == null || Input.InvestorRole == false))
                {
                    var roleResultCustomer = await _userManager.AddToRoleAsync(user, RoleType.Customer.ToDescriptionString());
                }

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email,
                        "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
