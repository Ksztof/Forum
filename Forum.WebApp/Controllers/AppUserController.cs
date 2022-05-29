using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Models.AppUserModels;
using Forum.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Forum.WebApp.Controllers
{
    public class AppUserController : Controller
    {
        private readonly ILogger<AppUserController> _logger;
        private IAppUserService _appUserService;
        private IUserProfileService _profileService;


        public AppUserController(ILogger<AppUserController> logger, IAppUserService userService, IUserProfileService profileService)
        {
            this._appUserService = userService;
            _logger = logger;
            _profileService = profileService;
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

            AppUser appUser = model.Construct();
            appUser = _appUserService.Add(appUser);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Show()
        {
            var appUsersList = _appUserService.GetList();

            return View(new ShowListModel<AppUser>
            {
                Data = appUsersList
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

        [Authorize]
        [Route("/AppUser/Update/{id}")]
        [HttpGet]
        public IActionResult Update()
        {
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
            model.changeAppUserData(model, appUser);
            var updatedUser = _appUserService.Update(appUser);

            return RedirectToAction("Show");
        }


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