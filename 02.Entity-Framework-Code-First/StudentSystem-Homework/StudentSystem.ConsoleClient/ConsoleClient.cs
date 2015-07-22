using System;
using System.Linq;
using System.Runtime.InteropServices;
using StudentSystem.Data;

namespace StudentSystem.ConsoleClient
{
    class ConsoleClient
    {
        static void Main()
        {
            using (var context = new StudentContext())
            {
                //Problem 3.	Working with the Database

                Console.WriteLine();
                Console.WriteLine("1. Lists all students and their homework submissions. Select only their names and for each homework - content and content-type");
                Console.WriteLine();

                var students = context.Students
                    .Select(s => new
                    {
                        s.Name,
                        homeworks = s.Homeworks.Select(h => new
                        {
                            h.Content,
                            h.ContentType
                        })
                    });

                foreach (var student in students)
                {
                    Console.WriteLine("--- Student: {0}", student.Name);

                    foreach (var homework in student.homeworks)
                    {
                        Console.WriteLine("Homework content: {0}, of type: {1}", homework.Content, homework.ContentType);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("2. List all courses with their corresponding resources. Select the course name and description and everything for each resource. Order the courses by start date (ascending), then by end date (descending).");
                Console.WriteLine();

                var courses = context.Courses
                    .OrderBy(c => c.StartDate)
                    .ThenByDescending(c => c.EndDate)
                    .Select(c => new
                    {
                        c.Name,
                        c.Description,
                        c.Resources
                    });

                foreach (var course in courses)
                {
                    Console.WriteLine("--- Course: {0}, description: {1}", course.Name, course.Description);

                    foreach (var resource in course.Resources)
                    {
                        Console.WriteLine("{0} - {1}, url: {2}", resource.Name, resource.ResourceType, resource.Url);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("3.	List all courses with more than 5 resources. Order them by resources count (descending), then by start date (descending). Select only the course name and the resource count.");
                Console.WriteLine();

                var coursesResources = context.Courses
                    .Where(c => c.Resources.Count() > 5)
                    .OrderByDescending(c => c.Resources.Count())
                    .ThenByDescending(c => c.StartDate)
                    .Select(c => new
                    {
                        c.Name,
                        ResourceCount = c.Resources.Count()
                    })
                    .ToList();

                coursesResources.ForEach(Console.WriteLine);

                Console.WriteLine();
                Console.WriteLine("4.	List all courses which were active on a given date (choose the date depending on the data seeded to ensure there are results), and for each course count the number of students enrolled. Select the course name, start and end date, course duration (difference between end and start date) and number of students enrolled. Order the results by the number of students enrolled (in descending order), then by duration (descending).");
                Console.WriteLine();

                var date = new DateTime(2015, 6, 22);
                var activeCouses = context.Courses
                    .Where(c => c.StartDate < date && c.EndDate >= date)
                    .ToList()
                    .OrderByDescending(c => c.Students.Count)
                    .ThenByDescending(c => (c.EndDate - c.StartDate).TotalDays)
                    .Select(c => new
                    {
                        c.Name,
                        c.StartDate,
                        c.EndDate,
                        StudentCount = c.Students.Count,
                        CurseDuration = (c.EndDate - c.StartDate).TotalDays
                    })
                    .ToList();

                activeCouses.ForEach(c =>
                {
                    Console.WriteLine("{0} [{1:dd-MM-yyyy} - {2:dd-MM-yyyy}]: {3} days, {4} students", c.Name,
                        c.StartDate, c.EndDate, c.CurseDuration, c.StudentCount);
                });

                Console.WriteLine();
                Console.WriteLine("5.	For each student, calculate the number of courses he/she has enrolled in, the total price of these courses and the average price per course for the student. Select the student name, number of courses, total price and average price. Order the results by total price (descending), then by number of courses (descending) and then by the student's name (ascending).");
                Console.WriteLine();

                var studentCourses = context.Students
                    .Select(s => new
                    {
                        s.Name,
                        NumberOfCourses = s.Courses.Count(),
                        TotalPrice = s.Courses.Sum(c => c.Price),
                        AveragePrice = (double) s.Courses.Sum(c => c.Price)/s.Courses.Count()
                    })
                    .OrderByDescending(s => s.TotalPrice)
                    .ThenByDescending(s => s.NumberOfCourses)
                    .ThenBy(s => s.Name)
                    .ToList();

                studentCourses.ForEach(Console.WriteLine);
            }
        }
    }
}