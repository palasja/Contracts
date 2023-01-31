using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TestRepository
{
    static class ServiceTypeRepository
    {
        public static List<ServiceType> getSerivecesType() 
        {
            var si = new List<ServiceType>();

            si.Add(new ServiceType()
            {
                Id = 1,
                Name = "Обслуживание КлиентТК",
                Description = "Консультации, удалённая поддержка. При необходимости выезд к клиенту"
            });
            si.Add(new ServiceType()
            {
                Id = 2,
                Name = "Обслуживание ГРС",
                Description = "Консультации, удалённая поддержка. При необходимости выезд к клиенту."
            });
            si.Add(new ServiceType()
            {
                Id = 3,
                Name = "Сопровождение вычислительно техники",
                Description = "Обслуживание техники. Ежемесечная проверка с диагностикой на месте эксплуатации."
            });
            si.Add(new ServiceType()
            {
                Id = 4,
                Name = "Удалённое сопровождение вычислительно техники",
                Description = "Удалённое бслуживание техники без выезда на место"
            });
            si.Add(new ServiceType()
            {
                Id = 5,
                Name = "Установка ГРС",
                Description = "Удалённая установка. При необходимости выезд к клиенту и установка на месте."
            });
            return si;
        }
    }
}
