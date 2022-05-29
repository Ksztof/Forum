using Forum.Core.Interfaces.CommentToAnswer;
using Forum.Core.Models.AppUserModels;
using Forum.Core.Models.CommentToAnswer;
using Forum.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class CommentToAnswerController : Controller
    {
        private readonly ILogger<CommentToAnswerController> _logger;
        private ICommentToAnswerService _commentToAnswerService;
        public CommentToAnswerController(ILogger<CommentToAnswerController> logger, ICommentToAnswerService commentToAnswerService)
        {
            this._commentToAnswerService = commentToAnswerService;
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

            CommentToAnswer commentToAnswer = model.Construct(answerId, questionId);

            var commentToAnswerResult = _commentToAnswerService.Add(commentToAnswer);
            return RedirectToAction("Show", "Answer", new { id = questionId });
        }

        [HttpGet]
        [Route("CommentToAnswer/Show/{id}")]
        public IActionResult Show(int id)
        {
            /*var allCommentToAnswerList = _commentToAnswerService.GetList();
            var commentToAnswerList = allCommentToAnswerList.Where(x => x.AnswerId == id);*/
            var commentToAnswerList = _commentToAnswerService.GetListWithSpecificAnswerId(id);

            return View(new ShowListModel<CommentToAnswer>
            {
                Data = commentToAnswerList,
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
        public IActionResult Update(int id, UpdateCommentToAnswerFM model)//utowrzyc formularz przesłac id hidden value
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var commentToAnswer = _commentToAnswerService.GetBy(id);
            model.changeCommentToAnswerData(commentToAnswer);//jak zrobic zeby pustych
            var questionUpdateResult = _commentToAnswerService.Update(commentToAnswer);
            
            return RedirectToAction("Show", new { id = commentToAnswer.AnswerId });
        }

    }
}
