using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.ModelsDAL.Serivces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using BLL.ModelsDTO.Serivces;

namespace BLL.Services
{
    public class ServiceInfoService : IServiceInfoRepository
    {
        public async Task<List<ServiceInfoDTO>> GetCostByYear(int year = 0)
        {
            if (year == 0) year = DateTime.Now.Year;
            List<ServiceCost> services = new List<ServiceCost>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServiceCost, ServiceInfoDTO>().ReverseMap());
            var mapper = new Mapper(config);
            using (ContractContext context = new ContractContext())
            {
                services = await context.ServiceCost.AsNoTracking().Where(sc => sc.Year == year).Include(sc => sc.ServiceType).ToListAsync();
            }
            return mapper.Map<List<ServiceInfoDTO>>(services);
        }

        public async Task<int[]> GetServiceYears()
        {
            int[] servicesYeasrs = null;
            using (ContractContext context = new ContractContext())
            {
                servicesYeasrs = await context.ServiceCost.AsNoTracking().Select(sc => sc.Year).Distinct().OrderByDescending(y => y).ToArrayAsync();
            }
            return servicesYeasrs;
        }

        public async Task AddNewServicesByYear(List<ServiceInfoDTO> newServices)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServiceInfoDTO, ServiceCost>());
            var mapper = new Mapper(config);
            List<ServiceCost> services = mapper.Map<List<ServiceCost>>(newServices);
            using (ContractContext context = new ContractContext())
            {
                await context.ServiceCost.AddRangeAsync(services);
                await context.SaveChangesAsync();
            }
        }

    }
}
