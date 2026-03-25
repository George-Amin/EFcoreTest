using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Models
{
    internal class StudentesCourses
    {
        public int? StdId { get; set; }
        public int? CrsId { get; set; }
        public int? Grade { get; set; }

/*        public ICollection<Student> StudentsId { get; set; }
        public ICollection<Course> CoursesId { get; set; }
*/
    }
}
