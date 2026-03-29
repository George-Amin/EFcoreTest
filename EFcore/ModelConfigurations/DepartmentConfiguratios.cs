using EFcore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.ConfigurationClasses
{
    public class DepartmentConfiguratios : IEntityTypeConfiguration<Department>
    {

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(d => d.DeptId);

            builder.Property(d => d.DeptId).HasColumnName("DepartmentId");

            builder.Property(d => d.Name)
                     .HasMaxLength(50)
                     .IsRequired();

            builder.Property(d => d.DateOfCreation)
                   .HasAnnotation("DataType", "Date")
                   .HasDefaultValueSql("GETDATE()");


            builder.HasOne(d => d.Manager)
                .WithOne(e => e.ManagedDepartment)
                .HasForeignKey<Department>(d => d.ManagerId)
                .OnDelete(DeleteBehavior.NoAction)
                /*.IsRequired(true)*/;



            builder.HasMany(d => d.Employees)
                .WithOne(e => e.EmployeeDepartment)
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired(true);

            #region Data Seeding Using Fluent API Migrations

            // using migration should all data is seeded

            builder.HasData(

                 new Department()
                 {
                     DeptId = 5,
                     Name = "Software",
                     DateOfCreation = new DateOnly(2024, 7, 20)

                 },

                new Department()
                {
                    DeptId = 6,
                    Name = "Design",
                    DateOfCreation = new DateOnly(2024, 7, 25)

                }
            );



            #endregion




        }
    }
}
