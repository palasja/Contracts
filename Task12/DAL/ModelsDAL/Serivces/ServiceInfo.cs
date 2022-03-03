using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ModelsDAL.Serivces
{
    public class ServiceInfo
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование услуги
        /// </summary>
        [Required(ErrorMessage = "Укажите наименование услуги")]
        public string Name { get; set; }
        /// <summary>
        /// Стоимость основного места/сервера
        /// </summary>
        [Required]
        public double MainCost { get; set; }
        /// <summary>
        /// Стоимость дополнительного места/сервера
        /// </summary>
        [Required]
        public double AdditionalCost { get; set; }
        /// <summary>
        /// Стоимость свыше 5 дополнительных мест
        /// </summary>
        public double More5Cost { get; set; } = 0;
        public string? Description { get; set; }
    }
}
