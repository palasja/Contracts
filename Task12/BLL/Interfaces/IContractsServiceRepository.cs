using BLL.ModelsBLL;
using BLL.ModelsDTO;
using BLL.ModelsDTO.Serivces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IContractsServiceRepository
    {
        public Task<List<ContractInfo>> GetFullContractOnOrganization(int organizationId);

        public Task AddContract(ContractDTO contractDTO, List<ServiceHardwareDTO> hardwaresDTO, List<ServiceSoftwareDTO> softwaresDTO);

        public Task<double> GetCostOnPeriod(int areaId, DateTime startFilter, DateTime endFilter);
        public Task<double> GetCostOnPeriod(DateTime startFilter, DateTime endFilter);
    }
}
