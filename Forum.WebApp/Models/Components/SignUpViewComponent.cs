using Forum.WebApp.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class SignUpViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(RegisterFM model)
        {
            return View();
        }
    }
}
