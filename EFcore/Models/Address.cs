using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Models
{
        //[Owned]
    public class Address
    {
        public string? Country{ get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }

        public Employee? EmployeesAddress { get; set; }

    }
}
