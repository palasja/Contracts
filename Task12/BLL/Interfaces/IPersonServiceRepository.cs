using BLL.ModelsBLL;
using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPersonServiceRepository
    {
        public Task<List<PeopleWithOrgName>> GetPersonWithOrg();

        public Task AddPerson(PersonDTO personDTO);

        public Task UpdatePerson(PersonDTO personDTO);
    }
}
