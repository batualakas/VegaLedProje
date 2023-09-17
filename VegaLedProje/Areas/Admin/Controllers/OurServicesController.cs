using Microsoft.AspNetCore.Mvc;
using VegaLedProje.Areas.Admin.Models;
using VegaLedProje.Business.Managers;
using VegaLedProje.Business.Services;
using VegaLedProje.Data.Dto;
using VegaLedProje.Data.Entities;   

namespace VegaLedProje.Areas.Admin.Controllers
{
    public class OurServicesController : BaseController
    {
        private readonly IOurServicesService _ourServicesService;
        private readonly IWebHostEnvironment _environment;
        public OurServicesController(IOurServicesService ourServicesService, IWebHostEnvironment environment)
        {
            _ourServicesService = ourServicesService;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var values = _ourServicesService.GetOurService();

            return View(values);
        }

        [HttpGet]
        public IActionResult New()
        {

            return View("form", new OurServicesFormViewModel());
        }
        [HttpPost]
        public IActionResult Save(OurServicesFormViewModel formData)
        {
            var allowedFileContentTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/jfif" };
            var allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".jfif" };

            var fileContentType = formData.File.ContentType;
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(formData.File.FileName);
            var fileExtension = Path.GetExtension(formData.File.FileName);
            if (formData.File == null || formData.File.Length == 0 || !allowedFileContentTypes.Contains(fileContentType) || !allowedFileExtensions.Contains(fileExtension))
            {
                ModelState.AddModelError("file", "Lütfen jpg , jpeg, jfif veya png tipinde geçerli bir dosya yükleyiniz.");
                return View("form", formData);
            }
            var newFileName = fileNameWithoutExtension + "_" + Guid.NewGuid() + fileExtension;
            var folderPath = Path.Combine("images", "OurServices");
            var wwwRootFolderPath = Path.Combine(_environment.WebRootPath, folderPath);
            var wwwRootFilePath = Path.Combine(wwwRootFolderPath, newFileName);

            Directory.CreateDirectory(wwwRootFolderPath);

            using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
            {
                formData.File.CopyTo(fileStream);
            }
            if (formData.Id==0)
            {
                var ourServicesDto = new OurServicesDto()
                {
                    Id = formData.Id,
                    Description = formData.Description,
                    Title = formData.Title,
                    ImagePath = newFileName
                };
                var response=_ourServicesService.AddOurService(ourServicesDto);
                if (response.IsSucceed)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.ErrorMessage = response.Message;
                    return View("form", formData);
                }
            }
            else
            {
                var ourServicesDto = new OurServicesDto()
                {
                    Id = formData.Id,
                    Description = formData.Description,
                    Title = formData.Title,
                };
                if (formData.File!=null)
                {
                    ourServicesDto.ImagePath = newFileName;
                    _ourServicesService.EditOurService(ourServicesDto);
                }
                return RedirectToAction("index");
            }
        }

        public IActionResult Edit(int id)
        {
            var ourService = _ourServicesService.GetOurServiceById(id);
            var viewModel = new OurServicesFormViewModel()
            {
                Id = ourService.Id,
                Description = ourService.Description,
                Title = ourService.Title,
                
            };
            ViewBag.Image = ourService.ImagePath;
            return View("form", viewModel);
        }

        public IActionResult Delete(int id)
        {
            
            _ourServicesService.DeleteOurService(id);
            
            return RedirectToAction("index");
        }
    }
}
