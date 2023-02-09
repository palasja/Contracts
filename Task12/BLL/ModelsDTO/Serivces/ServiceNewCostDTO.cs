using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDTO.Serivces
{
    public class ServiceNewCostDTO
    {
        [Required(ErrorMessage = "Необходимо ввести год")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Необходимо ввести месяц начало действия (0 для всего года)")]
        public int Month { get; set; }
        [Required]
        public double MainCost { get; set; }
        [Required]
        public double AdditionalCost { get; set; }
        [Required]
        public double More5Cost { get; set; } = 0;
        public int ServiceTypeId { get; set; }
    }
}
