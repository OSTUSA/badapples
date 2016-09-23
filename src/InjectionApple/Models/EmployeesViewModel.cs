using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BadApples.Model;

namespace InjectionApple.Models
{
    public class EmployeesViewModel
    {
        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
