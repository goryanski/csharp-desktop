using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;

namespace StoreApp.BLL.Interfaces
{
    public interface IPublishingOfficesService
    {
        void CreatePublishingOffice(PublishingOfficeDTO publishingOffice);
        PublishingOfficeDTO GetPublishingOfficeById(int id);
    }
}
