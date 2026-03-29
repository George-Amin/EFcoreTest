using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Models
{
    //[PrimaryKey(nameof(StdId), nameof(CrsId))]  
    internal class StudentsCourses
    {
        //[ForeignKey(nameof(Student))]
        public int StdId { get; set; }



        //[ForeignKey(nameof(Course))]
        public int CrsId { get; set; }


        public int? Grade { get; set; }
        // re
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!; 

    }
}
