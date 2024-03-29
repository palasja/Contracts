﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollDAL.ModelsDAL
{
    public class Payroll
    {
        public int Id { get; set; }
        public string Worker { get; set; }
        public DateTime Period { get; set; }
        public double Accrued { get; set; }
        public double Withheld { get; set; }
        public double Natural { get; set; }
        public double Paid { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public LoadedFile File{ get; set; }
    }
}
