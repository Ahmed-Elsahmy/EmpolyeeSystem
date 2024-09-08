using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.DAl.Entities
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
