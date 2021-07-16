using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Interfaces;

namespace StoreApp.BLL.Services
{
    public class PublishingOfficesService : IPublishingOfficesService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;

        public PublishingOfficesService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreatePublishingOffice(PublishingOfficeDTO publishingOffice)
        {
            var result = objectMapper.Mapper.Map<PublishingOffice>(publishingOffice);
            uow.PublishingOfficesRepository.Create(result);
            uow.Save();
        }

        public PublishingOfficeDTO GetPublishingOfficeById(int id)
        {
            var result = uow.PublishingOfficesRepository.Get(id);
            return objectMapper.Mapper.Map<PublishingOfficeDTO>(result);
        }

        public List<PublishingOfficeDTO> GetAllOffices()
        {
            var result = uow.PublishingOfficesRepository.GetAll();
            return objectMapper.Mapper.Map<List<PublishingOfficeDTO>>(result);
        }

    }
}
