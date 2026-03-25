using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public Address? Address { get; set; }

        #region Relationship
        public int DeptId { get; set; } // FK to the Department entity
        public Department Department { get; set; } = null!; // Navigation property for the department the employee belongs to


        public Department ManagedDepartment { get; set; } = null!; //Navigational Property To ManagerId In Department

        #endregion




    }
}
