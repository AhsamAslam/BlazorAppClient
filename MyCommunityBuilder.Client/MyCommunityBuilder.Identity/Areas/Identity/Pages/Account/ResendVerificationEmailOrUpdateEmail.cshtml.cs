using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MyCommunityBuilder.Identity.Models;

namespace MyCommunityBuilder.Identity.Areas.Identity.Pages.Account
{
    public class ResendVerificationEmailOrUpdateEmailModel : PageModel
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        public ResendVerificationEmailOrUpdateEmailModel(UserManager<ApplicationUser> userManager,
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

        public string ReturnUrl { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public ApplicationUser User { get; private set; }
        public async Task OnGet(string Email, string returnUrl = null)
        {
            try
            {
                ReturnUrl = returnUrl;
                ViewData["Email"] = Email;
                //User = await _userManager.FindByEmailAsync(Email);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IActionResult> OnPostAsync(string Email, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var User = await _userManager.FindByEmailAsync(Email);
            if (User != null)
            {
                if(Input.Email == null && Input.Email == "")
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(User);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = User.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Email,
                        "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(User, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                else if(Input.Email != null && Input.Email != "")
                {
                    User.Email = Input.Email;
                    var result = await _userManager.UpdateAsync(User);
                    if (result.Succeeded)
                    {
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(User);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = User.Id, code = code, returnUrl = returnUrl },
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
                            await _signInManager.SignInAsync(User, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }
                   
                }
                
            }
            return Page();
        }

    }
}
