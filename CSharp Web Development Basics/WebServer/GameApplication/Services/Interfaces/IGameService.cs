using System;
using System.Collections.Generic;
using System.Text;
using WebServer.GameApplication.Models;

namespace WebServer.GameApplication.Services.Interfaces
{
    public interface IGameService
    {
	    List<Game> ListAllGamesIndex();

	    List<UserGame> ListAllUserGames(int id);

    }
}
