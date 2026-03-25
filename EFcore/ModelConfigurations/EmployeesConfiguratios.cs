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
    internal class EmployeesConfiguratios : IEntityTypeConfiguration<Employee>

    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");


          
            builder.HasKey(e => e.EmpId);
           
            builder.Property(e => e.EmpId).HasColumnName("EmployeeID").IsRequired(true);
         

            builder.Property(e => e.Name).HasMaxLength(100);
           
            builder.OwnsOne(A => A.Address);


            //builder.HasOne(E => E.Department)
            //    .WithMany(D => D.Employees)
            //    .HasForeignKey(e => e.DeptId); // one to many relationship between Employee and Department
            builder.HasOne(e => e.Department)      // Employee has one Dept (workplace)
    .WithMany(d => d.Employees)     // Dept has many Employees (staff)
    .HasForeignKey(e => e.DepartmentId)
    .OnDelete(DeleteBehavior.Restrict); // Prevent accidental deletions
        }
    }
}


