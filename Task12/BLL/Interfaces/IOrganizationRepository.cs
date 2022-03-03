using BlazorInputFile;
using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrganizationRepository
    {
        public Task<List<OrganizationDTO>> GetOrganizationOnAreaAsync(int areaId);
        public Task ChangeOrganization(OrganizationDTO organization);

        public Task AddOrganization(OrganizationDTO organization, PersonDTO person);
        public Task<string> OrganizationFromTM(IFileListEntry fileEntry);
    }
}
