using Forum.Core.Interfaces.CommentToComment;
using Forum.Core.Models.AppUserModels;
using Forum.Core.Models.CommentToComment;
using Forum.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class CommentToCommentController : Controller
    {
        private readonly ILogger<CommentToCommentController> _logger;
        private ICommentToCommentService _commentToCommentService;

        public CommentToCommentController(ILogger<CommentToCommentController> logger, ICommentToCommentService commentToCommentService)
        {
            _logger = logger;
            this._commentToCommentService = commentToCommentService;
        }

        [Route("CommentToComment/Add/{commentToCommentId}")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("CommentToComment/Add/{commentToCommentId}")]
        [HttpPost]
        public IActionResult Add(AddCommentToCommentFM model, int commentToCommentId)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            CommentToComment commentToComment = model.Construct(commentToCommentId);
            var commentToAnswerIdc = commentToComment.CommentToAnswerId;
            _commentToCommentService.Add(commentToComment);
            return RedirectToAction("Show", new { id = commentToAnswerIdc });
        }

        [HttpGet]
        [Route("CommentToComment/Show/{commentToAnswerId}")]
        public IActionResult Show(int commentToAnswerId)
        {
            var commentToAnswerList = _commentToCommentService.GetListWithSpecificAnswerId(commentToAnswerId);
            return View(new ShowListModel<CommentToComment>
            {
                Data = commentToAnswerList,
            });
        }

        [Route("/CommentToComment/Delete/{commentToCommentId}")]
        [HttpGet]
        public IActionResult Delete(int commentToCommentId)
        {
            var commentToComment = _commentToCommentService.GetBy(commentToCommentId);
            var deleteCommentToCommentResult = _commentToCommentService.Delete(commentToComment);
            var commentToAnswerId = commentToComment.CommentToAnswerId;
            return RedirectToAction("Show", new { id = commentToAnswerId });
        }


        [Route("/CommentToComment/Update/{commentToCommentId}")]
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [Route("/CommentToComment/Update/{commentToCommentId}")]
        [HttpPost]
        public IActionResult Update(int commentToCommentId, int CommentToAnswerId, AddCommentToCommentFM model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Fill in the required fields of the form!");
            }
            var commentToComment = _commentToCommentService.GetBy(commentToCommentId);
            commentToComment = model.UpdateCommentToCommentContent(commentToComment);
            var udatedCommentToComment = _commentToCommentService.Update(commentToComment);
            var commentToAnswerId = commentToComment.CommentToAnswerId;
            return RedirectToAction("Show", "CommentToComment", new { id = commentToAnswerId });
        }


    }
}
