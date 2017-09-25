using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHierarchy.Models
{
    public class Review
    {
	    public int Id { get; set; }

	    public Customer Customer { get; set; }

	    public int CustomerId { get; set; }

	    public Item Item { get; set; }

	    public int ItemId { get; set; }
    }
}
