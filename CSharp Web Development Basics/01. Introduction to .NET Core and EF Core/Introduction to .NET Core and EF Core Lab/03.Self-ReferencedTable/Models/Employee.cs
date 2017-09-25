using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _03.Self_ReferencedTable
{
    public class Employee
    {
	    public int Id { get; set; }

		[Required]
		[MaxLength(50)]
	    public string Name { get; set; }

	    public int DepartmentId { get; set; }

	    public Department Department { get; set; }

	    public Employee Manager { get; set; }

	    public int ManagerId { get; set; }

	    public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
