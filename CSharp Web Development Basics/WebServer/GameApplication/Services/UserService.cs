using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using WebServer.GameApplication.Data;
using WebServer.GameApplication.Models;
using WebServer.GameApplication.Services.Interfaces;

namespace WebServer.GameApplication.Services
{
    public class UserService : IUserService
    {
	    public void Add(User user)
	    {
		    using (var ctx = new MyDbContext())
		    {
			    ctx.Users.Add(user);

			    ctx.SaveChanges();
		    }
	    }

	    public int LastUserId()
	    {
		    using (var ctx = new MyDbContext())
		    {
			    return ctx.Users.LastOrDefault().Id;
		    }
	    }

	    public User FindUser(string email)
	    {
			using (var ctx = new MyDbContext())
			{
				return ctx.Users.FirstOrDefault(c => c.Email == email);
			}
		}

	    public User FindUser(int id)
	    {
			using (var ctx = new MyDbContext())
			{
				return ctx.Users.FirstOrDefault(c => c.Id == id);
			}
		}
    }
}
