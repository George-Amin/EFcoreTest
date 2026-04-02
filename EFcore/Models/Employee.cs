using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public  string? Email { get; set; }

        public required string PhoneNumber { get; set; }
        public string? Password { get; set; }
        public Address EmpAddress { get; set; }

        #region Relationship
        [ForeignKey(nameof(DepartmentId))]
        public int? DepartmentId { get; set; } // FK to the Department entity
        public virtual Department EmployeeDepartment { get; set; } = null!; // Navigation property for the department the employee belongs to


        public virtual Department? ManagedDepartment { get; set; } = null!; //Navigational Property To ManagerId In Department

        #endregion




    }
}
