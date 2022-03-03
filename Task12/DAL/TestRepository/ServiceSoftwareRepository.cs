using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TestRepository
{
    class ServiceSoftwareRepository
    {
        public static List<ServiceSoftware> getSerivecesSoftware()
        {
            var ss = new List<ServiceSoftware>();

            ss.Add(new ServiceSoftware() {Id = 1, ServiceInfoId = 1, MainPlaceCount = 1, AdditionalPlaceCount = 0, ContractId = 1});
            ss.Add(new ServiceSoftware() { Id = 2, ServiceInfoId = 2, MainPlaceCount = 1, AdditionalPlaceCount = 0, ContractId = 2 });
            ss.Add(new ServiceSoftware() { Id = 3, ServiceInfoId = 1, MainPlaceCount = 1, AdditionalPlaceCount = 1, ContractId = 3 });
            ss.Add(new ServiceSoftware() { Id = 4, ServiceInfoId = 2, MainPlaceCount = 1, AdditionalPlaceCount = 0, ContractId = 4 });
            ss.Add(new ServiceSoftware() { Id = 5, ServiceInfoId = 1, MainPlaceCount = 0, AdditionalPlaceCount = 1, ContractId = 4 });
/*            ss.Add(new ServiceSoftware() { Id = 6, ServiceInfoId = 2, MainPlaceCount = 8, AdditionalPlaceCount = 0 });*/


            return ss;
        }
    }
}
