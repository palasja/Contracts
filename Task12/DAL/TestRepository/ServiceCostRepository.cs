using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TestRepository
{
    public static class ServiceCostRepository
    {
        public static List<ServiceCost> getSerivecesCost()
        {
            var si = new List<ServiceCost>();

            si.Add(new ServiceCost()
            {
                Id = 1,
                Year = 2021,
                ServiceTypeId = 1,
                MainCost = 39.60,
                AdditionalCost = 19.80,
                More5Cost = 14.76,
            });
            si.Add(new ServiceCost()
            {
                Id = 2,
                Year = 2021,
                ServiceTypeId = 2,
                MainCost = 39.60,
                AdditionalCost = 19.80,
                More5Cost = 14.76,
            });
            si.Add(new ServiceCost()
            {
                Id = 3,
                Year = 2021,
                ServiceTypeId = 3,
                MainCost = 24.00,
                AdditionalCost = 52.80,
            });
            si.Add(new ServiceCost()
            {
                Id = 4,
                Year = 2021,
                ServiceTypeId = 4,
                MainCost = 19.20,
                AdditionalCost = 14.40,
            });
            si.Add(new ServiceCost()
            {
                Id = 5,
                Year = 2021,
                ServiceTypeId = 5,
                MainCost = 50.40,
                AdditionalCost = 21.48,
            });
            return si;
        }
    }
}
