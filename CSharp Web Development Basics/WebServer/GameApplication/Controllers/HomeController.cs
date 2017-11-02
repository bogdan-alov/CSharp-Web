using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServer.GameApplication.Data;
using WebServer.GameApplication.Models;
using WebServer.GameApplication.Services;
using WebServer.GameApplication.Services.Interfaces;
using WebServer.GameApplication.Views;
using WebServer.Server.Enums;
using WebServer.Server.HTTP;
using WebServer.Server.HTTP.Contracts;
using WebServer.Server.HTTP.Response;

namespace WebServer.GameApplication.Controllers
{
    public class HomeController
    {
	    private IUserService userService;
	    private IGameService gameService;
	    private const string loggedUser = "logged-user";
	    private const string loggedAdmin = "logged-admin";
	    private const string guest = "guest";

	    public HomeController()
	    {
		    this.userService = new UserService();
			this.gameService = new GameService();
	    }

	    public IHttpResponse Index(IHttpContext ctx)
	    {
		    var req = ctx.Request;
		    var queryParameters = ctx.Request.QueryParameters;
		    var view = new HomeIndexView();
		    view.AllGames = gameService.ListAllGamesIndex(); ;
			if (queryParameters.Any())
		    {
				if (queryParameters["filter"] == "Owned")
				{
					var id = (int)req.Session.Get("UserId");
					var user = userService.FindUser(id);
					return new ViewResponse(HttpStatusCode.OK, new HomeOwnedGames(id));
				}
			}

			if (req.Session.ContainsKey("UserId"))
			{
				var id = (int) req.Session.Get("UserId");
				var user = userService.FindUser(id);
				if (user.IsAdmin)
				{
					view.TypeOfUser = loggedAdmin;
				}
				view.TypeOfUser = loggedUser;

				//var games = this.gameService.ListAllUserGames(id);
			}
		    else
		    {
			    view.TypeOfUser = guest;
		    }
		    return new ViewResponse(HttpStatusCode.OK, view);
	    }


	}
}
