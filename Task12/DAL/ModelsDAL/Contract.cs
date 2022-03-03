using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsDAL
{
    public class Contract
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо указать номер договора")]
        public string Number{ get; set; }
        [Required(ErrorMessage = "Необходимо указать дату начала действия")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<ServiceSoftware> ServicesSoftware { get; set; }
        public ICollection<ServiceHardware> ServicesHardware { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
    }
}
