using Forum.Core.Models.Answer;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class AnswerUpdateViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(AnswerUpdateFM model)
        {
            return View();
        }
    }
}
