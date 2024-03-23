using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Models
{
    public class Deduction
    {
        public int ID { get; set; }
        public int Sum { get; set; }
        public int EmployeeID { get; set; }
        public int DeductionTypeID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual DeductionType DeductionType { get; set; }
    }
}