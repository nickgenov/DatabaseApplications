﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SoftUniDatabaseFirst
{
    class AllProblems
    {
        static void Main()
        {
            //Problem 2. Employee DAO Class

            using (var context = new SoftUniEntities())
            {
                Employee employee = new Employee()
                {
                    FirstName = "Ivan",
                    LastName = "Stamatov",
                    JobTitle = "Accountant",
                    DepartmentID = 2,
                    HireDate = new DateTime(2015, 2, 15),
                    Salary = 2000,
                };

                //1. Insert an employee:

                DataAccessObject.Add(employee);

                //2. Print his/her primary key generated by the DB:

                Console.WriteLine(employee.EmployeeID);

                //3. Change the employee first name and save it to the database:

                DataAccessObject.Modify(employee, "Kiril");

                //4. Deletes an employee

                DataAccessObject.Delete(employee);
            }

            //Problem 3.    Database Search Queries

            //1.	Find all employees who have projects started in the time period 2001 - 2003 (inclusive). Select each employee's first name, last name and manager name and each of their projects' name, start date, end date.

            using (var context = new SoftUniEntities())
            {
                var projects = context.Projects
                    .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        Project = p.Name,
                        Start = p.StartDate,
                        End = p.EndDate,
                        p.Employees
                    });

                foreach (var project in projects)
                {
                    Console.WriteLine("--{0}", project.Project);
                    var employees = project.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.Manager
                        });
                    foreach (var employee in employees)
                    {
                        Console.WriteLine("{0} {1}, manager: {2}", employee.FirstName, employee.LastName, employee.Manager.FirstName + " " + employee.Manager.LastName);
                    }
                }
            }

            //2.	Find all addresses, ordered by the number of employees who live there (descending), then by town name (ascending). Take only the first 10 addresses and select their address text, town name and employee count. 

            using (var context = new SoftUniEntities())
            {
                var addresses = context.Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .Take(10)
                    .Select(a => new
                    {
                        Address = a.AddressText,
                        Town = a.Town.Name,
                        EmployeeCount = a.Employees.Count
                    });

                foreach (var address in addresses)
                {
                    Console.WriteLine("{0}, {1} - {2} employees", address.Address, address.Town, address.EmployeeCount);
                }
            }

            //3.	Get an employee by id (e.g. 147). Select only his/her first name, last name, job title and projects (only their names). The projects should be ordered by name (ascending).

            using (var context = new SoftUniEntities())
            {
                var employee = context.Employees
                    .Where(e => e.EmployeeID == 147)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                        Projects = e.Projects.Select(p => new
                        {
                            p.Name
                        })
                            .OrderBy(p => p.Name)
                    })
                    .FirstOrDefault();

                Console.WriteLine("{0} {1} ({2}) --projects: {3}", employee.FirstName, employee.LastName, employee.JobTitle, string.Join(", ", employee.Projects));
            }

            //4.	Find all departments with more than 5 employees. Order them by employee count (ascending). Select the department name, manager name and first name, last name, hire date and job title of every employee.

            using (var context = new SoftUniEntities())
            {
                var departments = context.Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .Select(d => new
                    {
                        DepartmentName = d.Name,
                        ManagerName = context.Employees
                            .Where(e => e.EmployeeID == d.ManagerID)
                            .Select(e => e.LastName)
                            .FirstOrDefault(),
                        Employees = d.Employees
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.HireDate,
                                e.JobTitle
                            })
                    });

                Console.WriteLine(departments.Count());

                foreach (var department in departments)
                {
                    Console.WriteLine("---{0} - Manager: {1}, Employees: {2}",
                        department.DepartmentName,
                        department.ManagerName,
                        department.Employees.Count());
                }
            }

            //Problem 4.	Native SQL Query

            using (var context = new SoftUniEntities())
            {
                var sw = new Stopwatch();
                sw.Start();

                PrintNamesWithNativeQuery(context);
                Console.WriteLine("Native: {0}", sw.Elapsed);

                sw.Restart();

                PrintNamesWithLinqQuery(context);
                Console.WriteLine("Linq: {0}", sw.Elapsed);
            }

            //Problem 5.	Concurrent Database Changes with EF

            var context1 = new SoftUniEntities();
            var context2 = new SoftUniEntities();

            var employee1 = context1.Employees.Find(1);
            employee1.FirstName = "Pesho";

            var employee2 = context2.Employees.Find(1);
            employee2.FirstName = "Gosho";

            //First name is changed to Pesho
            context1.SaveChanges();

            //First name is changed to Gosho and Pesho is gone
            context2.SaveChanges();

            context1.Dispose();
            context2.Dispose();

            //with FIXED concurrency mode, the second transaction fails
            //the name is Pesho, not Gosho

            //Problem 6.	Call a Stored Procedure

            using (var context = new SoftUniEntities())
            {
                var employees = context.udp_get_full_names();

                foreach (var emp in employees)
                {
                    Console.WriteLine(emp);   
                }

            }
        }
        public static void PrintNamesWithNativeQuery(SoftUniEntities context)
        {
            var query =
                    @"SELECT E.FirstName
                        FROM Employees E
                    INNER JOIN EmployeesProjects EP 
	                    ON EP.EmployeeID = E.EmployeeID
                    INNER JOIN Projects P 
	                    ON P.ProjectID = EP.ProjectID
                    WHERE DATEPART(YEAR, P.StartDate) = 2002";

            var employees = context.Database.SqlQuery<List<string>>(query).ToList();

            //commented for accurate measurements
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //Console.WriteLine(employees.Count);
        }

        public static void PrintNamesWithLinqQuery(SoftUniEntities context)
        {
            var employees = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate >= new DateTime(2002, 1, 1) &&
                              p.StartDate <= new DateTime(2002, 12, 31)))
                .Select(e => e.FirstName)
                .ToList();

            //commented for accurate measurements
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //Console.WriteLine(employees.Count);
        }
    }
}