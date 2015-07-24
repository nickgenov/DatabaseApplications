using System;
using System.Data.Entity.Core;
using System.Linq;

namespace SoftUniDatabaseFirst
{
    public class DataAccessObject
    {
        public static void Add(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                Console.WriteLine("Employee added");
            }
        }

        public static Employee FindByKey(object key)
        {
            using (var context = new SoftUniEntities())
            {
                var employee = context.Employees.Find(key);
                if (employee == null)
                {
                    throw new ObjectNotFoundException("Employee not found");
                }
                return employee;
            }
        }

        public static void Modify(Employee employee, string name)
        {
            using (var context = new SoftUniEntities())
            {
                var emp = context.Employees.Find(employee.EmployeeID);

                emp.FirstName = name;
                context.SaveChanges();
                Console.WriteLine("FirstName changed");
            }
        }

        public static void Delete(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                var emp = context.Employees.Find(employee.EmployeeID);

                var projects = emp.Projects;
                while (projects.Count > 0)
                {
                    emp.Projects.Remove(projects.First());
                }

                context.Employees.Remove(emp);
                context.SaveChanges();
                Console.WriteLine("Employee deleted");
            }
        }
    }
}