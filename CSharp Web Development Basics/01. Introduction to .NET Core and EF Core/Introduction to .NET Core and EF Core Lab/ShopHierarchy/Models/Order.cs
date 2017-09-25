using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHierarchy.Models
{
    public class Order
    {
	    public int Id { get; set; }

	    public Customer Customer { get; set; }

	    public int CustomerId { get; set; }

	    public ICollection<OrderItems> Items { get; set; } = new List<OrderItems>();
    }
}
