using System;
using WebServer.Application;
using WebServer.GameApplication;
using WebServer.GameApplication.Data;
using WebServer.Server.Contracts;
using WebServer.Server.Routing;
using WebServer.Server.Routing.Contracts;

namespace WebServer
{
    class Launcher : IRunnable
    {

	    private Server.WebServer webServer;

        static void Main(string[] args)
        {
            new Launcher().Run();
        }

	    public void Run()
	    {
			IApplication app = new GameApplication.GameApplication();
			var ctx = new MyDbContext();
		    ctx.Database.EnsureCreated();

		    IAppRouteConfig routeConfig = new AppRouteConfig();
			app.Start(routeConfig);

		    this.webServer = new Server.WebServer(8080, routeConfig);
			this.webServer.Run();

		
	    }
    }
}
