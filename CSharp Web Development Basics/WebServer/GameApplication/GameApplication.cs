using System;
using System.Collections.Generic;
using System.Text;
using WebServer.GameApplication.Controllers;
using WebServer.Server.Contracts;
using WebServer.Server.Handlers;
using WebServer.Server.Routing.Contracts;

namespace WebServer.GameApplication
{
    public class GameApplication : IApplication
    {
	    public void Start(IAppRouteConfig appRouteConfig)
	    {
			appRouteConfig.AddRoute("/", new GETHandler(httpContext => new HomeController().Index(httpContext)));
			appRouteConfig.AddRoute("/register", new GETHandler(httpContext => new AccountContoller().RegisterGet(httpContext.Request)));
		    appRouteConfig.AddRoute("/register", new POSTHandler(httpContext => new AccountContoller().RegisterPost(httpContext.Request)));
			appRouteConfig.AddRoute("/logout", new GETHandler(httpContext => new AccountContoller().Logout(httpContext.Request)));
		    appRouteConfig.AddRoute("/login", new GETHandler(httpContext => new AccountContoller().LoginGet(httpContext.Request)));
		    appRouteConfig.AddRoute("/login", new POSTHandler(httpContext => new AccountContoller().LoginPost(httpContext.Request)));
		}
    }
}
