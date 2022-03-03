using DAL.ModelsDAL;
using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.TestRepository
{
    static class ContractRepository
    {
        public static List<Contract> GetContracts()
        {
            var contracts = new List<Contract>();

            contracts.Add(new Contract()
            {
                Id = 1,
                Number = "12-123/ВК6",
                StartDate = DateTime.Parse("2020-01-01"),
                EndDate = DateTime.Parse("2022-02-12"),
                OrganizationId = 1,
            });
            contracts.Add(new Contract()
            {
                Id = 2,
                Number = "12-1/ГК6",
                StartDate = DateTime.Parse("2020-02-12"),
                EndDate = DateTime.Parse("2022-05-28"),
                OrganizationId = 2,
            });
            contracts.Add(new Contract()
            {
                Id = 3,
                Number = "33-4/НК-6",
                StartDate = DateTime.Parse("2020-01-01"),
                EndDate = DateTime.Parse("2022-06-02"),
                OrganizationId = 3,
                
            });
            contracts.Add(new Contract()
            {
                Id = 4,
                Number = "4484/ОИ-6",
                StartDate = DateTime.Parse("2020-01-01"),
                EndDate = DateTime.Parse("2022-07-2"),
                OrganizationId = 4,
            });
            return contracts;
        }
    }
}
