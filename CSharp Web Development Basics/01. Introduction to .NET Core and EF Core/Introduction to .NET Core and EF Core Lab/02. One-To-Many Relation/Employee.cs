﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _02.One_To_Many_Relation
{
    public class Employee
    {
	    public int Id { get; set; }

		[Required]
		[MaxLength(50)]
	    public string Name { get; set; }

	    public int DepartmentId { get; set; }

	    public Department Department { get; set; }
    }
}
