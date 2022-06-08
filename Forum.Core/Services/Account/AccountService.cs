using Forum.Core.Interfaces.Account;
using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Models.AppUserModels;
using Forum.Domain.Models.Account;
using Forum.Domain.Models.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Services.Account
{
    public class AccountService : IAccountService
    {
        private UserManager<WebAppUser> _usrManager;
        private IAppUserService _appUserService;
        private RoleManager<WebAppRole> roleManager;

        public AccountService(UserManager<WebAppUser> usrManger, IAppUserService appUserService, RoleManager<WebAppRole> roleManager)
        {
            this._usrManager = usrManger;
            this._appUserService = appUserService;
            this.roleManager = roleManager;     
        }

        public IdentityResult Add(RegisterFM model, Domain.Models.AppUser appUser)
        {
            WebAppUser webAppUser = new WebAppUser();
            webAppUser.Email = model.Email;
            webAppUser.UserName = model.UserName;
            webAppUser.UserId = appUser.Id;

            

            var createResult = _usrManager.CreateAsync(webAppUser, model.Password).Result;

            var addToRole = _usrManager.AddToRoleAsync(webAppUser, "Admin").Result;

            return createResult;
        }


        public bool Delete(int id)
        {
            var webAppUser = _usrManager.Users.Where(u => u.UserId == id).First();
            var result = _usrManager.DeleteAsync(webAppUser).Result;
            var appUserForDelete = _appUserService.GetBy(id);
            var deleteAppUser = _appUserService.Delete(appUserForDelete);
            if (result == IdentityResult.Success)
            {
                return true;
            }
            return false;
        }

        public bool Check(ClaimsPrincipal user, int id)
        {
            var applicationUser = _usrManager.GetUserAsync(user).Result;
            var currentAppUserId = applicationUser.UserId;
            var userIdFromProfile = _appUserService.GetBy(id).Id;
            if (userIdFromProfile == currentAppUserId)
            {
                return true;
            }
            return false;
        }
        //TODO: prevent default JS 

        public void Update(FormModelAppUser model, int id)
        {
            var appUser = _appUserService.GetBy(id);
            var changedAppUserData = model.changeAppUserData(appUser);
            var updatedAppUser = _appUserService.Update(changedAppUserData);

            var webAppUser = _usrManager.Users.Where(u => u.UserId == updatedAppUser.Id).First();
            webAppUser.UserName = updatedAppUser.Username;
            webAppUser.NormalizedUserName = updatedAppUser.Username.ToUpper();

            var updateResult = _usrManager.UpdateAsync(webAppUser);
            var token = _usrManager.GeneratePasswordResetTokenAsync(webAppUser).Result;
            var result = _usrManager.ResetPasswordAsync(webAppUser, token, model.Password);
        }


    }
}
