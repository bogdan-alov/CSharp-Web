using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
	public enum ResourceType
	{
		Video = 1, Presentation = 2, Document = 3, Other = 4
	}

    public class Resource
    {
		[Key]
	    public int Id { get; set; }

		[Required]
	    public string Name { get; set; }

		[Required]
	    public ResourceType ResourceType { get; set; }

		[Required]
	    public string URL { get; set; }

	    public Course Course { get; set; }

	    public int CourseId { get; set; }

	    public ICollection<License> Licenses { get; set; }	= new List<License>();
    }
}
