using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebServer.Server.Contracts;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Application.Views
{
	public class HomeIndexView : IView
	{
		public string View()
		{
			return File.ReadAllText(@".\Application\Resources\index.html");
		}
	}
}
