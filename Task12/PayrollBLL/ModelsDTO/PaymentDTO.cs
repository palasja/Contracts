using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollBLL.ModelsDTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Period { get; set; }
        public string SP { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public double Summ { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
