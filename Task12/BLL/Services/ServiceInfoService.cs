using AutoMapper;
using BLL.Interfaces;
using BLL.ModelsDTO.Serivces;
using DAL;
using DAL.ModelsDAL.Serivces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class ServiceInfoService : IServiceInfoRepository
    {
        public async Task<List<ServiceInfoDTO>> GetServicesInfoAsync()
        {
            List<ServiceType> services = new List<ServiceType>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServiceType, ServiceInfoDTO>());
            var mapper = new Mapper(config);
            using (ContractContext context = new ContractContext())
            {
                services = await context.ServiceType.AsNoTracking().ToListAsync();
            }
            return mapper.Map<List<ServiceInfoDTO>>(services);
        }
    }
}
