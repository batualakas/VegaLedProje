﻿using Microsoft.AspNetCore.Mvc;

namespace VegaLedProje.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
