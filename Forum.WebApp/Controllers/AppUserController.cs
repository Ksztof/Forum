using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Models.AppUserModels;
using Forum.Domain;
using Forum.Domain.Models.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Forum.WebApp.Controllers
{
    public class AppUserController : Controller
    {
        private readonly ILogger<AppUserController> _logger;
        private IAppUserService _appUserService;
        private IUserProfileService _profileService;
        private UserManager<WebAppUser> _usrManager;

        public AppUserController(ILogger<AppUserController> logger, IAppUserService userService, IUserProfileService profileService, UserManager<WebAppUser> usrManager)
        {
            this._appUserService = userService;
            this._logger = logger;
            this._profileService = profileService;
            this._usrManager = usrManager;
        }


        public IActionResult Index()
        {
            return View();
        }


        [Route("/AppUser/Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [Route("/AppUser/Add")]
        [HttpPost]
        public IActionResult Add(FormModelAppUser model)
        {
            if (!ModelState.IsValid) //if (!ModelState.IsValid) return Page();
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;

            AppUser appUser = model.Construct();
            appUser = _appUserService.Add(appUser);


            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Show()
        {
            var appUsersList = _appUserService.GetList();

            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;

            return View(new ShowListModel<AppUser>
            {
                Data = appUsersList,
                CurrentAppUserId = currentAppUserId,    
            });
        }

        [Authorize]
        [Route("/AppUser/Delete/{id}/")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appUserForDelete = _appUserService.GetBy(id);
            var deleteAppUser = _appUserService.Delete(appUserForDelete);

            return RedirectToAction("Show");
        }

       /* [Authorize]
        [Route("/AppUser/Update/{id}")]
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }*/

        /*[Authorize]
        [Route("/AppUser/Update/{id}")]
        [HttpPost]
        public IActionResult Update(int id, FormModelAppUser model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var appUser = _appUserService.GetBy(id);
            var changedAppUser = model.changeAppUserData(appUser);
            var updatedUser = _appUserService.Update(appUser);

            return RedirectToAction("Show");
        }*/


        public class AppUserUpdateFM 
        {
            [RefAttribute("Username")]
            public string MyUserName { get; set; }
        }

        public class RefAttribute : Attribute
        {
            public string PropName { get; set; }
            public RefAttribute(string name)
            {
                PropName = name;
            }
        }


    }
}