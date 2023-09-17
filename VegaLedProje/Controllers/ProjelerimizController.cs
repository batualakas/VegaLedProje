using Microsoft.AspNetCore.Mvc;
using VegaLedProje.Business.Managers;
using VegaLedProje.Business.Services;
using VegaLedProje.Models;

namespace VegaLedProje.Controllers
{
    public class ProjelerimizController : Controller
    {
        private readonly IOurServicesService _ourServicesService;
        public ProjelerimizController(IOurServicesService ourServicesService)
        {
              _ourServicesService=ourServicesService;
        }
        public IActionResult Index()
        {
            var ourServices= _ourServicesService.GetOurService();
            var viewModel = ourServices.Select(x => new OurServicesViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
                ImagePath = x.ImagePath
            }).ToList();
            return View(viewModel);
        }
    }
}
