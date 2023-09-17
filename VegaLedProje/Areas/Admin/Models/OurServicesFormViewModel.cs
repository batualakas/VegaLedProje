using System.ComponentModel.DataAnnotations;

namespace VegaLedProje.Areas.Admin.Models
{
    public class OurServicesFormViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Projenin Görseli")]
        public IFormFile File { get; set; }
    }
}
