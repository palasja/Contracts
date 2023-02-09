using BLL.ModelsDTO.Serivces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IServiceInfoRepository
    {
        public Task<List<ServiceInfoDTO>> GetServicesInfoAsync();
        public Task<List<ServiceInfoDTO>> GetLastYaerCost();
    }
}
