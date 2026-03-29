using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFcore.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingInDeptTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DateOfCreation", "ManagerId", "Name" },
                values: new object[,]
                {
                    { 5, new DateOnly(2024, 7, 20), null, "Software" },
                    { 6, new DateOnly(2024, 7, 25), null, "Design" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 6);
        }
    }
} 
