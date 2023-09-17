using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaLedProje.Data.Entities
{
    public class OurServicesEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
