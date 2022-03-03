using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll
{
    public class Payroll
    {
        public string Worker { get; set; }
        public DateTime Period { get; set; }

        public List<PaymentInfo> PaymentsType = new List<PaymentInfo>();
    }
}
