using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StudentSystem.Models
{
	public enum ContentType
	{
		Application = 1, Pdf = 2, Zip = 3
	}

    public class Homework
    {
			
		[Key]
	    public int Id { get; set; }

		[Required]
	    public string Content { get; set; }

		[Required]
	    public ContentType ContentType { get; set; }

		[Required]
	    public DateTime SubmissionDate { get; set; }

		public Student Student { get; set; }

		public int StudentId { get; set; }

	    public Course Course { get; set; }

	    public int CourseId { get; set; }

	}

}
