using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class CommentToAnswerShowViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
