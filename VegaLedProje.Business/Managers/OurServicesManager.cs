using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaLedProje.Business.Services;
using VegaLedProje.Business.Types;
using VegaLedProje.Data.Dto;
using VegaLedProje.Data.Entities;
using VegaLedProje.Data.Repositories;

namespace VegaLedProje.Business.Managers
{
    public class OurServicesManager : IOurServicesService
    {
        private readonly IRepository<OurServicesEntity> _ourServicesRepository;
        public OurServicesManager(IRepository<OurServicesEntity> ourServicesRepository)
        {
            _ourServicesRepository = ourServicesRepository;
        }
        public ServiceMessage AddOurService(OurServicesDto ourServices)
        {
            var ourServicesEntity = new OurServicesEntity()
            {
                Id = ourServices.Id,
                Title = ourServices.Title,
                Description = ourServices.Description,
                ImagePath = ourServices.ImagePath,

            };
            _ourServicesRepository.Add(ourServicesEntity);
            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public void DeleteOurService(int id)
        {

            _ourServicesRepository.Delete(id);
         
        }

        public void EditOurService(OurServicesDto ourServices)
        {
            var ourServicesEntity = _ourServicesRepository.GetById(ourServices.Id);

            ourServices.Title = ourServicesEntity.Title;
            ourServices.Description = ourServicesEntity.Description;
            ourServices.ImagePath = ourServicesEntity.ImagePath;
            if (ourServices.ImagePath != null)
            {
                ourServicesEntity.ImagePath = ourServices.ImagePath;
            }
            _ourServicesRepository.Update(ourServicesEntity);
        }

        public List<OurServicesEntity> GetOurService()
        {
            var query = _ourServicesRepository.GetAll();
            var ourServicesEntities = query.OrderBy(x => x.CreatedDate);
            var ourServicesList = ourServicesEntities.Select(x => new OurServicesEntity
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImagePath = x.ImagePath,

            }).ToList();
            return ourServicesList;
        }

        public OurServicesDto GetOurServiceById(int id)
        {
            var ourServicesEntity = _ourServicesRepository.GetById(id);

            var ourServicesDto = new OurServicesDto
            {
                Id = ourServicesEntity.Id,
                Title = ourServicesEntity.Title,
                Description = ourServicesEntity.Description,
                ImagePath = ourServicesEntity.ImagePath,
            };
            return ourServicesDto;
        }


    }
}
