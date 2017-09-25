using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Data;

namespace StudentSystem.Core
{
    public class Engine
    {
		private MyDbContext ctx = new MyDbContext();

	    public void Run()
	    {
		    ctx.Database.EnsureCreated();

		    Console.WriteLine("Success!");
	    }

	    public void ListAllStudentsAndHomeworks()
	    {

		    var students = ctx.Students.Include(c => c.Homeworks).ToList().Select(c=> new { Name = c.Name, Homeworks = c.Homeworks.Select(x=> new { Content = x.Content, ContentType = x.ContentType.ToString()}).ToList()});

		    foreach (var student in students)
		    {
			    Console.WriteLine(student.Name);
			    foreach (var homework in student.Homeworks)
			    {
				    Console.WriteLine($"Content: {homework.Content}, Content-type: {homework.ContentType}");
			    }
		    }
	    }

	    public void ListAllCoursesAndResources()
	    {
		    var courses = ctx.Courses.Include(c => c.Resources).OrderBy(c => c.StartDate).ThenByDescending(c => c.EndDate)
			    .ToList();

		    foreach (var course in courses)
		    {
			    Console.WriteLine($"{course.Name} {course.Description}");
			    Console.WriteLine("Resources:");
			    foreach (var resource in course.Resources)
			    {
				    Console.WriteLine($"{resource.Name} {resource.ResourceType} {resource.URL}");
			    }
		    }


	    }

	    public void ListAllCoursesWithMoreThan5Resources()
	    {
			var courses = ctx.Courses.Include(c => c.Resources).Where(c=> c.Resources.Count > 5).OrderByDescending(c=> c.Resources.Count).ThenByDescending(c=> c.StartDate)
			    .ToList();

		    foreach (var course in courses)
		    {
			    Console.WriteLine($"{course.Name} {course.Resources.Count}");
			    
		    }
		}

	    public void CalculateNumberOfCoursesForStudent()
	    {
		    var students = ctx.Students.Include(c => c.Courses).Where(c=> c.Courses.Count > 0).Select(c => new
		    {
			    Name = c.Name,
			    NumberCourses = c.Courses.Count,
			    TotalPrice = c.Courses.Sum(x => x.Course.Price),
			    AveragePice = c.Courses.Average(x => x.Course.Price)
		    }).ToList();


		    foreach (var student in students)
		    {
			    Console.WriteLine($"Name: {student.Name} Number of Courses: {student.NumberCourses} Total price: {student.TotalPrice} Average price: {student.AveragePice}");
		    }
	    }

	    public void ListAllCoursesWithResourcesAndLicenses()
	    {
		    var courses = ctx.Courses.Include(c => c.Resources).ThenInclude(c => c.Licenses).OrderByDescending(c=> c.Resources.Count).ThenBy(c=> c.Name).ToList();

		    foreach (var course in courses)
		    {
			    Console.WriteLine($"Course name: {course.Name}");

			    foreach (var resource in course.Resources.OrderByDescending(c=> c.Licenses.Count).ThenBy(c=> c.Name))
			    {
				    Console.WriteLine($"Resource: {resource.Name}");

				    if (resource.Licenses.Count > 0)
				    {
					    Console.WriteLine($"Licenses for this resource:");
					    foreach (var license in resource.Licenses)
					    {
						    Console.WriteLine($"{license.Name}");
					    }
				    }
			    }
		    }

	    }

	    public void ListAllStudentsWithTheirCoursesAndResources()
	    {
		    var students = ctx.Students.Include(c => c.Courses).ThenInclude(c => c.Course.Resources).ThenInclude(c=> c.Course.Resources.Select(x=> x.Licenses))
			    .OrderByDescending(c => c.Courses.Count).ThenBy(c => c.Name).ToList();

		    foreach (var student in students)
		    {
			    Console.WriteLine($"{student.Name} {student.Courses.Count} {student.Courses.Sum(c=> c.Course.Resources.Count)} {student.Courses.Sum(c=> c.Course.Resources.Sum(x=> x.Licenses.Count))}");
		    }
	    }
	}
}
