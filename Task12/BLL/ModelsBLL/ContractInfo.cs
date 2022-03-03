using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsBLL
{
    public class ContractInfo
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<SoftwareForInfo> SoftwareForInfo { get; set; }
        public ICollection<HardwareForInfo> HardwareForInfo { get; set; }

    }
}
