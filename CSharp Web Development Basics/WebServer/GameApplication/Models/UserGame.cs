using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.GameApplication.Models
{
    public class UserGame
    {
	    public User User { get; set; }

	    public int UserId { get; set; }

	    public Game Game { get; set; }

	    public int GameId { get; set; }
	}
}
