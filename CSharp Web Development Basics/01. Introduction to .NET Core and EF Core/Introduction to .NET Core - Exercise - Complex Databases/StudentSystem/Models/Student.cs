using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Models
{
    public class Student
    {
		[Key]
	    public int Id { get; set; }

		[Required]
	    public string Name { get; set; }

	    public string PhoneNumber { get; set; }

		[Required]
	    public DateTime RegistrationDate { get; set; }

	    public DateTime BirthDay { get; set; }

	   public ICollection<StudentCourse> Courses { get; set; } = new List<StudentCourse>();

	    public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}
