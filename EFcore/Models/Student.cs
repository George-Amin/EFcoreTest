using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Models
{
    internal class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        //public StudentesCourses? StudentesCourses { get; set; }


        //public ICollection<Course> Courses { get; set; } = new HashSet<Course>(); // navigational property


        public ICollection<StudentsCourses> StudentsCourses { get; set; } = new HashSet<StudentsCourses>();
    }
}
