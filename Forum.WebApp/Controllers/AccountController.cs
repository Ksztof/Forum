using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Models;
using Forum.Domain;
using Forum.Domain.Models.Error;
using Forum.Domain.Models.Identities;
using Forum.WebApp.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IAppUserService _appUserService;
        private UserManager<WebAppUser> usrManager;
        private SignInManager<WebAppUser> signInManager;
        private RoleManager<WebAppRole> roleManager;

        public AccountController(IAppUserService appUserService, UserManager<WebAppUser> usrManager, SignInManager<WebAppUser> signInManager, RoleManager<WebAppRole> roleManager)
        {
            _appUserService = appUserService;
            this.usrManager = usrManager;
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
            var createResult = usrManager.CreateAsync(webAppUser, model.Password).Result;
            /*if (createResult.Errors.Any(x => x.Code == "PasswordTooShort"))//zmienić to i dOSTOSOWAĆ PATERNY
            {
                var errorContent = "Password format is wrong";
                return RedirectToAction("ShowError", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }*/
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

