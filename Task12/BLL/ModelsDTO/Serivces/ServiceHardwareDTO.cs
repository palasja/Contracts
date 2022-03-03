using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ModelsDTO.Serivces
{
    public class ServiceHardwareDTO
    {
        public int Id { get; set; }
        public int ServerCount { get; set; }
        public int WorkplaceCount { get; set; }
        public int ServiceInfoId { get; set; }
        public int ContractId { get; set; }
    }
}
