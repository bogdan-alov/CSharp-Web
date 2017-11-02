using WebServer.GameApplication.Models;

namespace WebServer.GameApplication.Services.Interfaces
{
    public interface IUserService
    {

	    void Add(User user);
	    int LastUserId();
	    User FindUser(string email);
	    User FindUser(int id);
	}
}
