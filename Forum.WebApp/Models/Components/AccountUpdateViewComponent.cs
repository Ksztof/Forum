using Forum.Core.Models.AppUserModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class AccountUpdateViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(FormModelAppUser model)
        {
            return View();
        }
    }
}
