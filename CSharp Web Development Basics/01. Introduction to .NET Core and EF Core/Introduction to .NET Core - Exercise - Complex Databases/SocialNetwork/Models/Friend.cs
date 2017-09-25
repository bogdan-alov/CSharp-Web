using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Models
{
    class Friend
    {
	    public int UserId { get; set; }
	    public User User { get; set; }

	    public int FriendId { get; set; }
	    public User FriendUser { get; set; }

    }
}
