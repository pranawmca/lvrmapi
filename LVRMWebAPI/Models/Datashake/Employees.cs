using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Models.Datashake
{
    public class Employees
    {
        [Key]
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
