using Forum.Core.Models.CommentToComment;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class CommentToCommentAddViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(AddCommentToCommentFM model)
        {
            return View();
        }
    }
}
