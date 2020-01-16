using MicrodevProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MicrodevProject.ViewModels
{
    public class EmployeeViewModel
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
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
