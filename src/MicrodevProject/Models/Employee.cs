using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicrodevProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = " نام و نام خانوادگی ")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "حقوق دریافتی ")]
        public decimal Salary { get; set; }
        public int? BossId { get; set; }
        public Employee Boss { get; set; }
        [Display(Name = "شرکت ")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
