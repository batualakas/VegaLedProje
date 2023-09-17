using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaLedProje.Business.Types;
using VegaLedProje.Data.Dto;
using VegaLedProje.Data.Entities;

namespace VegaLedProje.Business.Services
{
    public interface IGenericService<T>
    {
        ServiceMessage AddOurService(OurServicesDto ourServices);
        List<OurServicesEntity> GetOurService();
        OurServicesDto GetOurServiceById(int id);
        void EditOurService(OurServicesDto ourServices);
        void DeleteOurService(int id);
       
    }
}
