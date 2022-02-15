using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyCommunityBuilder.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Client.Pages
{
    public partial class UserProfile
    {
        #region Property
        [Parameter]
        public string ID { get; set; }
        protected IdentityUserViewModel UserDto = new IdentityUserViewModel();
        public class UserModal
        {
            public string Id { get; set; }
            [Required]
            public string FirstName { get; set; }
            public string LastName { get; set; }
            [Required]
            public string Username { get; set; }
            public string ZipCode { get; set; }
            //[Required]
            //[DataType(DataType.EmailAddress)]
            //[EmailAddress]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.PhoneNumber)]
            [Phone]
            public string PhoneNumber { get; set; }
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
        #endregion

        protected async Task<IdentityUserViewModel> LoadUserID()
        {
            try
            {
                UserDto = await AccountService.GetById(ID);
                User = new UserModal
                {
                    Id = UserDto.Id,
                    Email = UserDto.Email,
                    FirstName = UserDto.FirstName,
                    LastName = UserDto.LastName,
                    Username = UserDto.UserName,
                    PhoneNumber = UserDto.PhoneNumber,
                    ZipCode = User.ZipCode,
                    OldPassword = UserDto.OldPassword,
                    NewPassword = User.NewPassword

                };
                ImagePath = "https://localhost:5001" + UserDto.ImagePath;
                Console.WriteLine(User);
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return UserDto;
        }
        protected async Task<bool> UpdateUser()
        {
            try
            {
                IdentityUserViewModel IUser = new IdentityUserViewModel
                {

                    Id = User.Id,
                    Email = User.Email,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    UserName = User.Username,
                    PhoneNumber = User.PhoneNumber,
                    ZipCode = User.ZipCode,
                    OldPassword = User.OldPassword,
                    NewPassword = User.NewPassword


                };
                
                var AddedUser = await AccountService.UpdateUser(IUser);
                NavigationManager.NavigateTo("/");
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
            }
            return true;
        }
    }
}
