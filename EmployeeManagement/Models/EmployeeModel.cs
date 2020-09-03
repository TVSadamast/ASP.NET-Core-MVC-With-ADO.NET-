using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee ID")]
        [Required(ErrorMessage = "Id is mandatory")]
        public int EmployeeID { get; set; } = 0;
        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string Name { get; set; } = "";
        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string Surname { get; set; } = "";
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string Address { get; set; } = "";
        [Required]
        public string Qualification { get; set; } = "";
        [Required]
        public string Contact { get; set; } = "";
        [Required]
        public string Department { get; set; } = "";
        public string flag { get; set; }
    }
}