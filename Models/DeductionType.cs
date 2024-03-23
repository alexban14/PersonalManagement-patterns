using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagement.Models
{
    public class DeductionType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Deduction> Deductions { get; set; }
    }
}
