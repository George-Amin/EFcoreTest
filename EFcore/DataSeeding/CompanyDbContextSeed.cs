using EFcore.DBContext;
using EFcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFcore.DataSeeding
{
    public static class CompanyDbContextSeed
    {
        public static bool DataSeeding(CompanyDbContext DbContext)
        {
            try
            {
                if (!DbContext.Employees.Any())
                {
                    
                    //var Employees = File.ReadAllText("D:\\George\\Harsha\\EFcore\\EFcore\\DataSeeding\\employees.json");

                    var EmployeesData = File.ReadAllText("Files\\employees.json");

                    // JSON to List<Employee> (string) => serialization => List<Employee>

                    //serialization
                    var Employees = JsonSerializer.Deserialize<List<Employee>>(EmployeesData);

                    //if not null and count > 0 -- then add to database
                    if (Employees?.Count > 0)
                    {
                        //foreach (var EmpsItem in Employees)
                        //{
                        //    DbContext.Employees.Add(EmpsItem);
                        //}
                        
                        DbContext.AddRange(Employees);

                        DbContext.SaveChanges();
                    }

                return true;
                }
                else
                {
                    return true; // if data already exists, we can consider it as successful seeding
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
