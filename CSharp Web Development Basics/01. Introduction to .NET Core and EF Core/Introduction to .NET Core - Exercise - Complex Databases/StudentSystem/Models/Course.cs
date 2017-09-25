using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Models
{
    public class Course
    {
		[Key]
	    public int Id { get; set; }

		[Required]
	    public string Name { get; set; }

	    public string Description { get; set; }

		[Required]
	    public DateTime StartDate { get; set; }

		[Required]
	    public DateTime EndDate { get; set; }

		[Required]
	    public decimal Price { get; set; }

	    public ICollection<Resource> Resources { get; set; } = new List<Resource>();

	    public ICollection<StudentCourse> Students { get; set; } = new List<StudentCourse>();

	    public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}
