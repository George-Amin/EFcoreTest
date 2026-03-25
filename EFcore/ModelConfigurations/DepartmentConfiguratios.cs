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

            //builder.HasMany(d => d.Employees)
            //       .WithOne(e => e.Department); // One-to-many relationship between Department and Employee

            //builder.HasOne(d=>d.Employee)
            //    .WithOne(e=>e.Department)
            //    .HasForeignKey<Department>(d => d.ManagerId)
            //       .OnDelete(DeleteBehavior.NoAction); // One-to-one relationship between Department and Employee for the Manager     
            builder.HasOne(d => d.Manager)              // Dept has one Manager
        .WithOne(e => e.ManagedDepartment)   // Employee manages one Dept
        .HasForeignKey<Department>(d => d.ManagerId); // FK is in Department table

        }
    }
}
