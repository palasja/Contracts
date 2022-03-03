using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsBLL
{
    public class PeopleWithOrgName
    {
        public List<PersonDTO> People { get; set; }
        public string OrgName { get; set; }
    }
}
