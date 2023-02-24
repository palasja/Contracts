using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ModelsDTO.Serivces
{
    public class ServiceInfoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование услуги")]
        public string ServiceTypeName { get; set; }
        [Required]
        public int Year { get; set; }
        /// <summary>
        /// Month change cost
        /// </summary>
        public int Month { get; set; } = 0;
        /// <summary>
        /// Cost main workplace/server
        /// </summary>
        [Required]
        public double MainCost { get; set; }
        /// <summary>
        /// Cost added workplace/server
        /// </summary>
        [Required]
        public double AdditionalCost { get; set; }
        /// <summary>
        /// Cost more than 5 added workplace
        /// </summary>
        public double More5Cost { get; set; } = 0;
        public int ServiceTypeId { get; set; }
        public string ServiceTypeDescription { get; set; }
    }
}
