using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ModelsDTO.Serivces
{
    public class ServiceSoftwareDTO
    {
        public int Id { get; set; }
        public int MainPlaceCount { get; set; }
        public int AdditionalPlaceCount { get; set; }
        public int ServiceInfoId { get; set; }
        public int ContractId { get; set; }
    }
}
