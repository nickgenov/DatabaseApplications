using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.DatabaseFirstSoftuni
{
    class DatabaseFirstSoftuni
    {
        static void Main()
        {

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Where(e => e.FirstName == "John")
            //        .OrderBy(e => e.FirstName)
            //        .Select(e => e.Address.AddressText);
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var towns = context.Towns
            //        .Where(e => e.Name == "Calgary")
            //        .OrderBy(e => e.Name);

            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Where(e => e.JobTitle == "Design Engineer")
            //        .OrderBy(e => e.LastName)
            //        .Select(e => e.LastName);

            //    foreach (var e in employees)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var projects = context.Projects
            //        .Where(p => p.EndDate > new DateTime(1998, 10, 10))
            //        .Select(prj => new
            //        {
            //            Name = prj.Name,
            //            Employees = prj.Employees,
            //            StartDate = prj.StartDate,
            //            EndDate = prj.EndDate

            //        });

            //    foreach (var p in projects)
            //    {
            //        Console.WriteLine(p.Name);
            //        var employees = p.Employees;

            //        foreach (var e in employees)
            //        {
            //            Console.WriteLine("{0} {1} ({2})", e.FirstName, e.LastName, e.JobTitle);
            //        }
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = from e in context.Employees
            //                    where e.FirstName == "John"
            //                    select e.LastName;

            //    foreach (var e in employees)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Where(emp => emp.JobTitle == "Design Engineer")
            //        .Select(emp => new
            //        {
            //            emp.FirstName,
            //            emp.LastName,
            //            emp.JobTitle,
            //            emp.Salary
            //        });

            //    foreach (var e in employees)
            //    {
            //        Console.WriteLine("{0} {1} ({2}) - salary: {3}", e.FirstName, e.LastName, e.JobTitle, e.Salary);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Where(e => e.FirstName == "John")
            //        .Select(e => e.LastName)
            //        .ToList();

            //    foreach (var e in employees)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees.Select(e => e.FirstName).ToArray();

            //    Console.WriteLine(employees);

            //    Console.WriteLine(string.Join(", ", employees));
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Where(e => e.FirstName == "John")
            //        .Select(e => e.LastName)
            //        .FirstOrDefault();

            //    Console.WriteLine(employees);
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Where(e => e.FirstName == "John")
            //        .Select(e => e.LastName)
            //        .Take(10);

            //    foreach (var e in employees)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}

            //var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            //var evenNums = nums.Where(n => n % 2 == 0); //4, 6, 8

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees
            //        .Where(e => e.FirstName == "John")
            //        .Select(emp => new
            //        {
            //            emp.LastName
            //        })
            //        .ToList();

            //    Console.WriteLine(string.Join(", ", employees));
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var employees = context.Employees.Find(3);
            //    Console.WriteLine(employees.FirstName + " " + employees.LastName);
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var towns = context.Towns;

            //    Console.WriteLine(towns.ToString());
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var towns = context.Towns
            //        .Select(t => t.Name)
            //        .ToList();

            //    Console.WriteLine(towns.ToString());
            //}

            //using (var context = new SoftUniEntities())
            //{
            //    var address = new Address()
            //    {
            //        //CTRL + SPACE - hint for properties!
            //        AddressText = "Sofia address 12",
            //    };

            //    context.Addresses.Add(address);
            //    context.SaveChanges();
            //}

            using (var context = new SoftUniEntities())
            {
                var employee = context.Employees.First();

                Console.WriteLine(context.Entry(employee).State);
                employee.FirstName = "Stamat";

                Console.WriteLine(context.Entry(employee).State);

                context.SaveChanges();

                Console.WriteLine(context.Entry(employee).State);
            }
        }
    }
}
