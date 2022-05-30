using Forum.Core.Interfaces.Answer;
using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Models.Answer;
using Forum.Core.Models.AppUserModels;
using Forum.Domain.Models;
using Forum.Domain.Models.Error;
using Forum.Domain.Models.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class AnswerController : Controller
    {
        private UserManager<WebAppUser> _usrManager;
        private readonly ILogger<AnswerController> _logger;
        private IAnswerService _answerService;
        public AnswerController(ILogger<AnswerController> logger, IAnswerService answerService, UserManager<WebAppUser> usrManager)
        {
            this._answerService = answerService;
            _logger = logger;
            this._usrManager = usrManager;
        }


        [Route("/Answer/Add/{id}")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [Route("/Answer/Add/{id}")]
        [HttpPost]
        public IActionResult Add(AnswerAddFM model, int id)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;//TODO: do stałej wywalić we wszstkich pikach 

            Answer answer = model.Construct(id, currentAppUserId);
            answer = _answerService.Add(answer);



            return RedirectToAction("Show", "Question");
        }


        [Route("/Answer/Show/{id}")]
        [HttpGet]
        public IActionResult Show(int id)
        {
            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;

            var allAnswersToQuestion = _answerService.GetList();
            var AnswersToQuestion = allAnswersToQuestion.Where(x => x.QuestionId == id);

            return View(new ShowListModel<Answer>
            {
                Data = AnswersToQuestion,
                CurrentAppUserId = currentAppUserId,
            });
        }


        [Route("/Answer/Update/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;
            var userIdForAnswer = _answerService.GetBy(id).AppUserId;

            if (userIdForAnswer != currentAppUserId)
            {
                var errorContent = "What are you doing here?";
                return RedirectToAction("ShowError", "Account", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }
            return View();
        }


        [Route("/Answer/Update/{id}")]
        [HttpPost]
        public IActionResult Update(int id, AnswerUpdateFM model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var answer = _answerService.GetBy(id);

            model.changeAnswerData(model, answer);
            var updatedAnswer = _answerService.Update(answer);
            var questionId = updatedAnswer.QuestionId;
            return RedirectToAction("Show", new { id = questionId });
        }


        [Route("/Answer/Delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var applicationUser = _usrManager.GetUserAsync(User).Result;
            var currentAppUserId = applicationUser.UserId;
            var userIdForAnswer = _answerService.GetBy(id).AppUserId;
            if (userIdForAnswer != currentAppUserId)
            {
                var errorContent = "What are you doing here?";
                return RedirectToAction("ShowError", "Account", new ErrorFM
                {
                    ErrorContent = errorContent
                });
            }
            var answerToDelete = _answerService.GetBy(id);
            var deleteAnswerResult = _answerService.Delete(answerToDelete);
            var questionId = answerToDelete.QuestionId;
            return RedirectToAction("Show", new { id = questionId });
        }


        /*[Route("/Answer/Delete/{id}")] //TODO: JAVASCRIPT
        [HttpPost]
        public IActionResult GetData(int id)
        {
            var data = _answerService.GetBy(id);

            return Ok(JsonConvert.SerializeObject(data, new JsonSerializerSettings { Formatting = Formatting.Indented, ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }*/
    }

    //public class ProperlyController : ApiController bardziej RAW data
    //{
    //    [Route("/Answer/Delete/{id}")]
    //    [HttpPost]
    //    public IActionResult GetData(int id)
    //    {
    //        var data = _answerService.GetBy(id);

    //        return Ok(JsonConvert.SerializeObject(data, new JsonSerializerSettings { Formatting = Formatting.Indented, ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
    //    }
    //}
}