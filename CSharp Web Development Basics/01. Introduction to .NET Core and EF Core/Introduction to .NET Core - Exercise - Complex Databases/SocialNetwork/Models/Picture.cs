using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Models
{
    class Picture
    {
		[Key]
	    public int Id { get; set; }

		[Required]
	    public string Title { get; set; }

	    public string Caption { get; set; }

	    public string Path { get; set; }

	    public ICollection<AlbumPicture> Albums { get; set; } = new List<AlbumPicture>();
    }
}
