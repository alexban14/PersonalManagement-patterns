using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public string Profession { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Deduction> Deductions { get; set; } = new List<Deduction>();
    }
}