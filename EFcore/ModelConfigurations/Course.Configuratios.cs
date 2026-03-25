using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.ModelConfigurations
{
    internal class Course : IEntityTypeConfiguration<Models.Course>
    {
        public void Configure(EntityTypeBuilder<Models.Course> builder)
        {
            builder.ToTable("Courses");
        }
    }
}
