using System;
using WebServer.GameApplication.Models;
using WebServer.GameApplication.Services;
using WebServer.GameApplication.Views;
using WebServer.Server.Enums;
using WebServer.Server.HTTP.Contracts;
using WebServer.Server.HTTP.Response;

namespace WebServer.GameApplication.Controllers
{
	public class AccountContoller
	{
		public AccountContoller()
		{
			this.service = new UserService();
		}
		private UserService service;

		public IHttpResponse RegisterGet(IHttpRequest req)
		{
			req.Cookies.ClearCookies();
			req.Session.Clear();

			return new ViewResponse(HttpStatusCode.OK, new RegisterView());
		}


		public IHttpResponse RegisterPost(IHttpRequest req)
		{
			var user = new User();
			try
			{

				if (req.FormData["password"] != req.FormData["confirmPassword"])
				{
					throw new Exception("Passwords must match.");
				}

				user.Email = req.FormData["email"];
				user.FullName = req.FormData["fullName"];
				user.Password = req.FormData["password"];
				user.IsAdmin = false;

			}
			catch
			{
				return new ViewResponse(HttpStatusCode.NotAuthorized, new RegisterView(true));
			}

			service.Add(user);
			var response = new RedirectResponse("/");
			req.Session.Add("UserId", service.LastUserId());


			return response;
		}

		public IHttpResponse Logout(IHttpRequest req)
		{

			var response = new RedirectResponse("/");
			req.Cookies.ClearCookies();
			req.Session.Clear();
			response.CookieCollection.ClearCookies();

			return response;
		}


		public IHttpResponse LoginGet(IHttpRequest req)
		{
			req.Cookies.ClearCookies();
			req.Session.Clear();

			return new ViewResponse(HttpStatusCode.OK, new LoginView());

		}


		public IHttpResponse LoginPost(IHttpRequest req)
		{
			try
			{
				var email = req.FormData["email"];
				var password = req.FormData["password"];

				if (service.FindUser(email) == null)
				{
					throw new Exception("Invalid credentials. No user with this email or password.");
				}

				var user = service.FindUser(email);

				if (password != user.Password)
				{
					throw new Exception("Invalid credentials. No user with this email or password.");
				}
				req.Session.Add("UserId", user.Id);
			}
			catch (Exception e)
			{
				return new ViewResponse(HttpStatusCode.NotAuthorized, new LoginView(e.Message));
			}


			return new RedirectResponse("/");

		}

	}
}
