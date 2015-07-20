using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniDBFirst
{
    class DataAccessObject
    {
        public static void Add(Employee employee) 
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }
        public static void FindByKey(Object key)
        {
            using (var context = new SoftUniEntities())
            {
                var employee = context.Employees.Find(key);
                Console.WriteLine("{0} {1} - salary: {2}", employee.FirstName, employee.LastName, employee.Salary);
            }
        }
        public static void Modify(Employee employee) 
        {
            using (var context = new SoftUniEntities())
            {
                
            }
        }
    }
}
