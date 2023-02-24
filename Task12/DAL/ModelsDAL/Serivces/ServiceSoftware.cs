using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ModelsDAL.Serivces
{
    public class ServiceSoftware
    {
        public int Id { get; set; }
        [Required]
        public int MainPlaceCount { get; set; }
        [DefaultValue(0)]
        public int AdditionalPlaceCount { get; set; }
        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
        public Contract Contract { get; set; }
        public int ContractId { get; set; }
    }
}
