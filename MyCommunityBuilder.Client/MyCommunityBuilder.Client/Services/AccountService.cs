using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Services
{

    public class AccountService
    {
        HttpService _httpService;

        public AccountService(
           HttpService httpService
        )
        {
            _httpService = httpService;
        }

        public async Task<IList<IdentityUserViewModel>> GetUsers()
        {
            return await _httpService.Get<IList<IdentityUserViewModel>>("/api/administration/users");
        }

        public async Task<IList<IdentityRoleViewModel>> GetRoles()
        {
            return await _httpService.Get<IList<IdentityRoleViewModel>>("/api/administration/Roles");
        }

        public async Task<IdentityUserViewModel> GetById(string id)
        {
            return await _httpService.Get<IdentityUserViewModel>($"/api/user/{id}");
        }

        public async Task CreateRole(CreateIdentityRoleViewModel model)
        {
            await _httpService.Post("/api/administration/roles", model);
        }

        public async Task<bool> AddUpdateRole(AddUserRoleReqModel model)
        {
          return await _httpService.Post<bool>("/api/administration/users/role", model);
        }

        public async Task<bool> UpdateUser2FA(UpdateUser2FAModelReqModel model)
        {
            return await _httpService.Post<bool>("/api/administration/users/update", model);
        }

        public async Task<bool> UpdateUser(IdentityUserViewModel model)
        {
            return await _httpService.Post<bool>("/api/user/update", model);
        }

        public async Task<VerifyTwoFactorTokenReqModel> VerifyTwoFactorToken(VerifyTwoFactorTokenReqModel model)
        {
            return await _httpService.Post<VerifyTwoFactorTokenReqModel>("/api/user/VerifyTwoFactorToken", model);
        }
    }
}
