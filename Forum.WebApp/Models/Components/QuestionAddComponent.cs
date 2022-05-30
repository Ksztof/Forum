using Forum.Core.Models.Question;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class QuestionAddViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(QuestionAddFM model)
        {
            return View();
        }
    }
}
