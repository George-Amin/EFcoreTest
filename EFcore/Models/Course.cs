using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        //public ICollection<StudentsCourses> CoursesStudents { get; set; } = new HashSet<StudentsCourses>(); // navigation property

        public virtual ICollection<StudentsCourses> CoursesStudents { get; set; } = new HashSet<StudentsCourses>();

    }
}
