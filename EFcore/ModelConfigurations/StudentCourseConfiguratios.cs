using EFcore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.ModelConfigurations
{
    public class StudentCourseConfiguratios : IEntityTypeConfiguration<Models.StudentsCourses>

    {
        public void Configure(EntityTypeBuilder<StudentsCourses> builder)
        {
            builder.ToTable("StudentsCourses");

            builder.HasKey(sc => new { sc.StdId, sc.CrsId });

            builder.HasOne(S => S.Student)
                .WithMany(ST=>ST.StudentsCourses)
                .HasForeignKey(S => S.StdId);


            builder.HasOne(C => C.Course)
                .WithMany(CR => CR.CoursesStudents)
                .HasForeignKey(C => C.CrsId);
        }
    }
}
