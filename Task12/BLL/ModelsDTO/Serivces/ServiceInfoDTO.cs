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
        public string Name { get; set; }
        /*[Required]
        public double MainCost { get; set; }
        [Required]
        public double AdditionalCost { get; set; }*/
        public string Description { get; set; }
    }
}
