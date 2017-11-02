using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Application.Models
{
    public class Cart
    {

	    public Cart()
	    {
		    this.Cakes = new List<Cake>();
	    }
	    public List<Cake> Cakes { get; set; }

    }
}
