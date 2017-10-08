using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServer.Application.Views;
using WebServer.Server.Enums;
using WebServer.Server.HTTP.Contracts;
using WebServer.Server.HTTP.Response;
using HttpStatusCode = WebServer.Server.Enums.HttpStatusCode;

namespace WebServer.Application.Controllers
{
	public class HomeController
	{
		public IHttpResponse Index()
		{
			return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
		}
	}
}
