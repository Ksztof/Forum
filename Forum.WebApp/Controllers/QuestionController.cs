using Forum.Core.Interfaces.Question;
using Forum.Core.Models.AppUserModels;
using Forum.Core.Models.Question;
using Forum.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;
        private IQuestionService _questionService;
        //dependency injection i reverse
        public QuestionController(ILogger<QuestionController> logger, IQuestionService questionService)
        {
            this._questionService = questionService;
            _logger = logger;
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

            Question question = model.Construct();
            question = _questionService.Add(question);

            return RedirectToAction("Show");
        }


        [HttpGet]
        public IActionResult Show()
        {
            var questionsList = _questionService.GetList();

            return View(new ShowListModel<Question>
            {
                Data = questionsList,
            });
        }


        [Route("/Question/Delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var question = _questionService.GetBy(id);
            var questionDeleteResult = _questionService.Delete(question);

            return RedirectToAction("Show");
        }


        [Route("/Question/Update/{id}")]
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }



        [Route("/Question/Update/{id}")]
        [HttpPost]
        public IActionResult Update(int id, QuestionAddFM model)//utowrzyc formularz przesłac id hidden value
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
