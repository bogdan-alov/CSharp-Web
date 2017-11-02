using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using WebServer.GameApplication.Data;
using WebServer.GameApplication.Models;
using WebServer.GameApplication.Services.Interfaces;

namespace WebServer.GameApplication.Services
{
    public class GameService : IGameService
    {
	    public List<Game> ListAllGamesIndex()	
	    {
		    using (var ctx = new MyDbContext())
		    {
			    return ctx.Games.ToList();
		    }
	    }

	    public List<UserGame> ListAllUserGames(int id)
	    {
			using (var ctx = new MyDbContext())
			{
				return ctx.Users.FirstOrDefault(c => c.Id == id).Games;
			}
		}

    }
}
