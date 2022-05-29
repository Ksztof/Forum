using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Models;
using Forum.Core.Models.AppUserModels;
using Forum.Domain;
using Forum.Domain.Models.Error;
using Forum.Domain.Models.Identities;
using Forum.WebApp.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IAppUserService _appUserService;
        private UserManager<WebAppUser> _usrManager;
        private SignInManager<WebAppUser> signInManager;
        private RoleManager<WebAppRole> roleManager;

        public AccountController(IAppUserService appUserService, UserManager<WebAppUser> usrManager, SignInManager<WebAppUser> signInManager, RoleManager<WebAppRole> roleManager)
        {
            _appUserService = appUserService;
            this._usrManager = usrManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }


        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Show", "QuestionController");
            }
            return View();
        }

        [Route("/Account")]
        [HttpPost]
        public IActionResult SignIn(LogInModel logInModel)
        {
            if (!ModelState.IsValid)
            {
                var errorContent = "Some data is missing";
                return RedirectToAction("ShowError", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }

            var result = signInManager.PasswordSignInAsync(logInModel.AccountUserLogin, logInModel.AccountUserPassword, false, false).Result;

            if (!result.Succeeded)
            {
                var errorContent = "Your login or password don't match";
                return RedirectToAction("ShowError", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }
            return RedirectToAction("Show", "Question");
        }

        [HttpGet]
        public IActionResult SignUp()// wyswietlamy formularz 
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(RegisterFM model)
        {
            if (!ModelState.IsValid || model.Password != model.PasswordConfirm)
            {
                var errorContent = "Required data is missing or passwords dont't match to each other!";
                return RedirectToAction("ShowError", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }
            var appUser = model.ContructAppUser();

            var isExist = _appUserService.GetByEmail(model.Email);
            if (isExist != null)
            {
                var errorContent = "The given e-mail is using by another user!";
                return RedirectToAction("ShowError", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }

            var user = _appUserService.Add(appUser);
            if (user == null)
            {
                var errorContent = "User object is missing data";
                return RedirectToAction("ShowError", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }

            WebAppUser webAppUser = new WebAppUser();
            webAppUser.Email = model.Email;
            webAppUser.UserName = model.UserName;
            webAppUser.UserId = user.Id;
            var createResult = _usrManager.CreateAsync(webAppUser, model.Password).Result;

            if (!createResult.Succeeded)
            {
                var errorContent = "User can't be created";
                return RedirectToAction("ShowError", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }
            return RedirectToAction("Index");
        }




        [Authorize]
        [Route("/AppUser/Update/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;
            var userIdFromProfile = _appUserService.GetBy(id).Id;
            if (userIdFromProfile != currentAppUserId)
            {
                var errorContent = "What are you doing here?";
                return RedirectToAction("ShowError", "Account", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }
            return View();
        }

        [Authorize]
        [Route("/AppUser/Update/{id}")]
        [HttpPost]
        public IActionResult Update(int id, FormModelAppUser model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }

            var appUser = _appUserService.GetBy(id);
            var changedAppUserData = model.changeAppUserData(appUser);
            var updatedAppUser = _appUserService.Update(changedAppUserData);

            var webAppUser = _usrManager.Users.Where(u => u.UserId == updatedAppUser.Id).First();
            webAppUser.UserName = updatedAppUser.Username;
            webAppUser.NormalizedUserName = updatedAppUser.Username.ToUpper();

            var updateResult = _usrManager.UpdateAsync(webAppUser);

            var token = _usrManager.GeneratePasswordResetTokenAsync(webAppUser).Result;
            var result = _usrManager.ResetPasswordAsync(webAppUser, token, model.Password);

            return RedirectToAction("Show", "AppUser");
        }

        [Authorize]
        [Route("/AppUser/Delete/{id}/")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;
            var userIdFromProfile = _appUserService.GetBy(id).Id;
            if (userIdFromProfile != currentAppUserId)
            {
                var errorContent = "What are you doing here?";
                return RedirectToAction("ShowError", "Account", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }
            var webAppUser = _usrManager.Users.Where(u => u.UserId == id).First();
            var result = _usrManager.DeleteAsync(webAppUser).Result;
            var appUserForDelete = _appUserService.GetBy(id);
            var deleteAppUser = _appUserService.Delete(appUserForDelete);

            if (result == null)
            {
                var errorContent = "Delete operation was't successful";
                return RedirectToAction("ShowError", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }

            return RedirectToAction("SignOut");
        }


        //TODO: obłsuga linków aktywacyjnych  send register link is confirmed kiedy kliknie wl ink, (email veryfgication)
        //Jeżeli nie ma flagi conf. to nie pozwolić.

        [HttpGet]
        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult ShowError(ErrorFM errorFM)
        {
            return View(errorFM);
        }
    }
}

