using AutoMapper;
using BLL.Interfaces;
using BLL.ModelsBLL;
using BLL.ModelsDTO;
using BLL.ModelsDTO.Serivces;
using DAL;
using DAL.ModelsDAL;
using DAL.ModelsDAL.Serivces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ContractService : IContractsServiceRepository
    {
        public async Task<List<ContractInfo>> GetFullContractOnOrganization(int organizationId)
        {
            List<ContractInfo> fullInfo = new List<ContractInfo>();
            List<Contract> orgContracts;
            using (var context = new ContractContext())
            {
                orgContracts = await context.Contracts.Where(con => con.OrganizationId == organizationId).AsNoTracking().ToListAsync();
            }
            foreach (var contract in orgContracts)
            {
                var hardwareTask = await HardwaresForContractAsync(contract);
                var softwareTask = await SoftwaresForContractAsync(contract);
                fullInfo.Add(
                    new ContractInfo()
                    {
                        Id = contract.Id,
                        Number = contract.Number,
                        StartDate = contract.StartDate,
                        EndDate = contract.EndDate,
                        HardwareForInfo = hardwareTask,
                        SoftwareForInfo = softwareTask

                    }
                );
            }
            return fullInfo;
        }

        public async Task AddContract(ContractDTO contractDTO, List<ServiceHardwareDTO> hardwaresDTO, List<ServiceSoftwareDTO> softwaresDTO)
        {
            var configContract = new MapperConfiguration(cfg => cfg.CreateMap<ContractDTO, Contract>());
            var configHardwares = new MapperConfiguration(cfg => cfg.CreateMap<ServiceHardwareDTO, ServiceHardware>());
            var configSoftwares = new MapperConfiguration(cfg => cfg.CreateMap<ServiceSoftwareDTO, ServiceSoftware>());

            var mapperContract = new Mapper(configContract);
            var mapperHardwares = new Mapper(configHardwares);
            var mapperSoftwares = new Mapper(configSoftwares);

            Contract contract = mapperContract.Map<Contract>(contractDTO);
            List<ServiceHardware> hardwares = mapperHardwares.Map<List<ServiceHardware>>(hardwaresDTO);
            List<ServiceSoftware> softwares = mapperSoftwares.Map<List<ServiceSoftware>>(softwaresDTO);
            contract.ServicesHardware = hardwares;
            contract.ServicesSoftware = softwares;

            using (ContractContext context = new ContractContext())
            {
                await context.Contracts.AddAsync(contract);
                await context.SaveChangesAsync();
            }
        }

        public async Task<double> GetCostOnPeriod(int areaId, DateTime startFilter, DateTime endFilter)
        {
            double fullCost = 0;
            const double MY_PERCENT = 25;
            const double NDS = 20;
            const double INCOME_TAX = 13;
            const double PF = 1;
            List<Contract> contracts;
            List<ServiceCost> costContracts;
            using (ContractContext context = new ContractContext())
            {
                // This Is filter contract on crossing date. If contract started and ended before filter it skip
                /* before change to cost, remove if all work
                                 contracts = await context.Contracts.Where(c => c.Organization.AreaId == areaId).Include(c => c.ServicesHardware).ThenInclude(sh => sh.ServiceInfo).
                     Include(c => c.ServicesSoftware).ThenInclude(sh => sh.ServiceInfo).
                     Where((c => (!((startFilter <= c.StartDate && endFilter <= c.StartDate) || (startFilter >= (c.EndDate == null ? endFilter : c.EndDate) && endFilter >= (c.EndDate == null ? endFilter : c.EndDate)))))).
                     AsNoTracking().ToListAsync();
                 */
                contracts = await context.Contracts.Where(c => c.Organization.AreaId == areaId).Include(c => c.ServicesHardware).
                     Include(c => c.ServicesSoftware).
                     Where((c => (!((startFilter <= c.StartDate && endFilter <= c.StartDate) || (startFilter >= (c.EndDate == null ? endFilter : c.EndDate) && endFilter >= (c.EndDate == null ? endFilter : c.EndDate)))))).
                     AsNoTracking().ToListAsync();
                costContracts = await context.ServiceCost.Where(sc => sc.Year >= startFilter.Year && sc.Year <= endFilter.Year).AsNoTracking().ToListAsync();
            }
            fullCost += GetCostHardware(contracts, costContracts, startFilter, endFilter);
            fullCost += GetCostSoftware(contracts, costContracts, startFilter, endFilter);
            double afterNDS = fullCost * ((100 - NDS) / 100);
            double afterWithold = afterNDS * ((100 - (INCOME_TAX + PF)) / 100);
            return Math.Round(afterWithold * MY_PERCENT, MidpointRounding.AwayFromZero) / 100;
        }

        //Пока работает только для 1 организации, организации нет в запросе
        public async Task<double> GetCostOnPeriod(DateTime startFilter, DateTime endFilter)
        {
            int areaId = 0;
            using (ContractContext context = new ContractContext()) 
            {
                areaId = await context.Areas.AsNoTracking().Select(a => a.Id).FirstOrDefaultAsync();
            }
            return await GetCostOnPeriod(areaId, startFilter, endFilter);
        }
        /// <summary>
        /// Посчитать сумму заплаченую организациями на ИВЦ за выбраный период
        /// </summary>
        /// <param name="contracts"></param>
        /// <param name="startFilter"></param>
        /// <param name="endFilter"></param>
        /// <returns>Полная стоимость договоров</returns>
        private double GetCostSoftware(List<Contract> contracts, List<ServiceCost> costContracts, DateTime startFilter, DateTime endFilter)
        {
            double sum = 0;
            //contract work 1 year, don't have to delims by years
            foreach (var contract in contracts)
            {
                var month = GetMonthActionContract(contract, startFilter, endFilter);
                foreach (var software in contract.ServicesSoftware)
                {
                    var serviceCost = costContracts.FirstOrDefault(cc => cc.Year == contract.StartDate.Year && cc.ServiceTypeId == software.ServiceTypeId);

                    sum += software.MainPlaceCount * serviceCost.MainCost * month;
                    sum += software.AdditionalPlaceCount * serviceCost.AdditionalCost * month;
                }
            }
            return sum;
        }
        /// <summary>
        /// Посчитать сумму заплаченую организациями на ИВЦ за выбраный период
        /// </summary>
        /// <param name="contracts"></param>
        /// <param name="startFilter"></param>
        /// <param name="endFilter"></param>
        /// <returns>Полная стоимость договоров</returns>
        private double GetCostHardware(List<Contract> contracts, List<ServiceCost> costContracts, DateTime startFilter, DateTime endFilter)
        {
            double sum = 0;
            foreach (var contract in contracts)
            {
                var month = GetMonthActionContract(contract, startFilter, endFilter);
                foreach (var software in contract.ServicesHardware)
                {
                    var serviceCost = costContracts.FirstOrDefault(cc => cc.Year == contract.StartDate.Year && cc.ServiceTypeId == software.ServiceTypeId);

                    sum += software.ServerCount * serviceCost.MainCost * month;
                    sum += software.WorkplaceCount * serviceCost.AdditionalCost * month;
                }
            }
            return sum;
        }
        /// <summary>
        /// Посчиатать сколько месяцев действовад договор в выбраном периоде
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="startFilter"></param>
        /// <param name="endFilter"></param>
        /// <returns>Количество месяев</returns>
        private int GetMonthActionContract(Contract contract, DateTime startFilter, DateTime endFilter)
        {
            DateTime maxStart = startFilter;
            DateTime minEnd = endFilter;
            if (DateTime.Compare(contract.StartDate, startFilter) > 0) maxStart = contract.StartDate;
            if (DateTime.Compare(contract.EndDate ?? endFilter, endFilter) < 0) minEnd = contract.EndDate ?? endFilter;
            int month = ( minEnd.Year - maxStart.Year) * 12 + minEnd.Month - maxStart.Month;
            return month;
        }
        private async Task<List<HardwareForInfo>> HardwaresForContractAsync(Contract contract)
        {
            List<HardwareForInfo> hardwares = new List<HardwareForInfo>();
            using (var context = new ContractContext())
            {
                hardwares = await context.ServiceHardwares.Where(hard => hard.ContractId == contract.Id).Include(info => info.ServiceType).
                   Select(item => new HardwareForInfo()
                    {
                        ServerCount = item.ServerCount,
                        WorkplaceCount = item.WorkplaceCount,
                        ServiceInfoName = item.ServiceType.Name
                    }).AsNoTracking().ToListAsync();
            }
            return hardwares;
        }

        private async Task<List<SoftwareForInfo>> SoftwaresForContractAsync(Contract contract)
        {
            List<SoftwareForInfo> softwares = new List<SoftwareForInfo>();
            using (var context = new ContractContext())
            {
                softwares = await context.ServiceSoftwares.Where(hard => hard.ContractId == contract.Id).Include(info => info.ServiceType).
                     Select(item => new SoftwareForInfo()
                    {
                        MainPlaceCount = item.MainPlaceCount,
                        AdditionalPlaceCount = item.AdditionalPlaceCount,
                        ServiceInfoName = item.ServiceType.Name
                    }).AsNoTracking().ToListAsync();
            }
            return softwares;
        }
    }

}
