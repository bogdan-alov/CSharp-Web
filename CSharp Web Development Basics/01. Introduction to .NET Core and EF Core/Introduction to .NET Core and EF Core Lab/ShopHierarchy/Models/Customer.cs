using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopHierarchy.Models
{
    public class Customer
    {

	    public int Id { get; set; }

		[Required]
		[MaxLength(50)]
	    public string Name { get; set; }

	    public ICollection<Review> Reviews { get; set; } = new List<Review>();

	    public ICollection<Order> Orders { get; set; } = new List<Order>();

	    public Salesman Salesman { get; set; }

	    public int SalesmanId { get; set; }
    }
}
