using Forum.Core.Models.AppUserModels;
using Forum.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class AppUserShowViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
