using EFcore.DataSeeding;
using EFcore.DBContext;
using EFcore.Models;

namespace EFcore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();

            #region Data Seeding

            #region Manual Data Seeding

            Department Dept01 = new Department()
            {
                Name = "Test",
                DateOfCreation = new DateOnly(2024, 7, 25)
            };


            //dbContext.Set<Department>().Add(Dept01);




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

            //dbContext.Set<Department>().AddRange(ListOfDepts);

            dbContext.SaveChanges();
            #endregion

            #region Data Seeding Using Fluent API Migrations
            // in DepartmentConfiguratios class
            #endregion


            #region Dynamic DataSeeding

            //CompanyDbContextSeed.DataSeeding(dbContext);
            //chick if the operation is successful or not
            var Flag = CompanyDbContextSeed.DataSeeding(dbContext);
            if (Flag)
            {
                Console.WriteLine("Data Seeding is successful");
            }
            else
            {
                Console.WriteLine("Data Seeding is failed");
            }

            #endregion

            #endregion
        }

    }
}

