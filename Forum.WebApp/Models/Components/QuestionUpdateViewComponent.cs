using Forum.Core.Models.Question;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class QuestionUpdateViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(QuestionAddFM model)
        {
            return View();
        }
    }
}
