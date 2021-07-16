using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.UI.WPF.Helpers;

namespace StoreApp.UI.WPF.DbServices
{
    public class ViewBookDbService
    {
        ServicesStorage services = ServicesStorage.Instance;

        public string GetPublishingOfficeName(int id)
        {
            var office = services.PublishingOfficesService.GetPublishingOfficeById(id);
            return office.Name;
        }
    }
}
