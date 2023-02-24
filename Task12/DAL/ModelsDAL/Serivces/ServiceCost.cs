using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelsDAL.Serivces
{
    public class ServiceCost
    {
        public int Id { get; set; }
        /// <summary>
        ///Year change cost
        /// </summary>
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
        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
    }
}
