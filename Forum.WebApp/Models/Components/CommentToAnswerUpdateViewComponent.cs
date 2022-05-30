using Forum.Core.Models.CommentToAnswer;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class CommentToAnswerUpdateViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(UpdateCommentToAnswerFM model)
        {
            return View();
        }
    }
}
