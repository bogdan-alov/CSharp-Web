using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebServer.GameApplication.Models;
using WebServer.Server.Contracts;

namespace WebServer.GameApplication.Views
{
	public class HomeIndexView : IView
	{

		public string TypeOfUser { get; set; }
		public List<Game> AllGames { get; set; }

		public string View()
		{
			var result = string.Empty;
			var allGames = new StringBuilder();

			var counter = 0;
			var lastCounter = 0;
			foreach (var game in AllGames)
			{
				if (counter == 0)
				{
					allGames.Append(@"<div class=""card-group"">");
				}
				else if (counter == 2)
				{
					allGames.Append($@"<div class=""card col-4 thumbnail""> <img class=""card-image-top img-fluid img-thumbnail"" onerror=""this.src='{game.Thumbnail}';"" src=""{game.Thumbnail}""> <div class=""card-body""> <h4 class=""card-title"">{game.Title}</h4> <p class=""card-text""><strong>Price</strong> - {game.Price}&euro;</p> <p class=""card-text""><strong>Size</strong> - {game.Size} GB</p> <p class=""card-text"">{game.Description}.</p> </div> <div class=""card-footer""> <a class=""card-button btn btn-outline-primary"" name=""info"" href=""#"">Info</a> <a class=""card-button btn btn-primary"" name=""buy"" href=""#"">Buy</a> </div> </div> ");
					allGames.Append(@"</div>");
					counter = 0;
					continue;

				}
				allGames.Append($@"<div class=""card col-4 thumbnail""> <img class=""card-image-top img-fluid img-thumbnail"" onerror=""this.src='{game.Thumbnail}';"" src=""{game.Thumbnail}""> <div class=""card-body""> <h4 class=""card-title"">{game.Title}</h4> <p class=""card-text""><strong>Price</strong> - {game.Price}&euro;</p> <p class=""card-text""><strong>Size</strong> - {game.Size} GB</p> <p class=""card-text"">{game.Description}.</p> </div> <div class=""card-footer""> <a class=""card-button btn btn-outline-primary"" name=""info"" href=""#"">Info</a> <a class=""card-button btn btn-primary"" name=""buy"" href=""#"">Buy</a> </div> </div> ");

				counter++;
			}

			if (TypeOfUser.Equals("guest"))
			{
				result = File.ReadAllText(@".\GameApplication\Resources\guest-home.html");
				result = result.Replace("<!--Games-->", allGames.ToString());


			}
			else if (TypeOfUser.Equals("logged-user"))
			{
				result = File.ReadAllText(@".\GameApplication\Resources\user-home.html");
				result = result.Replace("<!--Games-->", allGames.ToString());
			}
			else if (TypeOfUser.Equals("logged-admin"))
			{
				result = File.ReadAllText(@".\GameApplication\Resources\admin-home.html");
				result = result.Replace("<!--Games-->", allGames.ToString());
			}


			return result;
		}
	}
}
