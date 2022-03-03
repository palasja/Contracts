using BLL.ModelsDTO;
using BLL.ModelsDTO.Serivces;
using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsBLL
{
    public class ContractsWithType
    {
        public OrganizationDTO Organization { get; set; }
        public List<ServiceInfoDTO> Services {get; set;}
    }
}
