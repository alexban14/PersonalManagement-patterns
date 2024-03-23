using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Models
{
    public class Deduction
    {
        public int ID { get; set; }
        public string DeductionType { get; set; }
        public int Sum { get; set; }
        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }
    }
}