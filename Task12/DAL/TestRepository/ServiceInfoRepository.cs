using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TestRepository
{
    static class ServiceInfoRepository
    {
        public static List<ServiceInfo> getSerivecesInfo() 
        {
            var si = new List<ServiceInfo>();

            si.Add(new ServiceInfo()
            {
                Id = 1,
                Name = "Обслуживание КлиентТК",
                MainCost = 39.60,
                AdditionalCost = 19.80,
                More5Cost = 14.76,
                Description = "Консультации, удалённая поддержка. При необходимости выезд к клиенту"
            });
            si.Add(new ServiceInfo()
            {
                Id = 2,
                Name = "Обслуживание ГРС",
                MainCost = 39.60,
                AdditionalCost = 19.80,
                More5Cost = 14.76,
                Description = "Консультации, удалённая поддержка. При необходимости выезд к клиенту."
            });
            si.Add(new ServiceInfo()
            {
                Id = 3,
                Name = "Сопровождение вычислительно техники",
                MainCost = 24.00,
                AdditionalCost = 52.80,
                Description = "Обслуживание техники. Ежемесечная проверка с диагностикой на месте эксплуатации."
            });
            si.Add(new ServiceInfo()
            {
                Id = 4,
                Name = "Удалённое сопровождение вычислительно техники",
                MainCost = 19.20,
                AdditionalCost = 14.40,
                Description = "Удалённое бслуживание техники без выезда на место"
            });
            si.Add(new ServiceInfo()
            {
                Id = 5,
                Name = "Установка ГРС",
                MainCost = 50.40,
                AdditionalCost = 21.48,
                Description = "Удалённая установка. При необходимости выезд к клиенту и установка на месте."
            });
            return si;
        }
    }
}
