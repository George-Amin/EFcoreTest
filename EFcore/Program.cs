using EFcore.DataSeeding;
using EFcore.DBContext;
using EFcore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFcore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();


            //var updateEmp = dbContext.Employees.Update(nameof())
            //dbContext.Employees.FirstOrDefault(E => E.EmpId == 9).DepartmentId = 8;
            //dbContext.SaveChanges();
            #region Data Seeding

            #region Manual Data Seeding
            /*
                        Department Dept01 = new Department()
                        {
                            Name = "Test",
                            DateOfCreation = new DateOnly(2024, 7, 25)
                        };
            */

            //dbContext.Set<Department>().Add(Dept01);


            /*

                        List<Department> ListOfDepts = new()
                        {
                            new Department()
                            {
                                Name = "HR",
                                DateOfCreation = new DateOnly(2024, 7, 25)
                            },
                            new Department()
                            {
                                Name = "Finance",
                                DateOfCreation = new DateOnly(2024, 7, 25)
                            },
                            new Department()
                            {
                                Name = "Admin",
                                DateOfCreation = new DateOnly(2024, 7, 25)
                            }
                        };
            */
            //dbContext.Set<Department>().AddRange(ListOfDepts);

            //dbContext.SaveChanges();
            #endregion

            #region Data Seeding Using Fluent API Migrations
            // in DepartmentConfiguratios class
            #endregion


            #region Dynamic DataSeeding

            //CompanyDbContextSeed.DataSeeding(dbContext);
            //chick if the operation is successful or not
            //var Flag = CompanyDbContextSeed.DataSeeding(dbContext);
            //if (Flag)
            //{
            //    Console.WriteLine("Data Seeding is successful");
            //}
            //else
            //{
            //    Console.WriteLine("Data Seeding is failed");
            //}

            #endregion

            #endregion


            #region Loading Related Data

            #region Default (old Way)

            /*
            var Emp01 = dbContext.Employees.FirstOrDefault(E => E.EmpId == 9);


            if (Emp01 is null)
            {
                // is null
                Console.WriteLine("Employee not found");
            }
            else
            {
                // is not null
                Console.WriteLine($"Employee Name: {Emp01.EmpName}");
                Console.WriteLine($"Employee Name: {Emp01.DepartmentId}");
                //Console.WriteLine($"Department Name: {Emp01.EmployeeDepartment?.Name}"); // Related data is loaded using Navigation Property

                var EmpDept = (from DeptName in dbContext.Set<Department>()
                              where DeptName.DeptId == Emp01.DepartmentId
                              select DeptName.Name).FirstOrDefault();

                Console.WriteLine($"Department Name: {EmpDept}");
                #endregion
            }
            */


            #endregion

            #region Eager Loading -- > using Include() method
            /*
             it s like a (join) in SQL, it will load the related data in one query,
             it is more efficient than lazy loading,
             but it will load all the related data even if we don't need it,
             so we should use it when we need to load all the related data.  
            */


            /*
            var Emp01 = dbContext.Employees.Include(D => D.EmployeeDepartment).FirstOrDefault(E => E.EmpId == 9);

            if (Emp01 is not null)
            {
                Console.WriteLine("Employee Name : " + Emp01.EmpName);
                Console.WriteLine("Employee Department : " + Emp01.EmployeeDepartment.Name);
            }
            */


            // get all employees with their managed departments


            //var managersEmps = dbContext.Employees.Include(D => D.ManagedDepartment).FirstOrDefault(d=>d.EmpId ==9);

            //if(managersEmps is not null)
            //{
            //    Console.WriteLine($" Employee Name : {managersEmps.EmpName}");
            //    Console.WriteLine($" Department Id : {managersEmps.ManagedDepartment?.DeptId}");
            //    Console.WriteLine($" Department Name : {managersEmps.ManagedDepartment?.Name}");

            //}




            #endregion

            #region Eager Loading -- > using ThenInclude() method

            //Emp with his department and the department manager

            /*
            var Emp = dbContext.Employees
                .Include(D => D.EmployeeDepartment)
                .ThenInclude(D => D.Manager)
                .FirstOrDefault(E => E.EmpId == 9);


            if (Emp != null)
            {
                Console.WriteLine($"Employee Name : {Emp.EmpName}");
                Console.WriteLine($"work in Department Id : {Emp.DepartmentId}");
                Console.WriteLine($"Manager of Department Name : {Emp.EmployeeDepartment?.Name} And Dept Id is : {Emp.EmployeeDepartment?.DeptId}");
                Console.WriteLine($"Manger Id : {Emp.EmployeeDepartment?.Manager?.EmpId}");
                Console.WriteLine($"Manger Name : {Emp.EmployeeDepartment?.Manager?.EmpName}");
     

            }

            */
            #endregion

            #region Loading Related Data - Explicit Loading

            #region EX01
            /*
                       var Emp =  dbContext.Employees.FirstOrDefault(E => E.EmpId == 9);

                       if(Emp != null)
                       {
                           Console.WriteLine($"Employee Name : {Emp.EmpName}");
                           Console.WriteLine($"work in Department Id : {Emp.DepartmentId}");
                           dbContext.Entry(Emp).Reference(D => D.EmployeeDepartment).Load(); // it will load the related data in a separate query, it is more efficient than eager loading, but it will load the related data only when we need it, so we should use it when we need to load the related data.
                           Console.WriteLine($"work in Department Name : {Emp.EmployeeDepartment.Name}"); // Unhandled exception.// related data is not loaded yet, so it will throw an exception


                       }
           */


            #endregion


            #region EX02


            // get the department with its employees    
            var Dept = dbContext.Set<Department>().FirstOrDefault(D => D.DeptId == 8);
            if (Dept != null)
            {
                Console.WriteLine($"Employess work in {Dept.Name}");
                // use collection navigation property to load the related data
                dbContext.Entry(Dept).Collection(E => E.Employees).Query().Where(e=>e.Age > 25).Load(); // it will load the related data in a separate query.
                foreach (var item in Dept.Employees)
                {
                    Console.WriteLine(item.EmpName);
                }

            }

            #endregion
            #endregion


            #region Lazy Loading -- > using Navigation Properties


            #endregion


            #endregion
        }
    }
}

