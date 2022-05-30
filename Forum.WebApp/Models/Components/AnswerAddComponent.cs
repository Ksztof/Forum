using Forum.Core.Models.Answer;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class AnswerAddViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(AnswerAddFM model)
        {
            return View();
        }
    }
}
