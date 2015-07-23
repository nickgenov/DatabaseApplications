using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics;
using EntityFramework.Extensions;

namespace ConsoleClient
{
    class Program
    {
        static void Main()
        {
            // // Test connection:

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Where(e => e.Department.Name == "Engineering")
            //        .Select(e => new
            //        {
            //            e.FirstName,
            //            e.LastName,
            //            Department = e.Department.Name
            //        });

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine("{0} {1} --- {2}", employee.FirstName, employee.LastName, employee.Department);
            //    }
            //}

            // // Multiple SQL Requests:

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees;

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine("{0} {1} {2}", employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            //    }
            //}


            // // A single SQL request
            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Select(e => new
            //        {
            //            e.LastName,
            //            Department = e.Department.Name,
            //            Town = e.Address.Town.Name
            //        });

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine("{0} {1} {2}", employee.LastName, employee.Department, employee.Town);
            //    }
            //}

            // Another way for the above, but less efficient:
            //using (var context = new SoftUniEntities())
            //{
            //    foreach (var employee in context.Employees
            //        .Include(e => e.Department)
            //        .Include(e => e.Address.Town))
            //    {
            //        Console.WriteLine("{0} {1} {2}", employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var towns = context.Towns
            //        .Select(t => new
            //        {
            //            t.Name,
            //            t.TownID
            //        });

            //    foreach (var town in towns)
            //    {
            //        Console.WriteLine("{0}, {1}", town.TownID, town.Name);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .OrderByDescending(e => e.FirstName)
            //        .Take(3);

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine("name: {0} department: {1} town: {2}",
            //            employee.LastName,
            //            employee.Department.Name,
            //            employee.Address.Town.Name);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .OrderByDescending(e => e.LastName)
            //        //YOU CAN ONLY INCLUDE WHOLE TABLES!
            //        .Include(e => e.Department)
            //        .Include(e => e.Address.Town)
            //        .Take(3);

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine("name: {0} department: {1} town: {2}",
            //            employee.LastName,
            //            employee.Department.Name,
            //            employee.Address.Town.Name);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .OrderByDescending(e => e.LastName)
            //        .Include(e => e.Department)
            //        .Include(e => e.Address.Town)
            //        .Take(3)
            //        .Select(e => new
            //        {
            //            e.LastName,
            //            Department = e.Department.Name,
            //            Town = e.Address.Town.Name
            //        });

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine("name: {0} department: {1} town: {2}",
            //            employee.LastName,
            //            employee.Department,
            //            employee.Town);
            //    }
            //}


            // //Correct use of .ToList()
            //using (var context = new SoftUniEntities())
            //{
            //    var employeesFromRedmond = context.Employees
            //        .Where(e => e.Address.Town.Name == "Redmond")
            //        .Select(e => new
            //        {
            //            e.FirstName,
            //            e.LastName,
            //            e.JobTitle,
            //            e.Address.AddressText
            //        })
            //        .OrderBy(e => e.LastName)
            //        .ToList();

            //    foreach (var emp in employeesFromRedmond)
            //    {
            //        Console.WriteLine("{0} {1} ({2}), address: {3}", emp.FirstName, emp.LastName, emp.JobTitle, emp.AddressText);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employeesFromCalgary = context.Employees

            //        //INCORRECT, SHOULD BE AT THE END!!!
            //        .ToList()

            //        .Where(e => e.Address.Town.Name == "Calgary")
            //        .Select(e => new
            //        {
            //            e.FirstName,
            //            e.LastName,
            //            e.JobTitle,
            //            e.Address.AddressText
            //        })
            //        .OrderBy(e => e.LastName);

            //    foreach (var emp in employeesFromCalgary)
            //    {
            //        Console.WriteLine("{0} {1} ({2}), address: {3}", emp.FirstName, emp.LastName, emp.JobTitle, emp.AddressText);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    decimal totalSalaries = 0;

            //    foreach (var salary in context.Employees
            //    {
            //        totalSalaries += salary;
            //    }

            //    Console.WriteLine("{0:F2}", totalSalaries);
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    decimal totalSalaries = 0;

            //    foreach (var salary in context.Employees
            //        .Select(e => e.Salary))
            //    {
            //        totalSalaries += salary;
            //    }

            //    Console.WriteLine("{0:F2}", totalSalaries);
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var totalSalaries = context.Employees
            //        .Sum(e => e.Salary);

            //    var avgSalaries = context.Employees
            //        .Average(e => e.Salary);

            //    Console.WriteLine("Total salaries: {0:F2}", totalSalaries);
            //    Console.WriteLine("Average salary: {0:F2}", avgSalaries);
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employeesProjects = context.Employees
            //        .Where(e => e.Address.Town.Name == "Redmond")
            //        .Select(e => new
            //        {
            //            e.FirstName,
            //            e.LastName,
            //            Town = e.Address.Town.Name,
            //            Department = e.Department.Name,
            //            Manager = e.Manager.LastName,
            //            Projects = e.Projects.Select(p => new
            //            {
            //                Project = p.Name,
            //                p.Description,
            //                AvgSalary = p.Employees.Average(emp => emp.Salary)
            //            })
            //        })
            //        .Take(10)
            //        .OrderByDescending(e => e.Department)
            //        .ToList();

            //    foreach (var emp in employeesProjects)
            //    {
            //        Console.WriteLine("----- {0} {1} from {2}, department: {3}, manager: {4}", emp.FirstName, emp.LastName, emp.Town, emp.Department, emp.Manager);

            //        foreach (var project in emp.Projects)
            //        {
            //            Console.WriteLine("{0}, average employee salary: {1}", project.Project, project.AvgSalary);
            //        }
            //    }
            //}

            // UPDATING Entities in EF
            //using (var context = new SoftUniEntities())
            //{
            //    var timer = new Stopwatch();

            //    timer.Start();
            //    EfStandartUpdate(context);
            //    Console.WriteLine("EF query: {0}", timer.Elapsed); //00:00:00.2239094

            //    timer.Restart();

            //    timer.Start();
            //    NativeUpdate(context);
            //    Console.WriteLine("Native query: {0}", timer.Elapsed); //00:00:00.0046463
            //}

            // UPDATING Entities with EF Extensions
            //using (var context = new SoftUniEntities())
            //{
            //    context.Employees
            //        .Where(e => e.FirstName == "Jacomo")
            //        .Update(e => new Employee()
            //        {
            //            FirstName = "Roberto"
            //        });

            //    context.SaveChanges();
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    context.Employees
            //        .Update(e => new Employee()
            //        {
            //            Salary = 600000
            //        });

            //    context.SaveChanges();
            //}

            // DELETING WITH EF Extensions
            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Where(e => e.Address.Town.Name == "Sofia")
            //        .Select(e => new
            //        {
            //            e.FirstName,
            //            e.LastName,
            //            Address = e.Address.AddressText,
            //            Town = e.Address.Town.Name
            //        });

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine("{0} {1} --- {2}, {3}", employee.FirstName, employee.LastName, employee.Address, employee.Town);
            //    }

            //    context.Employees
            //        .Where(e => e.Address.Town.Name == "Sofia")
            //        .Delete();

            //    context.SaveChanges();
            //}

            // Comparing the three different update methods Speed:
            //using (var context = new SoftUniEntities())
            //{
            //    var employeesCount = context.Employees.Count();
            //    Console.WriteLine("Number of employees: {0}", employeesCount);

            //    Stopwatch timer = new Stopwatch();
                
            //    timer.Start();
            //    EfStandartUpdate(context);
            //    Console.WriteLine("EF Standard update: {0}", timer.Elapsed);

            //    timer.Restart();
            //    EfExtensionsUpdate(context);
            //    Console.WriteLine("EF Extensions update: {0}", timer.Elapsed);

            //    timer.Restart();
            //    NativeUpdate(context);
            //    Console.WriteLine("Native update: {0}", timer.Elapsed);

            //}

            //Add a Base64 Encoded image to the database:
            using (var context = new SoftUniEntities())
            {
                for (int i = 0; i < 10000; i++)
                {
                    context.Images.Add(new Image()
                    {
                        ImageBase64 = new string('-', 5) + i
                    });
                }
                context.SaveChanges();

                var imageCount = context.Images.Count();
                Console.WriteLine(imageCount);

                var timer = new Stopwatch();
                timer.Start();

                EfStandartDelete(context);
                Console.WriteLine("EF Standard delete: {0}", timer.Elapsed);
                timer.Restart();

                EfExtensionsDelete(context);
                Console.WriteLine("EF Extensions delete: {0}", timer.Elapsed);
                timer.Restart();

                NativeDelete(context);
                Console.WriteLine("Native delete: {0}", timer.Elapsed);
                timer.Restart();
            }
        }

        private static void EfStandartUpdate(SoftUniEntities context)
        {
            var employees = context.Employees;

            foreach (var employee in employees)
            {
                employee.Salary = 520000;
            }
            context.SaveChanges();
        }
        private static void EfExtensionsUpdate(SoftUniEntities context)
        {
            context.Employees
                .Update(e => new Employee()
                {
                    Salary = 850000
                });
            context.SaveChanges();
        }
        private static void NativeUpdate(SoftUniEntities context)
        {
            var query = @"UPDATE Employees SET Salary = 250000";
            context.Database.ExecuteSqlCommand(query);
            context.SaveChanges();
        }
        private static void EfStandartDelete(SoftUniEntities context)
        {
            var images = context.Images
                .Where(i => i.ImageBase64.EndsWith("5"));
            foreach (var image in images)
            {
                context.Images.Remove(image);
            }
            context.SaveChanges();
        }
        private static void EfExtensionsDelete(SoftUniEntities context)
        {
            context.Images
                .Where(i => i.ImageBase64.EndsWith("6"))
                .Delete();
            context.SaveChanges();
        }
        private static void NativeDelete(SoftUniEntities context)
        {
            var query = @"DELETE FROM Images WHERE Images.ImageBase64 LIKE '%3'";
            context.Database.ExecuteSqlCommand(query);
            context.SaveChanges();
        }
    }
}