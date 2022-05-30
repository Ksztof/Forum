using Forum.Core.Interfaces.Question;
using Forum.Core.Models.AppUserModels;
using Forum.Core.Models.Question;
using Forum.Domain.Models;
using Forum.Domain.Models.Error;
using Forum.Domain.Models.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;
        private IQuestionService _questionService;
        private UserManager<WebAppUser> _usrManager;
        //dependency injection i reverse
        public QuestionController(ILogger<QuestionController> logger, IQuestionService questionService, UserManager<WebAppUser> usrManager)
        {
            this._questionService = questionService;
            this._logger = logger;
            this._usrManager = usrManager;
        }


        [HttpGet]
        [Route("Question/Add")]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(QuestionAddFM model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var appUser = _usrManager.GetUserAsync(User).Result;
            var appUserId = appUser.UserId;

            Question question = model.Construct(appUserId);
            question = _questionService.Add(question);

            return RedirectToAction("Show");
        }


        [HttpGet]
        public IActionResult Show()
        {
            var questionsList = _questionService.GetList();
            var appUser = _usrManager.GetUserAsync(User).Result;
            var appUserId = appUser.UserId;
            return View(new ShowListModel<Question>
            {
                Data = questionsList,
                CurrentAppUserId = appUserId,
            });
        }


        [Route("/Question/Delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;
            var userIdForQuestion = _questionService.GetBy(id).AppUserId;
            if (userIdForQuestion != currentAppUserId)
            {
                var errorContent = "What are you doing here?";
                return RedirectToAction("ShowError", "Account", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }
            var question = _questionService.GetBy(id);
            var questionDeleteResult = _questionService.Delete(question);

            return RedirectToAction("Show");
        }


        [Route("/Question/Update/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;
            var userIdForQuestion = _questionService.GetBy(id).AppUserId;

            if (userIdForQuestion != currentAppUserId)
            {
                var errorContent = "What are you doing here?";
                return RedirectToAction("ShowError", "Account", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }
            return View();
        }



        [Route("/Question/Update/{id}")]
        [HttpPost]
        public IActionResult Update(int id, QuestionAddFM model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var question = _questionService.GetBy(id);
            model.changeQuestionData(question);
            var questionUpdateResult = _questionService.Update(question);

            return RedirectToAction("Show");
        }
    }
}
