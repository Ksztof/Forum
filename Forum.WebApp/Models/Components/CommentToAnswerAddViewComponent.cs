using Forum.Core.Models.CommentToAnswer;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class CommentToAnswerAddViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CommentToAnswerAddFM model)
        {
            return View();
        }
    }
}
