using System;
using System.Collections.Generic;

namespace PayrollBLL.ModelsDTO
{
    public class PayrollDTO
    {
        public int Id { get; set; }
        public string Worker { get; set; }
        public DateTime Period { get; set; }
        public double Accrued { get; set; }
        public double Withheld { get; set; }
        public double Natural { get; set; }
        public double Paid { get; set; }
        public bool isShowDetail { get; set; } = false;
        public ICollection<PaymentDTO> Payments { get; set; } = new List<PaymentDTO>();
        public LoadedFileDTO File { get; set; }
    }
}
