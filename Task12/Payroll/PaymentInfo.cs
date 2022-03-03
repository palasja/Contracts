using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll
{
    public class PaymentInfo
    {
        public string Type { get; set; }
        public string ResultName { get; set; }
        public double ResultSumm { get; set; }
        public List<Payment> Payments = new List<Payment>();
    }
}
