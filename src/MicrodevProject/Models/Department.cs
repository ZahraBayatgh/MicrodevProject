using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicrodevProject.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = " نام شرکت ")]
        public string Name { get; set; }
    }
}
