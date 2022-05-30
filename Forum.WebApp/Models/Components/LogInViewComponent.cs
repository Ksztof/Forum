using Forum.Core.Models.Question;
using Forum.WebApp.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class LogInViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(LogInModel model)
        {
            return View();
        }
    }
}
