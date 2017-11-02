using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServer.Application.Models
{
    public class CartService
    {
	    private Cart cart;
	    private const string underscore = "___________________________________________________________";


		public CartService()
	    {
		    this.cart = new Cart();
	    }

	    public void AddCakeToCart(Cake cake)
	    {
		    this.cart.Cakes.Add(cake);
	    }

	    public string CartProductsCount()
	    {
		    return $"{this.cart.Cakes.Count} products in cart.";
	    }

	    public string GetOrderedProducts()
	    {
		    var result = new StringBuilder();

		    foreach (var cartCake in cart.Cakes)
		    {
			    result.AppendLine($"{cartCake.Name} - ${cartCake.Price}");
		    }

		    result.AppendLine(underscore);
		    result.AppendLine($"Total cost: ${cart.Cakes.Sum(c => c.Price):f2}");
		    result.AppendLine(underscore);
			return result.ToString();
	    }
    }
}
