using Forum.Core.Interfaces.CommentToAnswer;
using Forum.Core.Models.AppUserModels;
using Forum.Core.Models.CommentToAnswer;
using Forum.Domain;
using Forum.Domain.Models.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class CommentToAnswerController : Controller
    {
        private readonly ILogger<CommentToAnswerController> _logger;
        private ICommentToAnswerService _commentToAnswerService;
        private UserManager<WebAppUser> usrManager;
        public CommentToAnswerController(ILogger<CommentToAnswerController> logger, ICommentToAnswerService commentToAnswerService, UserManager<WebAppUser> usrManager)
        {
            this._commentToAnswerService = commentToAnswerService;
            this.usrManager = usrManager;
            _logger = logger;
        }
        [HttpGet]
        [Route("CommentToAnswer/Add/{questionId}/{answerId}")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("CommentToAnswer/Add/{questionId}/{answerId}")]
        public IActionResult Add(CommentToAnswerAddFM model, int questionId, int answerId)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var appUser = usrManager.GetUserAsync(User).Result;
            var appUserId = appUser.UserId;

            CommentToAnswer commentToAnswer = model.Construct(answerId, questionId, appUserId);

            var commentToAnswerResult = _commentToAnswerService.Add(commentToAnswer);
            return RedirectToAction("Show", "Answer", new { id = questionId });
        }

        [HttpGet]
        [Route("CommentToAnswer/Show/{id}")]
        public IActionResult Show(int id)
        {
            var commentToAnswerList = _commentToAnswerService.GetListWithSpecificAnswerId(id);
            var appUser = usrManager.GetUserAsync(User).Result;
            var appUserId = appUser.UserId;
            return View(new ShowListModel<CommentToAnswer>
            {
                Data = commentToAnswerList,
                CurrentAppUserId = appUserId,
            });
        }

        [Route("/CommentToAnswer/Delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var commentToAnswer = _commentToAnswerService.GetBy(id);
            var deleteCommentToAnswerResult = _commentToAnswerService.Delete(commentToAnswer);
            var AnswerId = commentToAnswer.AnswerId;
            return RedirectToAction("Show", new { id = AnswerId });
        }

        [Route("/CommentToAnswer/Update/{id}")]
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }



        [Route("/CommentToAnswer/Update/{id}")]
        [HttpPost]
        public IActionResult Update(int id, UpdateCommentToAnswerFM model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var commentToAnswer = _commentToAnswerService.GetBy(id);
            model.changeCommentToAnswerData(commentToAnswer);
            var questionUpdateResult = _commentToAnswerService.Update(commentToAnswer);

            return RedirectToAction("Show", new { id = commentToAnswer.AnswerId });
        }

    }
}
