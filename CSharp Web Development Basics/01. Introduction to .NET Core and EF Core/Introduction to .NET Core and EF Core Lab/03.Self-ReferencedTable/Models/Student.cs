using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _03.Self_ReferencedTable
{
    public class Student
    {
	    public int Id { get; set; }

		[Required]
		[MaxLength(50)]
	    public string Name { get; set; }

	    public ICollection<StudentsCourses> Courses { get; set; } = new List<StudentsCourses>();
    }
}
