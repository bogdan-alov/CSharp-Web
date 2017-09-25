using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Models
{
    class AlbumPicture
    {
	    public int AlbumId { get; set; }

	    public Album Album { get; set; }

	    public int PictureId { get; set; }

	    public Picture Picture { get; set; }
    }
}
