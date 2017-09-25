using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SocialNetwork.Models
{
    class TagAlbum
    {
		public int TagId { get; set; }

		public Tag Tag { get; set; }

		public int AlbumId { get; set; }

		public Album Album { get; set; }
    }
}
