using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace employee_web_api.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        public string Designation { get; set; }


        [Required(ErrorMessage = "Manager Name is required.")]
        public string ManagerName { get; set; }


        [Required(ErrorMessage = "Employee Type is required.")]
        public int EmployeeType { get; set; }


        public string Notes { get; set; }


        public byte[] Image { get; set; }

        public int DepartmentId { get; set; }
    }
}
