using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EmployeeManagement.Models
{
    public class DepartmentModel
    {
        [Display(Name = "Department ID")]
        [Required(ErrorMessage = "Id is mandatory")]
        public int DepartmentID { get; set; } = 0;
        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string flag { get; set; } = "";
    }
}