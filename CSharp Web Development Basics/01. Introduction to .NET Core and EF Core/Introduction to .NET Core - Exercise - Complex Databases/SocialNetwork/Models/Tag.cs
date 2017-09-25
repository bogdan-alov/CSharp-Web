using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SocialNetwork.Models
{
    class Tag
    {

	    public int Id { get; set; }

		private string name;

		public string Name
		{
			get { return name; }
			set
			{
				name = this.TransformTag(value); ;
				
			}
		}

	    public ICollection<TagAlbum> Albums { get; set; } = new List<TagAlbum>();

		private string TransformTag(string name)
	    {
		    if (name.Length > 0)
		    {
			    if (!name.StartsWith("#"))
			    {
				    name = "#" + name;
			    }
				else if (name.Contains(" "))
			    {
				    Regex.Replace(name, @"\s+", "");
			    }
		    }

		    return name;
		}
    }
}
