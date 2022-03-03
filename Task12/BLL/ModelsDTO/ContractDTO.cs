using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.ModelsDTO
{
    public class ContractDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо указать номер договора")]
        public string Number{ get; set; }
        [Required(ErrorMessage = "Необходимо указать дату начала действия")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
/*        public ICollection<ServiceSoftware> ServicesSoftware { get; set; }
        public ICollection<ServiceHardware> ServicesHardware { get; set; }*/
        public int OrganizationId { get; set; }
    }
}
