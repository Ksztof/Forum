﻿using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Models.Components
{
    public class AnswerShowViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

        /*public async Task<IViewComponentResult> InvokeAsync(string formModel)
        {
            return View();
        }*/
    }
}
