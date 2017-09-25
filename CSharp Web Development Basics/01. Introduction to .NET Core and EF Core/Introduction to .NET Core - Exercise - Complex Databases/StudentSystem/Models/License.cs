using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class License
    {
		[Key]
	    public int Id { get; set; }

	    public string Name { get; set; }


	    public Resource Resource { get; set; }

	    public int ResourceId { get; set; }
    }
}
