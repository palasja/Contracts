using AutoMapper;
using BlazorInputFile;
using BLL.Interfaces;
using BLL.ModelsDTO;
using BLL.ModelsDTO.Serivces;
using DAL;
using DAL.ModelsDAL;
using DAL.ModelsDAL.Serivces;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class OrganizationService : IOrganizationRepository
    {
        public async Task<List<OrganizationDTO>> GetOrganizationOnAreaAsync(int areaId )
        {
            List<OrganizationDTO> organization = new List<OrganizationDTO>();
            List <Organization> AllOrganizations = new List<Organization>();
            using (ContractContext context = new ContractContext())
            {
                AllOrganizations = await context.Organizations.Where(org => org.AreaId == areaId).OrderBy(org => org.FullName).AsNoTracking().ToListAsync();
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Organization, OrganizationDTO>());
            var mapper = new Mapper(config);
            organization = mapper.Map<List<OrganizationDTO>>(AllOrganizations);

            return organization;
        }

        public async Task ChangeOrganization(OrganizationDTO organization) 
        {
            using (ContractContext context = new ContractContext())
            {
                var org = context.Organizations.Where(org => org.Id == organization.Id).FirstOrDefault();
                if (!org.Name.Equals(organization.Name)) org.Name = organization.Name;
                if (!org.FullName.Equals(organization.FullName)) org.FullName = organization.FullName;
                if (!org.Address.Equals(organization.Address)) org.Address = organization.Address;
                if (!org.Email.Equals(organization.Email)) org.Email = organization.Email;
                if (!org.Smdo.Equals(organization.Smdo)) org.Smdo = organization.Smdo;
                await context.SaveChangesAsync();
            }
        }

        public async Task AddOrganization(OrganizationDTO organizationDTO, PersonDTO personDTO)
        {
            var configOrganization = new MapperConfiguration(cfg => cfg.CreateMap<OrganizationDTO, Organization>());
            var configPerson = new MapperConfiguration(cfg => cfg.CreateMap<PersonDTO, Person>());

            var mapperOrganization = new Mapper(configOrganization);
            var mapperPerson = new Mapper(configPerson);

            var organization = mapperOrganization.Map<Organization>(organizationDTO);
            var person = mapperPerson.Map<Person>(personDTO);
            organization.People = new List<Person>() { person};
            using (ContractContext context = new ContractContext())
            {
                await context.Organizations.AddAsync(organization);
                await context.SaveChangesAsync();
            }
        }

        public async Task<string> OrganizationFromTM(IFileListEntry fileEntry)
        {
            FileService fs = new FileService();
            const string areName = "Наровля";
            string result = "";
            
            var path = await fs.SaveFile(fileEntry, fileEntry.Name);
            DataTable dt = fs.GetTableFromFile(path);

            Area area = await GetAreaId(areName);
            int newOrgCount = 0;
            int newContractsCount = 0;
            if (area == null)
            {
                result = $"Нет райна с названием {areName}";
            }
            else 
            {
                List<Organization> TMOrganizations = await ReadOrganizationsWithContracts(dt, area.Id);
                using (ContractContext context = new ContractContext())
                {
                    foreach(Organization TMOrg in TMOrganizations)
                    {
                        var currentOrganization = await context.Organizations.Include(o => o.Contracts).FirstOrDefaultAsync(dbOrg => dbOrg.UNP == TMOrg.UNP);
                        if(currentOrganization == null)
                        {
                            await context.Organizations.AddRangeAsync(TMOrganizations);
                            await context.SaveChangesAsync();
                            newOrgCount += 1;
                            result = $"Добавлено: организаций - {newOrgCount}";
                        } else {
                            foreach(Contract TMContract in TMOrg.Contracts)
                            {
                                var currentContract = currentOrganization.Contracts.FirstOrDefault(c => c.Number == TMContract.Number);
                                if (currentContract == null)
                                {
                                    currentOrganization.Contracts.Add(TMContract);
                                    context.SaveChanges();
                                    newContractsCount += 1;
                                }
                            }
                            result = $"Добавлено: организаций - {newOrgCount}; договоров {newContractsCount} ";
                        }
                    }
                }
            }
            return result;
        }

        private async Task<Area> GetAreaId(string areaSimpleName)
        {
            Area area;
            using (ContractContext context = new ContractContext())
            {
                area = await context.Areas.Where(a => a.SimpleName.Equals(areaSimpleName)).FirstOrDefaultAsync();
            }
            return area;
        }

        private async Task<List<Organization>> ReadOrganizationsWithContracts(DataTable dt, int areaId)
        {
            Dictionary<int, Organization> organizations = new Dictionary<int, Organization>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrganizationDTO, Organization>();
                cfg.CreateMap<ContractDTO, Contract>();
                cfg.CreateMap<ServiceHardwareDTO, ServiceHardware>();
                cfg.CreateMap<ServiceSoftwareDTO, ServiceSoftware>();
            });
            Mapper mapper = new Mapper(config);
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int unp = Int32.Parse(row[7].ToString());
                ServiceSoftwareDTO ktk = new ServiceSoftwareDTO();
                ServiceSoftwareDTO grs = new ServiceSoftwareDTO();
                ServiceHardwareDTO sto = new ServiceHardwareDTO();
                ServiceHardwareDTO usvt = new ServiceHardwareDTO();
                OrganizationDTO organizationDTO = new OrganizationDTO();

                var contractDTO = new ContractDTO()
                {
                    Number = row[1].ToString(),
                    StartDate = DateTime.Parse(row[5].ToString()),
                    EndDate = DateTime.Parse(row[6].ToString()),
                };

                if (Int16.Parse(row[19].ToString()) != 0)
                {
                    ktk.ServiceInfoId = 1;
                    ktk.MainPlaceCount = Int16.Parse(row[19].ToString());
                    ktk.AdditionalPlaceCount = Int16.Parse(row[20].ToString());
                }

                if (Int16.Parse(row[21].ToString()) != 0)
                {
                    grs.ServiceInfoId = 2;
                    grs.MainPlaceCount = Int16.Parse(row[21].ToString());
                    grs.AdditionalPlaceCount = Int16.Parse(row[22].ToString());
                }

                if (Int16.Parse(row[23].ToString()) != 0 || Int16.Parse(row[24].ToString()) != 0)
                {
                    sto.ServiceInfoId = 3;
                    sto.ServerCount = Int16.Parse(row[23].ToString());
                    sto.WorkplaceCount = Int16.Parse(row[24].ToString());
                }

                if (Int16.Parse(row[25].ToString()) != 0 || Int16.Parse(row[26].ToString()) != 0)
                {
                    usvt.ServiceInfoId = 4;
                    usvt.ServerCount = Int16.Parse(row[25].ToString());
                    usvt.WorkplaceCount = Int16.Parse(row[26].ToString());
                }

                if (!organizations.ContainsKey(unp))
                {
                    organizationDTO.UNP = unp;
                    organizationDTO.AreaId = areaId;
                    organizationDTO.FullName = row[8].ToString();
                    organizationDTO.Address = $"{row[13].ToString()}, {row[14].ToString()}, {row[17].ToString()}, {row[12].ToString()}";
                    var organization = await Task.Run(() => mapper.Map<Organization>(organizationDTO));
                    organization.Contracts = new List<Contract>();
                    organizations.Add(unp, organization);
                }

                Contract contract = mapper.Map<Contract>(contractDTO);
                contract.ServicesHardware = new List<ServiceHardware>();
                contract.ServicesSoftware = new List<ServiceSoftware>();
                if (! (ktk.ServiceInfoId == 0)) contract.ServicesSoftware.Add(mapper.Map<ServiceSoftware>(ktk));
                if (! (grs.ServiceInfoId == 0)) contract.ServicesSoftware.Add(mapper.Map<ServiceSoftware>(grs));
                if (! (sto.ServiceInfoId == 0)) contract.ServicesHardware.Add(mapper.Map<ServiceHardware>(sto));
                if (! (usvt.ServiceInfoId == 0)) contract.ServicesHardware.Add(mapper.Map<ServiceHardware>(usvt));

                var org = organizations[unp];
                org.Contracts.Add(contract);
            }

            return organizations.Values.ToList();
        }
    }

}