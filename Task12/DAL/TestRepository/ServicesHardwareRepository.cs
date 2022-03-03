using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TestRepository
{
    class ServiceHardwareRepository
    {
        public static List<ServiceHardware> getSerivecesHardware()
        {
            var ss = new List<ServiceHardware>();

            ss.Add(new ServiceHardware() { Id = 1, ServiceInfoId = 3, ServerCount = 0, WorkplaceCount = 2,ContractId = 1 });
            ss.Add(new ServiceHardware() { Id = 2, ServiceInfoId = 4, ServerCount = 0, WorkplaceCount = 5, ContractId = 2 });
            ss.Add(new ServiceHardware() { Id = 3, ServiceInfoId = 3, ServerCount = 1, WorkplaceCount = 5, ContractId = 4 });
            ss.Add(new ServiceHardware() { Id = 4, ServiceInfoId = 4, ServerCount = 1, WorkplaceCount = 2 , ContractId = 3});
           /* ss.Add(new ServiceHardware() { Id = 5, ServiceInfoId = 1, ServerCount = 0, WorkplaceCount = 43 });
            ss.Add(new ServiceHardware() { Id = 6, ServiceInfoId = 2, ServerCount = 0, WorkplaceCount = 12 });*/


            return ss;
        }
    }
}
