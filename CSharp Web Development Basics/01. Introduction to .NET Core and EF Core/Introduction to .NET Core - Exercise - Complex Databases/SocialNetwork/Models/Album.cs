using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Models
{

	public enum Information
	{
		Public = 1, Private =2
	}
    class Album
    {
		[Key]
	    public int Id { get; set; }

		[Required]
	    public string Name { get; set; }

	    public string BackgroundColor { get; set; }

	    public Information  Information { get; set; }

	    public int UserId { get; set; }

	    public User User { get; set; }

	    public ICollection<AlbumPicture> Pictures { get; set; } = new List<AlbumPicture>();

	    public ICollection<TagAlbum> Tags { get; set; } = new List<TagAlbum>();
	}
}
