using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Models.UserProfile;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly ILogger<UserProfileController> _logger;
        private IUserProfileService _userProfileService;

        public UserProfileController(ILogger<UserProfileController> logger, IUserProfileService profileService)
        {
            _logger = logger;
            _userProfileService = profileService;
        }


        [Route("/UserProfile/Show/{id}")]
        [HttpGet]
        public IActionResult Show(int id)
        {
            var userProfile = _userProfileService.GetBy(id);

            return View(new UserProfileShowFm
            {
                AppUserId = userProfile.AppUserId,
                Name = userProfile.Name,
                Surname = userProfile.Surname,
                DisplayName = userProfile.DisplayName
            });
        }
    }
}
