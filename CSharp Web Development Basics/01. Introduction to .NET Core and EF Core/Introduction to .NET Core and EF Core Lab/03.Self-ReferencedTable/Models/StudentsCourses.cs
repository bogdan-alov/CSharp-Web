using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Self_ReferencedTable
{
    public class StudentsCourses
    {
	    public int StudentId { get; set; }

	    public Student Student { get; set; }

	    public int CourseId { get; set; }

	    public Course Course { get; set; }
    }
}
