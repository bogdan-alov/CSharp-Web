using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using WebServer.Application.Models;
using WebServer.Application.Views;
using WebServer.Server.Enums;
using WebServer.Server.HTTP;
using WebServer.Server.HTTP.Contracts;
using WebServer.Server.HTTP.Response;
using HttpStatusCode = WebServer.Server.Enums.HttpStatusCode;

namespace WebServer.Application.Controllers
{
	public class HomeController
	{
		public IHttpResponse Index(IHttpRequest req)
		{
			var response = new ViewResponse(HttpStatusCode.OK, new HomeIndexView());

			

			
			return response;
		}

		public IHttpResponse AboutUs()
		{
			return new ViewResponse(HttpStatusCode.OK, new AboutUsView());
		}

		public IHttpResponse CalculatorGet(IHttpRequest req)
		{
			if (!req.Cookies.ContainsKey("UserId"))
			{
				return new RedirectResponse("/login");
			}

			return new ViewResponse(HttpStatusCode.OK, new CalculatorView() );
		}

		public IHttpResponse CalculatorPost(string firstNumber, string secondNumber, string sign)
		{
			Calculator.Validate(decimal.Parse(firstNumber), decimal.Parse(secondNumber), sign);
			return new RedirectResponse("/calculator");
		}

		public IHttpResponse LoginGet()
		{
			return new ViewResponse(HttpStatusCode.OK, new LoginView());
		}

		public IHttpResponse LoginPost(string username, string password)
		{
			LoginData.SetUp(username, password);

			var response = new RedirectResponse("/");
			var bytes = new UTF8Encoding().GetBytes(password);
			var hashBytes = MD5.Create().ComputeHash(bytes);
			var data = Convert.ToBase64String(hashBytes);
			var random = new Random().Next(1000);

			response.CookieCollection.Add(new HttpCookie("UserId", data));
			response.CookieCollection.Add(new HttpCookie("CartId", random.ToString()));
			
			return response;
		}
	}
}
