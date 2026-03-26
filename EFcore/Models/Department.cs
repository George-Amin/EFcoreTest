using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Models
{
    public class Department
    {
        public int DeptId { get; set; }
        public string Name { get; set; }

        public DateOnly DateOfCreation { get; set; }

        #region Relationship 
        // Navigation property to represent the one-to-many relationship with Employees.


        public int ManagerId { get; set; } // FK

        public Employee Manager { get; set; } = null!; // Navigation property for the manager of the department

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>(); // Navigation property for the employees in the department

        #endregion





    }
}
