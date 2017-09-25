using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Core
{
    class Engine
    {

		private MyDbContext ctx = new MyDbContext();
	    public void Run()
	    {
		    
	    }

	    public void ListAllUsers()
	    {
		    var users = ctx.Users.Include(c => c.Friends).OrderByDescending(c => c.Friends.Count).ThenBy(c => c.Username);

		    foreach (var user in users)
		    {
			    var status = user.IsDeleted ? "Active" : "Inactive";
			    Console.WriteLine($"{user.Username} Number of Friends: {user.Friends.Count} Status: {status}");
		    }
	    }

	    public void ListAllActiveUsers()
	    {
			var users = ctx.Users.Include(c => c.Friends).Where(c=> c.IsDeleted == false && c.Friends.Count > 5).OrderBy(c => c.RegisteredOn).ThenByDescending(c => c.Friends.Count);

		    foreach (var user in users)
		    {
			    var difference = (user.LastTimeLoggedIn - user.RegisteredOn).TotalDays;

				Console.WriteLine($"{user.Username} Number of Friends: {user.Friends.Count} Period: {difference} days");
		    }
		}

	    public void ListAllAlbums()
	    {
		    var albums = ctx.Albums.Include(c => c.Pictures).OrderByDescending(c => c.Pictures.Count)
			    .ThenBy(c => c.User.Username);

		    foreach (var album in albums)
		    {
			    Console.WriteLine($"{album.Name}, {album.User.Username} Pics count: {album.Pictures.Count}");
		    }
	    }

	    public void ListAllPictures()
	    {
		    var pictures = ctx.Pictures.Include(c => c.Albums).Where(c => c.Albums.Count > 2)
			    .OrderByDescending(c => c.Albums.Count).ThenBy(c => c.Title).ToList();

		    foreach (var picture in pictures)
		    {
			    Console.WriteLine($"Title: {picture.Title} Authors:");
			    foreach (var pictureAlbum in picture.Albums)
			    {
				    Console.WriteLine($"-- {pictureAlbum.Album.User.Username}");
			    }
		    }
	    }

	    public void ListAllAlbums(Tag tag)
	    {
		    var albums = ctx.Albums.Include(c => c.Tags).Where(c => c.Tags.Any(x => x.Tag == tag))
			    .OrderByDescending(c => c.Tags.Count).ThenBy(c => c.Name).ToList();

		    foreach (var album in albums)
		    {
			    Console.WriteLine($"{album.Name} Owner: {album.User.Username}");
		    }
	    }

	    public void ListAllUsersWithTags()
	    {
		    var users = ctx.Users.Include(c => c.Albums).ThenInclude(c => c.Tags)
			    .Where(c => c.Albums.Count > 0 && c.Albums.Any(x => x.Tags.Count > 0)).ToList();

		    foreach (var user in users)
		    {
			    Console.WriteLine($"User: {user.Username}");
			    foreach (var userAlbum in user.Albums)
			    {
					Console.WriteLine($"Album title: {userAlbum.Name}");
				    Console.WriteLine("Tags:");
				    foreach (var userAlbumTag in userAlbum.Tags)
				    {

					    Console.WriteLine($"--{userAlbumTag.Tag.Name}");
				    }
				}
		    }
	    }
    }
}
