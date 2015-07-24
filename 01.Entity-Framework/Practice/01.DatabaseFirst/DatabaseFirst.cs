using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DatabaseFirst
{
    class DatabaseFirst
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindEntities())
            {
                var employees = context.Employees
                    .Where(e => e.FirstName == "Andrew")
                    .Select(e => e.Address);

                foreach (var e in employees)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }
}
