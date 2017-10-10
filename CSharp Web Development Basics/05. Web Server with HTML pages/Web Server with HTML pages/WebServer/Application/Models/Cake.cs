using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Application.Models
{
    public class Cake
    {
	    public Cake(string name, decimal price)
	    {
		    Name = name;
		    Price = price;
	    }

	    public string Name { get; set; }

	    public decimal Price { get; set; }

    }
}
