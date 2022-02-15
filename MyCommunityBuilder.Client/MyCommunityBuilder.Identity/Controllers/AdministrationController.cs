using MyCommunityBuilder.Identity.Models;
using MyCommunityBuilder.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdministrationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdministrationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("Users")]
        public async Task<ActionResult> GetUsersAsync()
        {
            IList<IdentityUserViewModel> identityUserViews = new List<IdentityUserViewModel>();
            IdentityUserViewModel identityUserView;
            var users = await _userManager.Users.ToListAsync();
            var allRoles = await _roleManager.Roles.ToListAsync();

            foreach (var user in users)
            {
                identityUserView = new IdentityUserViewModel();
                identityUserView.Email = user.Email;
                identityUserView.EmailConfirmed = user.EmailConfirmed;
                identityUserView.Id = user.Id;
                identityUserView.Name = user.Name;
                identityUserView.TwoFactorEnabled = user.TwoFactorEnabled;
                identityUserView.UserName = user.UserName;
                identityUserView.Force2FA = user.Force2FA;

                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Count > 0)
                {
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

                identityUserViews.Add(identityUserView);
            }
            return Ok(identityUserViews);
        }

        [HttpGet("Users/{Id}")]
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

        [HttpGet("Roles")]
        public async Task<ActionResult> GetRolesAsync()
        {
            return Ok(await _roleManager.Roles.ToListAsync());
        }

        [HttpPost("Roles")]
        public async Task<ActionResult> GetRolesAsync(CreateIdentityRoleViewModel model)
        {
            return Ok(await _roleManager.CreateAsync(new IdentityRole
            {
                Name = model.Role,
                NormalizedName = model.Role
            }));
        }

        [HttpPost("users/role")]
        public async Task<ActionResult> AddUserRole(AddUserRoleReqModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            bool isInRool = await _userManager.IsInRoleAsync(user, model.Role);
            if (!isInRool && !model.IsRemoved)
                await _userManager.AddToRoleAsync(user, model.Role);
            else if (isInRool && model.IsRemoved)
                await _userManager.RemoveFromRoleAsync(user, model.Role);
            return Ok(true);
        }

        [HttpPost("users/update")]
        public async Task<ActionResult> UpdateUser2FA(UpdateUser2FAModelReqModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user.Force2FA != model.TwoFA)
            {
                user.Force2FA = model.TwoFA;
                await _userManager.UpdateAsync(user);
            }

            return Ok(true);
        }
    }
}
