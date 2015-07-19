using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Entity_Framework_Excercise
{
    class Program
    {
        static void Main()
        {
            //Step 1 - Employees with Salary Over 50 000
            using (var context = new SoftUniEntities())
            {
                var employees = context.Employees
                    .Where(emp => emp.Salary > 50000)
                    .Select(emp => emp.FirstName);

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }

            //Step 2 - Employees from Seattle
            using (var context = new SoftUniEntities())
            {
                var employees = context.Employees
                    .Where(emp => emp.Department.Name == "Research and Development")
                    .OrderBy(emp => emp.Salary)
                    .ThenByDescending(emp => emp.FirstName)
                    .Select(emp => new
                    {
                        emp.FirstName,
                        emp.LastName,
                        DepartmentName = emp.Department.Name,
                        emp.Salary
                    });

                foreach (var employee in employees)
                {
                    Console.WriteLine("{0} {1} from {2} - ${3:F2}",
                        employee.FirstName,
                        employee.LastName,
                        employee.DepartmentName,
                        employee.Salary);
                }
            }

            //Problem 4.	Adding a New Address and Updating Employee
            using (var context = new SoftUniEntities())
            {
                var address = new Address
                {
                    AddressText = "Vitoshka 14",
                    TownID = 4
                };

                var employee = context.Employees.First(e => e.LastName == "Nakov");
                
                employee.Address = address;

                context.SaveChanges();

                var nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

                Console.WriteLine(nakov.Address.AddressText);
            }

            //Problem 5.	Deleting Project by Id
            using (var context = new SoftUniEntities())
            {
                var project = context.Projects.Find(2);
                

                foreach (var employee in project.Employees)
                {
                    employee.Projects.Remove(project);
                }
                context.Projects.Remove(project);
                
                context.SaveChanges();
            }
        }
    }
}