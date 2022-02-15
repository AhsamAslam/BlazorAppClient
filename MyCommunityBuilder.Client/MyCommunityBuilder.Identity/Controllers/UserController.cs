using MyCommunityBuilder.Identity.Models;
using MyCommunityBuilder.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;

namespace MyCommunityBuilder.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment env;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IHostingEnvironment env)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.env = env;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetUserByIdAsync(string Id)
        {
            var user = await _userManager.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
            IdentityUserViewModel identityUserView = new IdentityUserViewModel();
            if (user != null)
            {
                var allRoles = await _roleManager.Roles.ToListAsync();

                identityUserView.Email = user.Email;
                identityUserView.EmailConfirmed = user.EmailConfirmed;
                identityUserView.Id = user.Id;
                identityUserView.Name = user.Name;
                identityUserView.TwoFactorEnabled = user.TwoFactorEnabled;
                identityUserView.UserName = user.UserName;
                identityUserView.Force2FA = user.Force2FA;
                identityUserView.Was2faEnabledInit = user.Was2faEnabledInit;
                identityUserView.Email = user.Email;
                identityUserView.FirstName = user.FirstName;
                identityUserView.LastName = user.LastName;
                identityUserView.PhoneNumber = user.PhoneNumber;
                identityUserView.ConcurrencyStamp = user.ConcurrencyStamp;
                identityUserView.SecurityStamp = user.SecurityStamp;
                identityUserView.ImagePath = user.ImagePath;
                identityUserView.ImageBase64 = user.ImageBase64;
                
                //string[] PathList = identityUserView.ImagePath.Split("/");
                //string FileName = PathList[3].ToString();
            //foreach (string author in PathList)
            //string FilePath = "\\" + PathList[1] + "\\" + PathList[2];
            
            //var FileSavePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload", FileName);
                //string imgBase64String = GetBase64StringForImage(@"D:\Ahsam Projects\BlazorApp\MyCommunityBuilder.Client\MyCommunityBuilder.Identity\Upload\lcnm2.PNG");
                //identityUserView.ImageBase64 = ImageToBase64(identityUserView.ImagePath);
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Count > 0)
                    identityUserView.Roles = (from r in roles
                                              join ar in allRoles
                                              on r equals ar.Name
                                              select new IdentityRoleViewModel
                                              {
                                                  Name = ar.Name,
                                                  Id = ar.Id,
                                                  NormalizedName = ar.NormalizedName
                                              }).ToList();
            }

            return Ok(identityUserView);
        }


        [HttpPost("update")]
        public async Task<ActionResult> UpdateUser(IdentityUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (!string.IsNullOrEmpty(model.Name))
            {
                user.Name = model.Name;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.ZipCode = model.ZipCode;
            user.PhoneNumber = model.PhoneNumber;
            await _userManager.UpdateAsync(user);
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            return Ok(true);
        }

        [HttpPost("upload")]
        public async Task<ActionResult> UploadPhoto([FromForm] IFormFile Image)
        {
            try
            {
                if (Image == null || Image.Length == 0) return BadRequest("Upload any Image");
                var Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (Id == null) return BadRequest("Please login to change your profile image");
                var ImageBase64 = "";
                var GetUser = await _userManager.FindByIdAsync(Id);
                if(GetUser != null)
                {
                    string FileOriginalName = System.IO.Path.GetFileName(Image.FileName);
                    string FileExtension = System.IO.Path.GetExtension(Image.FileName);
                    string FileType = Image.ContentType;
                    float size = Image.Length;
                    string FileSize = (size / 1024).ToString();
                    var PathBuild = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload");
                    if (!Directory.Exists(PathBuild))
                    { 
                            Directory.CreateDirectory(PathBuild);  
                    }
                    var FileSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload", Image.FileName);
                    using (var stream = new FileStream(FileSavePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                        using (var ms = new MemoryStream())
                        {
                            var format = "image/*";
                            Image.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            ImageBase64 = $"data:{format};base64,{Convert.ToBase64String(fileBytes)}";
                        }
                    }
                    string FilePath = "/Upload/" + Image.FileName;
                    GetUser.ImagePath = FilePath;
                    GetUser.ImageBase64 = ImageBase64;


                    await _userManager.UpdateAsync(GetUser);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return null;
        }

        //[HttpPost("VerifyTwoFactorToken")]
        //public async Task<ActionResult> VerifyTwoFactorTokenAsync(VerifyTwoFactorTokenReqModel model)
        //{
        //    var user = await _userManager.FindByIdAsync(model.UserId);

        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    // Strip spaces and hypens
        //    var verificationCode = model.TokenCode.Replace(" ", string.Empty).Replace("-", string.Empty);

        //    var is2faTokenValid = await _userManager.VerifyTwoFactorTokenAsync(
        //       user, _userManager.Options.Tokens.AuthenticatorTokenProvider, verificationCode);

        //    if (!is2faTokenValid)
        //    {
        //        ModelState.AddModelError("tokenCode", "Verification code is invalid.");
        //        return Ok(new VerifyTwoFactorTokenReqModel());
        //    }

        //    await _userManager.SetTwoFactorEnabledAsync(user, true);
        //    return Ok(model);
        //}

        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
