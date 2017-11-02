using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.GameApplication.Models
{
    public class Game
    {
	    public Game()
	    {
		    this.Users = new List<UserGame>();
	    }

	    public int Id { get; set; }

	    public string Title { get; set; }

	    public string Description { get; set; }

	    public string Thumbnail { get; set; }

	    public decimal Price { get; set; }

	    public double Size { get; set; }

	    public string YouTubeVideoUrl { get; set; }

	    public DateTime ReleaseDate { get; set; }

	    public List<UserGame> Users { get; set; }

    }
}
